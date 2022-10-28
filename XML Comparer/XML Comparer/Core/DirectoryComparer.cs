namespace XML_Comparer.Core
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Xml;
	using XML_Comparer.Models;
	using XML_Comparer.ProgramConsts;

	public static class DirectoryComparer
	{
		/*In general I would use try catch in the methods, but since the essential checks are done in the Form1 class, there is no need to use it here at least at this stage.*/
		public static XmlDocument Compare(string oldPath, string newPath)
		{
			//Checking if oldPath or newPath is null or empty string => 
			if (string.IsNullOrEmpty(oldPath) || string.IsNullOrEmpty(newPath))
			{
				return null;
			}

			if (!NormalizeDirectory(ref oldPath))
			{
				return null;
			}

			if (!NormalizeDirectory(ref newPath))
			{
				return null;
			}

			var objectInfos = new List<ObjectConditions>();

			//Comparing the old with the new folder => 
			FileProcessing(newPath, string.Empty, oldPath, false, objectInfos);
			CheckDirectoryFilesAndFolder(newPath, oldPath, oldPath, false, objectInfos);

			//Comparing the new with the old folder => 
			FileProcessing(oldPath, string.Empty, newPath, true, objectInfos);
			CheckDirectoryFilesAndFolder(oldPath, newPath, newPath, true, objectInfos);

			return CreateXml(objectInfos);
		}

		private static bool NormalizeDirectory(ref string dirPath)
		{

			var directoryInfo = new DirectoryInfo(dirPath);
			if (!Directory.Exists(directoryInfo.FullName))
			{
				return false;
			}

			dirPath = directoryInfo.FullName;

			if (string.Compare("\\", dirPath.Substring(0, dirPath.Length - 1), StringComparison.InvariantCultureIgnoreCase) != 0)
			{
				dirPath = dirPath + "\\";
			}

			return true;
		}

		private static XmlDocument CreateXml(List<ObjectConditions> objectConditions)
		{
			//Using the XML System => 

			var xml = new XmlDocument();
			var root = xml.CreateElement("diff");
			xml.AppendChild(root);

			foreach (var condition in objectConditions)
			{
				XmlNode xmlNode = null;
				XmlAttribute xmlAttribute = null;

				if (condition.CanBeDeleted || condition.ShouldBeCreated)
				{
					xmlNode = xml.CreateElement(condition.CanBeDeleted ? ProgramConstants.DeleteAction : ProgramConstants.CreateAction);
					xmlAttribute = xml.CreateAttribute(condition.ObjectIsFile ? ProgramConstants.FileAction : ProgramConstants.DirAction);
					xmlAttribute.Value = condition.Path;
					xmlNode.Attributes.Append(xmlAttribute);
					root.AppendChild(xmlNode);
				}
			}
			return xml;
		}


		private static void CheckDirectoryFilesAndFolder(string baseComparedPath, string baseCheckedPath, string pathToCheck, bool isDelete, List<ObjectConditions> objectConditions)
		{
			string searchSample = string.Empty;

			if (string.IsNullOrEmpty(baseComparedPath) || string.IsNullOrEmpty(baseCheckedPath) || string.IsNullOrEmpty(pathToCheck))
			{
				return;
			}

			if (objectConditions == null)
			{
				objectConditions = new List<ObjectConditions>();
			}

			foreach (var folder in Directory.GetDirectories(pathToCheck))
			{
				searchSample = folder.Remove(0, baseCheckedPath.Length);
				if (!string.IsNullOrEmpty(searchSample))
				{
					CheckDirectoryFilesAndFolder(baseComparedPath, baseCheckedPath, folder, isDelete, objectConditions);

					if (isDelete)
					{
						DirectoryProcessing(baseComparedPath, searchSample, folder, isDelete, objectConditions);
						FileProcessing(baseComparedPath, searchSample, folder, isDelete, objectConditions);
					}
					else
					{
						FileProcessing(baseComparedPath, searchSample, folder, isDelete, objectConditions);
						DirectoryProcessing(baseComparedPath, searchSample, folder, isDelete, objectConditions);
					}
				}
			}

			return;
		}

		private static void DirectoryProcessing(string baseComparedPath, string searchSample, string dirPath, bool isDelete, List<ObjectConditions> objectConditions)
		{

			var dirConditions = new ObjectConditions()
			{
				CanBeDeleted = isDelete && !Directory.Exists(Path.Combine(baseComparedPath, searchSample)),
				ObjectIsFile = false,
				Path = isDelete ? dirPath : Path.Combine(baseComparedPath, searchSample),
				ShouldBeCreated = !isDelete && !Directory.Exists(Path.Combine(baseComparedPath, searchSample)),
			};

			if (isDelete)
			{
				objectConditions.Add(dirConditions);
			}
			else
			{
				objectConditions.Insert(0, dirConditions);
			}
		}

		private static void FileProcessing(string baseComparedPath, string searchSample, string dirPath, bool isDelete, List<ObjectConditions> objectConditions)
		{

			foreach (var file in Directory.GetFiles(dirPath))
			{
				var fi = new FileInfo(file);
				var fileInfo = new ObjectConditions()
				{
					CanBeDeleted = isDelete && !File.Exists(Path.Combine(Path.Combine(baseComparedPath, searchSample), fi.Name)),
					ObjectIsFile = true,
					Path = isDelete ? fi.FullName : Path.Combine(Path.Combine(baseComparedPath, searchSample), fi.Name),
					ShouldBeCreated = !isDelete && !File.Exists(Path.Combine(Path.Combine(baseComparedPath, searchSample), fi.Name)),
				};

				objectConditions.Insert(0, fileInfo);
			}
		}

	}
}

