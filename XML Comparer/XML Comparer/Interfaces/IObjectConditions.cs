namespace XML_Comparer.Interfaces
{
	public interface IObjectConditions
	{
		/// <summary>
		/// File or directory should be created
		/// </summary>
		bool ShouldBeCreated { get; set; }

		/// <summary>
		/// The file or directory can be deleted
		/// </summary>
		bool CanBeDeleted { get; set; }

		/// <summary>
		/// If object is a file then true otherwise false
		/// </summary>
		bool ObjectIsFile { get; set; }

		/// <summary>
		/// The full path/names to the directory or the files
		/// </summary>
		string Path { get; set; }
	}
}
