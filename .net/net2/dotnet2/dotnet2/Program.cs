
using dotnet2;

class Program
{
	public static void Main()
	{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
		var questions = new List<string>()
		{
			"Who?",
			"Why?",
			"How?",
			"Where?",
			"When?"
		};

		var student = new Student("Ivanov", "Ivan");
		var exam = new Exam(student, DateTime.Now, 7, questions);
		var exams = new Exams();

		exams.AddExam(exam);
		exams.AddExam(exam);
		exams.AddExam(exam);

		IPrintable printable = student;
		printable.Print();
		printable = exam;
		printable.Print();
		printable = exams;
		printable.Print();

		exams[0].Print();

		//throw new CustomException("Thing that should not be");
	}

	public static Student CreateStudent()
	{
		var firstName = Console.ReadLine();
		var lastName = Console.ReadLine();
		var student = new Student(firstName, lastName);
		return student;
	}

	public static List<string> CreateQuestions()
	{
		var questions = new List<string>();
		for (int i = 0; i < 5; i ++)
		{
			questions.Add(Console.ReadLine());
		}
		return questions;
	}

	public static Exam CreateExam(Student student, List<string> questions)
	{
		var date = DateTime.Parse(Console.ReadLine());
		var grade = int.Parse(Console.ReadLine());
		var exam = new Exam(student, date, grade, questions);
		return exam;
	}
}