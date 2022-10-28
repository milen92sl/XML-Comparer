namespace XML_Comparer.Models
{
	using XML_Comparer.Interfaces;
	public class ObjectConditions : IObjectConditions
	{
		public bool ShouldBeCreated { get; set; }
		public bool CanBeDeleted { get; set; }
		public string Path { get; set; }
		public bool ObjectIsFile { get; set; }
	}
}
