using dotnet2;

namespace dotnet3WinForms
{
	public partial class StudentForm : Form
	{
		public Student Student { get; set; }
		public StudentForm()
		{
			InitializeComponent();
		}

		public StudentForm(Student student)
		{
			InitializeComponent();
			Student = student;
			firstNameTextBox.Text = student.FirstName;
			lastNameTextBox.Text = student.LastName;
		}

		private void acceptButton_Click(object sender, EventArgs e)
		{
			var firstName = firstNameTextBox.Text;
			var lastName = lastNameTextBox.Text;
			Student = new Student(firstName, lastName);
			DialogResult = DialogResult.OK;
			Close();
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
