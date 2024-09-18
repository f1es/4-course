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
		private set => _grade = value; 
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
}
