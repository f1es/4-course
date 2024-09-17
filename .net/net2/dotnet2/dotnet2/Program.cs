
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
}