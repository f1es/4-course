namespace dotnet2;

public class Exams : IPrintable
{
	private List<Exam> _exams;

	public int Count =>
	 _exams.Count;

	public Exams()
    {
        _exams = new List<Exam>();
    }

    public Exam this[int index]
    {
        get => _exams[index];
        set => _exams[index] = value;
    }

    public void AddExam(Exam exam) => 
        _exams.Add(exam);

    public void Print()
    {
		Console.WriteLine("\tEXAMS");
		foreach (var exam in _exams)
        {
            exam.Print();
        }
    }
}
