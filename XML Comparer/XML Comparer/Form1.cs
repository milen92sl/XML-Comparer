namespace XML_Comparer
{
	using System;
	using System.IO;
	using System.Text;
	using System.Web.Services.Description;
	using System.Windows.Forms;
	using System.Xml;
	using XML_Comparer.Core;

	public partial class Form1 : Form
	{
		XmlDocument xmlDocument;

		public Form1()
		{
			InitializeComponent();
		}

		//This method should return the path of the selected folder => 
		private string GetDirPath()
		{
			try
			{
				using (this.folderBrowserDialog)
				{
					if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
					{
						// returns the path of the selected folder.
						return this.folderBrowserDialog.SelectedPath;
					}
					else
					{
						return string.Empty;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error - {ex}");
				return string.Empty;
			}
		}

		/// <summary>
		/// Coparing the paths and set the result to the XML document.
		/// </summary>
		/// <param name="oldPath">the oldPath is the path with the date that must be keeped.</param>
		/// <param name="newPath">The newPath as folder which should be become a copy of the oldpath.</param>
		private void GetXmlDifferences(string oldPath, string newPath)
		{
			try
			{
				if (string.IsNullOrEmpty(oldPath) || string.IsNullOrEmpty(newPath))
				{
					MessageBox.Show($"Please make sure that both paths are valid paths.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				this.xmlDocument = DirectoryComparer.Compare(oldPath, newPath);
				if (this.xmlDocument != null)
				{
					XmlDeclaration xmlDeclaration = this.xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
					XmlElement root = this.xmlDocument.DocumentElement;
					this.xmlDocument.InsertBefore(xmlDeclaration, root);
				}
				else
				{
					MessageBox.Show("Xml information was not collected. Please make sure that your paths are correct!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error - {ex}");
				return;
			}
		}

		//This method should visualize the generated XML in the Result    
		private void ShowXml()
		{
			progressBar1.Value = progressBar1.Minimum;
			try
			{
				if (this.xmlDocument != null)
				{
					var sb = new StringBuilder();
					using (var sw = new StringWriter(sb))
					{
						using (var xmlWriter = new XmlTextWriter(sw))
						{
							xmlWriter.Formatting = Formatting.Indented;
							var element = xmlDocument.DocumentElement.ParentNode;
							element.WriteTo(xmlWriter);
						}
					}

					xmlTextBoxDiff.Text = sb.ToString();
					progressBar1.Value = progressBar1.Maximum;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error - {ex}");
			}
		}

		// This method should save the generated XML into a file (diff.xml) in a selected by user folder.
		private void SaveXml()
		{
			try
			{
				if (this.xmlDocument == null)
				{
					MessageBox.Show("The result is not valid. File cannot be saved.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				var dirPath = this.GetDirPath();
				if (!Directory.Exists(dirPath))
				{
					Directory.CreateDirectory(dirPath);
					if (!Directory.Exists(dirPath))
					{
						MessageBox.Show("The destination path was not created. Please try again in other directory path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}

				dirPath = Path.Combine(dirPath, "diff.xml");
				if (File.Exists(dirPath))
				{
					File.Delete(dirPath);
					if (File.Exists(dirPath))
					{
						MessageBox.Show($"The existing file cannot be deleted in the current directory - {dirPath}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}

				using (var fileStream = new FileStream(dirPath, FileMode.CreateNew, FileAccess.ReadWrite, FileShare.Read))
				{
					this.xmlDocument.Save(fileStream);
					if (!File.Exists(dirPath))
					{
						MessageBox.Show($"The file was not exists in the current directory - {dirPath}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						MessageBox.Show("The result is saved successfully.", "OK", MessageBoxButtons.OK);
					}
				}
			}

			catch (Exception ex)
			{
				MessageBox.Show($"Unexpected error - {ex}");
			}
		}

		#region Events
		private void btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOldPath_Click(object sender, EventArgs e)
		{
			oldPathTextBox.Text = this.GetDirPath();
		}

		private void btnNewPath_Click(object sender, EventArgs e)
		{
			newPathTextBox.Text = this.GetDirPath();
		}

		private void btnCompare_Click(object sender, EventArgs e)
		{
			this.xmlTextBoxDiff.Clear();
			Cursor.Current = Cursors.WaitCursor;
			this.GetXmlDifferences(oldPathTextBox.Text, newPathTextBox.Text);
			this.ShowXml();
			Cursor.Current = Cursors.Default;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			this.SaveXml();
		}
		#endregion
	}
}