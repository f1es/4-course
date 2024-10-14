namespace dotnet3WinForms
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			listBox1 = new ListBox();
			editButton = new Button();
			deleteButton = new Button();
			addButton = new Button();
			SuspendLayout();
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(12, 12);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(212, 424);
			listBox1.TabIndex = 1;
			// 
			// editButton
			// 
			editButton.Location = new Point(230, 12);
			editButton.Name = "editButton";
			editButton.Size = new Size(75, 23);
			editButton.TabIndex = 2;
			editButton.Text = "Edit";
			editButton.UseVisualStyleBackColor = true;
			editButton.Click += editButton_Click;
			// 
			// deleteButton
			// 
			deleteButton.Location = new Point(230, 41);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(75, 23);
			deleteButton.TabIndex = 3;
			deleteButton.Text = "Delete";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += deleteButton_Click;
			// 
			// addButton
			// 
			addButton.Location = new Point(230, 70);
			addButton.Name = "addButton";
			addButton.Size = new Size(75, 23);
			addButton.TabIndex = 4;
			addButton.Text = "Add";
			addButton.UseVisualStyleBackColor = true;
			addButton.Click += addButton_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(329, 450);
			Controls.Add(addButton);
			Controls.Add(deleteButton);
			Controls.Add(editButton);
			Controls.Add(listBox1);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
		}

		#endregion

		private ListBox listBox1;
		private Button editButton;
		private Button deleteButton;
		private Button addButton;
	}
}
