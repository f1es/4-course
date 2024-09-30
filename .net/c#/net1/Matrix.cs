namespace net1;

public class Matrix
{
	private double[,] matrix;

    public Matrix(int size)
    {
		matrix = new double[5, 3];
    }
    public void Print()
	{
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				Console.Write(matrix[i, j] + "\t");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine();
		}
	}

	public void FillRandom()
	{
		for (int i = 0; i < matrix.GetLength(0); i++)
		{
			for (int j = 0; j < matrix.GetLength(1); j++)
			{
				matrix[i, j] = new Random().Next(100);
			}
		}
	}

	public void Swap(int number)
	{
		bool isNumberLowerThanDimensions =
			number < matrix.GetLength(0) &&
			number < matrix.GetLength(1);

		if (!isNumberLowerThanDimensions)
		{
			Console.WriteLine("Число должно быть меньше длинны измерений");
			return;
		}

		var minimumLength = int.MaxValue;
		for (int i = 0; i < matrix.Rank; i++)
		{
			if (minimumLength > matrix.GetLength(i))
				minimumLength = matrix.GetLength(i);
		}

		for (int i = 0; i < minimumLength; i++)
		{
			var temp = matrix[i, number];
			matrix[i, number] = matrix[number, i];
			matrix[number, i] = temp;
		}
	}
}
