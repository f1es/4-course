using dotnet2.Exceptions;

namespace dotnet2;

public class Exam : IPrintable
{
	private Student _student;
	private DateTime _date;
	private int _grade;
	private List<string> _questions;
	public Student Student 
	{ 
		get => _student; 
		private set => _student = value; 
	}
	public DateTime Date 
	{ 
		get => _date; 
		private set => _date = value; 
	}
	public int Grade 
	{ 
		get => _grade; 
		private set
		{
			if (value < 0 || value > 10)
				throw new IncorrectGradeException($"Grade should be in range 0 to 10, your input {value}");

			_grade = value;
		}
	}
	public List<string> Questions 
	{ 
		get => _questions; 
		private set => _questions = value; 
	}

	public Exam(
		Student student,
		DateTime date,
		int grade,
		List<string> questions)
    {
        Student = student;
		Date = date;
		Grade = grade;
		Questions = questions;
    }

	public void Print()
	{
		Console.WriteLine("\tEXAM");
		Console.WriteLine(
			$"Student: {_student.FirstName} {_student.LastName}\n" +
			$"Date: {_date.ToString()}\n" +
			$"Grade: {_grade}\n" +
			$"Questions:");

		foreach (var question in Questions)
		{
			Console.WriteLine("\t - " + question);
		}
	}

	public static Exam Input()
	{
		Console.WriteLine("Enter exam");

		var student = Student.Input();

		Console.Write("Enter exam date:");
		var date = DateTime.Parse(Console.ReadLine());

		Console.Write("Enter exam grade:");
		var grade = int.Parse(Console.ReadLine());

		var questions = new List<string>();
		Console.Write("Enter questions count:");

		var count = int.Parse(Console.ReadLine());
		for (int i = 0; i < count; i++)
		{
			Console.Write("Enter exam question:");
			questions.Add(Console.ReadLine());
		}

		return new Exam(student, date, grade, questions);
	}
}
