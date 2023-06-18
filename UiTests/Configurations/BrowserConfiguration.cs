namespace UiTests.Configurations
{
	internal class BrowserConfiguration : IConfiguration
	{
		public string baseURL {	get;set;}
		public string browser { get; set; }
		public int SmallWait { get; set; }
		public int MediumWait { get; set; }

		public string JsonSectionName => "Browser";
	}
}
