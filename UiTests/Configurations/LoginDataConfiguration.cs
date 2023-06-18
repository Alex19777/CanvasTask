namespace UiTests.Configurations
{
	internal class LoginDataConfiguration : IConfiguration
	{
		public string email { get; set; }
		public string password { get; set; }

		public string JsonSectionName => "LoginData";
	}
}
