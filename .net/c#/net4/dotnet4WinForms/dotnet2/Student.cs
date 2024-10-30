namespace dotnet2;

public class Student : Human, IPrintable
{
	public DateOnly CreationDate { get; set; }
	public string ImageSource { get; set; }
	public string Description { get; set; }
	public Student(string firstName, string lastName) :
		base(firstName, lastName)
	{

	}
	public override string ToString()
	{
		return $"{FirstName} \t{LastName} \t{CreationDate}";
	}
	public override void Print()
	{
		Console.WriteLine("\tSTUDENT");
		Console.WriteLine($"Student: {FirstName} {LastName}");
	}
	public static Student Input()
	{
		Console.WriteLine("Enter student");

		Console.Write("Enter student first name:");
		var firstName = Console.ReadLine();

		Console.Write("Enter student last name:");
		var lastName = Console.ReadLine();

		return new Student(firstName, lastName);
	}
}
