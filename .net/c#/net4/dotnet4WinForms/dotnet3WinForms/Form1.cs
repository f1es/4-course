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

		public Student SelectedStudent => 
			listBox1.SelectedItem as Student;

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
			var loadedStudent = fileManager.LoadStudent();
			Students.Add(loadedStudent);
			UpdateStudent(SelectedStudent);
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
	}
}
