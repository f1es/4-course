
using net1;

class Program
{
	public static void Main()
	{
		/*
		 2.4. В двухмерном массиве вещественных чисел поменять местами строки и столбцы с одинаковыми номерами.
		*/
		Matrix matrix = new Matrix(5);

		matrix.FillRandom();
		matrix.Print();
		matrix.Swap(2);
		Console.WriteLine();
		Console.WriteLine();
		matrix.Print();


		Console.WriteLine();
		Console.WriteLine();

		/*
		 3.4. Составить программу, которая будет вводить строку в переменную String. Определить, сколько раз в строке встречается заданное слово.
		 */
		var text1 = "ig ig4w owg ig rrr ig";
		Console.WriteLine(text1);
		WordFinder wordFinder = new WordFinder(text1);
		wordFinder.PrintWordCount("ig");


		Console.WriteLine();
		Console.WriteLine();

		/*
		 4.4. Задан текст. После каждой буквы «о» вставить сочетание «Oк».
		 */
		var text2 = "owerigriw olllloe eee";
		Console.WriteLine(text2);
		OkPlacer.PlaceOk(text2);
	}
}