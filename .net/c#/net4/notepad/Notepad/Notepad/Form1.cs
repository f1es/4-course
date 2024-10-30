namespace Notepad;

public partial class Form1 : Form
{
	public Form1()
	{
		InitializeComponent();
	}

	private void saveButton_Click(object sender, EventArgs e)
	{
		var currentDirectory = Directory.GetCurrentDirectory();
		var filePath = Path.Combine(currentDirectory, "notepad.txt");
		File.AppendAllText(filePath, textBox.Text);
	}

	private void loadButton_Click(object sender, EventArgs e)
	{
		var currentDictionary = Directory.GetCurrentDirectory();
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = currentDictionary;
		openFileDialog.DefaultExt = "txt";

		openFileDialog.ShowDialog();

		var file = openFileDialog.OpenFile();
		var streamReader = new StreamReader(file);
		var text = streamReader.ReadToEnd();

		textBox.Text = text;
	}

	private void colorButton_Click(object sender, EventArgs e)
	{
		var colorDialog = new ColorDialog();

		colorDialog.ShowDialog();

		var color = colorDialog.Color;

		textBox.ForeColor = color;
	}

	private void fontButton_Click(object sender, EventArgs e)
	{
		var fontDialog = new FontDialog();

		fontDialog.ShowDialog();

		var font = fontDialog.Font;

		textBox.Font = font;
	}
}
