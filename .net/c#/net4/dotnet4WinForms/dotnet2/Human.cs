namespace dotnet2;

public abstract class Human
{
	private string _firstName;
	private string _lastName;

	public string FirstName
	{
		get => _firstName; 
		set => _firstName = value;
	}

	public string LastName
	{
		get => _lastName;
		set => _lastName = value;
	}

    public Human(
		string firstName, 
		string lastName)
    {
        _firstName = firstName;
		_lastName = lastName;
    }

	public virtual void Print()
	{
		Console.WriteLine($"first name: {_firstName}");
		Console.WriteLine($"last name: {_lastName}");
	}
}
