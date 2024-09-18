namespace dotnet2;

public class Student : Human, IPrintable
{
	public Student(string firstName, string lastName) :
		base(firstName, lastName)
	{ 

	}

	public override void Print()
	{
		Console.WriteLine("\tSTUDENT");
		Console.WriteLine($"Student: {FirstName} {LastName}");
	}
}
