namespace dotnet3WinForms
{
	partial class StudentForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			acceptButton = new Button();
			cancelButton = new Button();
			firstNameTextBox = new TextBox();
			lastNameTextBox = new TextBox();
			firstNameLabel = new Label();
			lastNameLabel = new Label();
			SuspendLayout();
			// 
			// acceptButton
			// 
			acceptButton.Location = new Point(56, 139);
			acceptButton.Name = "acceptButton";
			acceptButton.Size = new Size(75, 23);
			acceptButton.TabIndex = 0;
			acceptButton.Text = "Accept";
			acceptButton.UseVisualStyleBackColor = true;
			acceptButton.Click += acceptButton_Click;
			// 
			// cancelButton
			// 
			cancelButton.Location = new Point(151, 139);
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new Size(75, 23);
			cancelButton.TabIndex = 1;
			cancelButton.Text = "Cancel";
			cancelButton.UseVisualStyleBackColor = true;
			cancelButton.Click += cancelButton_Click;
			// 
			// firstNameTextBox
			// 
			firstNameTextBox.Location = new Point(102, 43);
			firstNameTextBox.Name = "firstNameTextBox";
			firstNameTextBox.Size = new Size(132, 23);
			firstNameTextBox.TabIndex = 2;
			// 
			// lastNameTextBox
			// 
			lastNameTextBox.Location = new Point(102, 88);
			lastNameTextBox.Name = "lastNameTextBox";
			lastNameTextBox.Size = new Size(132, 23);
			lastNameTextBox.TabIndex = 3;
			// 
			// firstNameLabel
			// 
			firstNameLabel.AutoSize = true;
			firstNameLabel.Location = new Point(41, 46);
			firstNameLabel.Name = "firstNameLabel";
			firstNameLabel.Size = new Size(60, 15);
			firstNameLabel.TabIndex = 4;
			firstNameLabel.Text = "first name";
			// 
			// lastNameLabel
			// 
			lastNameLabel.AutoSize = true;
			lastNameLabel.Location = new Point(38, 91);
			lastNameLabel.Name = "lastNameLabel";
			lastNameLabel.Size = new Size(58, 15);
			lastNameLabel.TabIndex = 5;
			lastNameLabel.Text = "last name";
			// 
			// StudentForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(307, 231);
			Controls.Add(lastNameLabel);
			Controls.Add(firstNameLabel);
			Controls.Add(lastNameTextBox);
			Controls.Add(firstNameTextBox);
			Controls.Add(cancelButton);
			Controls.Add(acceptButton);
			Name = "StudentForm";
			Text = "StudentForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button acceptButton;
		private Button cancelButton;
		private TextBox firstNameTextBox;
		private TextBox lastNameTextBox;
		private Label firstNameLabel;
		private Label lastNameLabel;
	}
}