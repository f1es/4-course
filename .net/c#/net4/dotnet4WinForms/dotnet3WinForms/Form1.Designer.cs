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
			saveButton = new Button();
			loadButton = new Button();
			pictureBox = new PictureBox();
			imageButton = new Button();
			descriptionTextBox = new TextBox();
			((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
			SuspendLayout();
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(12, 12);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(343, 274);
			listBox1.TabIndex = 1;
			listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// editButton
			// 
			editButton.Location = new Point(361, 12);
			editButton.Name = "editButton";
			editButton.Size = new Size(75, 23);
			editButton.TabIndex = 2;
			editButton.Text = "Edit";
			editButton.UseVisualStyleBackColor = true;
			editButton.Click += editButton_Click;
			// 
			// deleteButton
			// 
			deleteButton.Location = new Point(361, 41);
			deleteButton.Name = "deleteButton";
			deleteButton.Size = new Size(75, 23);
			deleteButton.TabIndex = 3;
			deleteButton.Text = "Delete";
			deleteButton.UseVisualStyleBackColor = true;
			deleteButton.Click += deleteButton_Click;
			// 
			// addButton
			// 
			addButton.Location = new Point(361, 70);
			addButton.Name = "addButton";
			addButton.Size = new Size(75, 23);
			addButton.TabIndex = 4;
			addButton.Text = "Add";
			addButton.UseVisualStyleBackColor = true;
			addButton.Click += addButton_Click;
			// 
			// saveButton
			// 
			saveButton.Location = new Point(361, 99);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(75, 23);
			saveButton.TabIndex = 5;
			saveButton.Text = "Save";
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += saveButton_Click;
			// 
			// loadButton
			// 
			loadButton.Location = new Point(361, 128);
			loadButton.Name = "loadButton";
			loadButton.Size = new Size(75, 23);
			loadButton.TabIndex = 6;
			loadButton.Text = "Load";
			loadButton.UseVisualStyleBackColor = true;
			loadButton.Click += loadButton_Click;
			// 
			// pictureBox
			// 
			pictureBox.Location = new Point(222, 292);
			pictureBox.Name = "pictureBox";
			pictureBox.Size = new Size(133, 134);
			pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox.TabIndex = 7;
			pictureBox.TabStop = false;
			// 
			// imageButton
			// 
			imageButton.Location = new Point(361, 157);
			imageButton.Name = "imageButton";
			imageButton.Size = new Size(75, 23);
			imageButton.TabIndex = 8;
			imageButton.Text = "Image";
			imageButton.UseVisualStyleBackColor = true;
			imageButton.Click += imageButton_Click;
			// 
			// descriptionTextBox
			// 
			descriptionTextBox.Location = new Point(12, 292);
			descriptionTextBox.Multiline = true;
			descriptionTextBox.Name = "descriptionTextBox";
			descriptionTextBox.Size = new Size(204, 134);
			descriptionTextBox.TabIndex = 9;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(448, 519);
			Controls.Add(descriptionTextBox);
			Controls.Add(imageButton);
			Controls.Add(pictureBox);
			Controls.Add(loadButton);
			Controls.Add(saveButton);
			Controls.Add(addButton);
			Controls.Add(deleteButton);
			Controls.Add(editButton);
			Controls.Add(listBox1);
			Name = "Form1";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox listBox1;
		private Button editButton;
		private Button deleteButton;
		private Button addButton;
		private Button saveButton;
		private Button loadButton;
		private PictureBox pictureBox;
		private Button imageButton;
		private TextBox descriptionTextBox;
	}
}
