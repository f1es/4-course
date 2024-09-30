
using net1;

class Program
{
	public static void Main()
	{
		while (true)
		{
			Console.WriteLine("Choose № (1,2,3)");
			Console.Write("->");
			var input = Console.ReadLine();
			Console.Clear();
			switch (input)
			{
				case "1":
					/*
					 2.4. В двухмерном массиве вещественных чисел поменять местами строки и столбцы с одинаковыми номерами.
					*/
					Matrix matrix = new Matrix(5);

					matrix.FillRandom();
					matrix.Print();
					matrix.Swap(1);
					Console.WriteLine();
					Console.WriteLine();
					matrix.Print();

					Console.WriteLine();
					Console.WriteLine();
					break;

				case "2":
					/*
					 3.4. Составить программу, которая будет вводить строку в переменную String. Определить, сколько раз в строке встречается заданное слово.
					 */
					Console.WriteLine("Enter word");
					var word = Console.ReadLine();
					Console.WriteLine("Enter text");
					var text1 = Console.ReadLine();

					Console.WriteLine(text1);
					WordFinder wordFinder = new WordFinder(text1);
					wordFinder.PrintWordCount(word);

					Console.WriteLine();
					Console.WriteLine();
					break;

				case "3":
					/*
					 4.4. Задан текст. После каждой буквы «о» вставить сочетание «Oк».
					 */
					Console.WriteLine("Enter text");
					var text2 = Console.ReadLine();
					OkPlacer.PlaceOk(text2);
					break;
			}
		}
	}
}