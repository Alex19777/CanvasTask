using UiTests.models;

namespace UiTests.Builders
{
	public class ContactBuilder
	{
		ContactModel ContactModel { get; }

		public ContactBuilder()
		{
			ContactModel = new ContactModel();
		}

		public ContactBuilder(ContactModel contactModel)
		{
			ContactModel = contactModel;
		}

		public ContactBuilder WithFirstName(string firstName)
		{
			ContactModel.FirstName = firstName;
			return this;
		}

		public ContactBuilder WithLastName(string lastName)
		{
			ContactModel.LastName = lastName;
			return this;
		}

		public ContactBuilder WithCategories(params string[] categories)
		{
			ContactModel.Categories = new List<string>(categories);
			return this;
		}

		public ContactBuilder WithRole(string role)
		{
			ContactModel.Role = role;
			return this;
		}

		public ContactModel Build()
		{
			return ContactModel;
		}
	}
}
