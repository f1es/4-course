namespace Notepad
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
			textBox = new TextBox();
			saveButton = new Button();
			loadButton = new Button();
			colorButton = new Button();
			fontButton = new Button();
			SuspendLayout();
			// 
			// textBox
			// 
			textBox.Location = new Point(1, 39);
			textBox.Multiline = true;
			textBox.Name = "textBox";
			textBox.Size = new Size(685, 511);
			textBox.TabIndex = 0;
			// 
			// saveButton
			// 
			saveButton.Location = new Point(0, 10);
			saveButton.Name = "saveButton";
			saveButton.Size = new Size(75, 23);
			saveButton.TabIndex = 1;
			saveButton.Text = "Save";
			saveButton.UseVisualStyleBackColor = true;
			saveButton.Click += saveButton_Click;
			// 
			// loadButton
			// 
			loadButton.Location = new Point(80, 10);
			loadButton.Name = "loadButton";
			loadButton.Size = new Size(75, 23);
			loadButton.TabIndex = 2;
			loadButton.Text = "Load";
			loadButton.UseVisualStyleBackColor = true;
			loadButton.Click += loadButton_Click;
			// 
			// colorButton
			// 
			colorButton.Location = new Point(161, 10);
			colorButton.Name = "colorButton";
			colorButton.Size = new Size(75, 23);
			colorButton.TabIndex = 3;
			colorButton.Text = "Color";
			colorButton.UseVisualStyleBackColor = true;
			colorButton.Click += colorButton_Click;
			// 
			// fontButton
			// 
			fontButton.Location = new Point(242, 10);
			fontButton.Name = "fontButton";
			fontButton.Size = new Size(75, 23);
			fontButton.TabIndex = 4;
			fontButton.Text = "Font";
			fontButton.UseVisualStyleBackColor = true;
			fontButton.Click += fontButton_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(688, 562);
			Controls.Add(fontButton);
			Controls.Add(colorButton);
			Controls.Add(loadButton);
			Controls.Add(saveButton);
			Controls.Add(textBox);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox;
		private Button saveButton;
		private Button loadButton;
		private Button colorButton;
		private Button fontButton;
	}
}
