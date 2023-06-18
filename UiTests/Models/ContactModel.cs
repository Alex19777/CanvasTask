namespace UiTests.models;

public class ContactModel
{
    public string FirstName { get; set; }
    public string LastName{ get; set; }
	public List<string> Categories { get; set; }
	public string Role { get; set; }

	public override bool Equals(object obj) => Equals(obj as ContactModel);

	public override int GetHashCode() => base.GetHashCode();
	public override string ToString() => $"{nameof(FirstName)}: {FirstName}. {nameof(LastName)}: {LastName}. " +
		$"{nameof(Role)}: {Role}. {nameof(Categories)}:[{string.Join(",", Categories)}]. ";

	public bool Equals(ContactModel other) => other != null
		&& FirstName == other.FirstName
		&& LastName == other.LastName
		&& Categories.SequenceEqual(other.Categories)
		&& Role.Equals(other.Role);
}