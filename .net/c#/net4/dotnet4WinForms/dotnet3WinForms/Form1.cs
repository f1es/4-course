using dotnet2;
using System.ComponentModel;

namespace dotnet3WinForms
{
	public partial class Form1 : Form
	{
		private FileManager fileManager;
		public BindingList<Student> Students { get; set; } = new BindingList<Student>()
		{
			//new Student("Ivan","Ivanov"),
			//new Student("Sergey","Sergeev"),
		};

		public Form1()
		{
			InitializeComponent();
			listBox1.DataSource = Students;
			fileManager = new FileManager();
		}

		private void deleteButton_Click(object sender, EventArgs e)
		{
			var selected = listBox1.SelectedItem as Student;

			if (selected is null)
				return;

			Students.Remove(selected);
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
		}

		private void editButton_Click(object sender, EventArgs e)
		{
			var selectedStudent = listBox1.SelectedItem as Student;

			if (selectedStudent is null)
				return;

			var index = Students.IndexOf(selectedStudent);

			using (var editForm = new StudentForm(selectedStudent))
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
			var selectedStudent = listBox1.SelectedItem as Student;

			if (selectedStudent is null)
				return;

			fileManager.SaveStudent(selectedStudent);
		}

		private void loadButton_Click(object sender, EventArgs e)
		{
			var loadedStudent = fileManager.LoadStudent();
			Students.Add(loadedStudent);
		}
	}
}
