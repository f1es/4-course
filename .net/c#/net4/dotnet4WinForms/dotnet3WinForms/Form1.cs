using dotnet2;
using System.ComponentModel;
using System.Diagnostics;

namespace dotnet3WinForms;

public partial class Form1 : Form
{
	private FileManager fileManager;
	public BindingList<Student> Students { get; set; } = new BindingList<Student>()
	{
		//new Student("Ivan","Ivanov"),
		//new Student("Sergey","Sergeev"),
	};
	public BindingList<string> SortTypes { get; set; } = new BindingList<string>
	{
		"Name",
		"Date",
	};

	public Student SelectedStudent =>
		listBox1.SelectedItem as Student;

	public Form1()
	{
		InitializeComponent();
		listBox1.DataSource = Students;
		sortComboBox.DataSource = SortTypes;
		fileManager = new FileManager();
	}

	private void deleteButton_Click(object sender, EventArgs e)
	{
		var selected = listBox1.SelectedItem as Student;

		if (selected is null)
			return;

		Students.Remove(selected);
		SortStudents();
	}

	private void addButton_Click(object sender, EventArgs e)
	{
		using (var addForm = new StudentForm())
		{
			if (addForm.ShowDialog(this) == DialogResult.OK)
			{
				Students.Add(addForm.Student);
			}
		}

		SortStudents();
	}

	private void editButton_Click(object sender, EventArgs e)
	{
		if (SelectedStudent is null)
			return;

		var index = Students.IndexOf(SelectedStudent);

		using (var editForm = new StudentForm(SelectedStudent))
		{
			if (editForm.ShowDialog(this) == DialogResult.OK)
			{
				var editedStudent = editForm.Student;
				Students.RemoveAt(index);
				Students.Insert(index, editedStudent);
			}
		}
	}

	private void saveButton_Click(object sender, EventArgs e)
	{
		if (SelectedStudent is null)
			return;

		SelectedStudent.Description = descriptionTextBox.Text;

		try
		{
			fileManager.SaveStudent(SelectedStudent);
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private void loadButton_Click(object sender, EventArgs e)
	{
		try
		{
			var loadedStudent = fileManager.LoadStudent();
			Students.Add(loadedStudent);
			UpdateStudent(SelectedStudent);
			SortStudents();
		}
		catch
		{

		}
	}

	private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
	{
		UpdateStudent(SelectedStudent);
	}

	private void imageButton_Click(object sender, EventArgs e)
	{
		if (SelectedStudent is null)
			return;

		fileManager.SelectImage(SelectedStudent, pictureBox);
	}

	private void UpdateStudent(Student student)
	{
		if (student is null)
		{
			pictureBox.ImageLocation = null;
			descriptionTextBox.Text = string.Empty;
			return;
		}

		fileManager.LoadImage(student, pictureBox);
		descriptionTextBox.Text = student.Description;
	}

	private void sortComboBox_SelectedIndexChanged(object sender, EventArgs e)
	{
		SortStudents();
	}

	private void SortStudents()
	{
		var selectedSort = sortComboBox.SelectedItem as string;
		var orderedStudents = new List<Student>(Students.ToList());
		switch (selectedSort)
		{
			case "Name":
				orderedStudents = Students.OrderBy(s => s.FirstName).ToList();
				Update();
				listBox1.Update();
				break;
			case "Date":
				orderedStudents = Students.OrderBy(s => s.CreationDate).ToList();
				Update();
				listBox1.Update();
				break;
		}

		Students.Clear();
		foreach (var student in orderedStudents)
		{
			Students.Add(student);
		}
	}

	private void descriptionTextBox_TextChanged(object sender, EventArgs e)
	{
		if (SelectedStudent is null)
			return;

		SelectedStudent.Description = descriptionTextBox.Text;
	}
}
