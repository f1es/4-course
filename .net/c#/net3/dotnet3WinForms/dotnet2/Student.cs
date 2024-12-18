﻿namespace dotnet2;

public class Student : Human, IPrintable
{
	public Student(string firstName, string lastName) :
		base(firstName, lastName)
	{

	}

	public override string ToString()
	{
		return $"{FirstName} {LastName}";
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
