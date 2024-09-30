
using dotnet2;

class Program
{
	public static void Main()
	{                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
		var exams = new Exams();

		while (true)
		{
			try
			{
				Menu(exams);
			}
			catch (Exception ex) 
			{
				Console.WriteLine("Ой что-то сломалось");
				Console.WriteLine(ex.Message);
			}
		}
	}

	public static void Menu(Exams exams)
	{
		Console.WriteLine("1 - add exam\n2 - print exams\n3 - print exam by index");
		var menu = int.Parse(Console.ReadLine());
		Console.Clear();

		switch (menu)
		{
			case 1:
				var exam = Exam.Input();
				exams.AddExam(exam);
				break;
			case 2:
				exams.Print();
				break;
			case 3:
				Console.WriteLine($"Enter exam index, max - {exams.Count}");
				var index = int.Parse(Console.ReadLine());
				exams[index].Print();
				break;
		}
	}
}