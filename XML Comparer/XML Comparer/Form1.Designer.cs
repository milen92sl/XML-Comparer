
namespace XML_Comparer
{
	partial class Form1
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
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.oldPathTextBox = new System.Windows.Forms.TextBox();
			this.oldPathBtn = new System.Windows.Forms.Button();
			this.newPathBtn = new System.Windows.Forms.Button();
			this.newPathTextBox = new System.Windows.Forms.TextBox();
			this.compareBtn = new System.Windows.Forms.Button();
			this.labelText = new System.Windows.Forms.Label();
			this.xmlTextBoxDiff = new System.Windows.Forms.TextBox();
			this.exitBtn = new System.Windows.Forms.Button();
			this.saveBtn = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.Progress = new System.Windows.Forms.Label();
			this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
			this.oldPathLabel = new System.Windows.Forms.Label();
			this.newPathLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// folderBrowserDialog
			// 
			this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			this.folderBrowserDialog.SelectedPath = "c:\\test";
			this.folderBrowserDialog.ShowNewFolderButton = false;
			// 
			// oldPathTextBox
			// 
			this.oldPathTextBox.BackColor = System.Drawing.SystemColors.Window;
			this.oldPathTextBox.Location = new System.Drawing.Point(146, 35);
			this.oldPathTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.oldPathTextBox.Name = "oldPathTextBox";
			this.oldPathTextBox.Size = new System.Drawing.Size(463, 22);
			this.oldPathTextBox.TabIndex = 0;
			this.oldPathTextBox.Text = "c:\\test\\oldFolder";
			// 
			// oldPathBtn
			// 
			this.oldPathBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.oldPathBtn.Location = new System.Drawing.Point(291, 2);
			this.oldPathBtn.Margin = new System.Windows.Forms.Padding(4);
			this.oldPathBtn.Name = "oldPathBtn";
			this.oldPathBtn.Size = new System.Drawing.Size(156, 25);
			this.oldPathBtn.TabIndex = 1;
			this.oldPathBtn.Text = "Select Old Path";
			this.oldPathBtn.UseVisualStyleBackColor = false;
			this.oldPathBtn.Click += new System.EventHandler(this.btnOldPath_Click);
			// 
			// newPathBtn
			// 
			this.newPathBtn.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.newPathBtn.Location = new System.Drawing.Point(291, 92);
			this.newPathBtn.Margin = new System.Windows.Forms.Padding(4);
			this.newPathBtn.Name = "newPathBtn";
			this.newPathBtn.Size = new System.Drawing.Size(156, 25);
			this.newPathBtn.TabIndex = 3;
			this.newPathBtn.Text = "Select New Path";
			this.newPathBtn.UseVisualStyleBackColor = false;
			this.newPathBtn.Click += new System.EventHandler(this.btnNewPath_Click);
			// 
			// newPathTextBox
			// 
			this.newPathTextBox.Location = new System.Drawing.Point(146, 125);
			this.newPathTextBox.Margin = new System.Windows.Forms.Padding(4);
			this.newPathTextBox.Name = "newPathTextBox";
			this.newPathTextBox.Size = new System.Drawing.Size(463, 22);
			this.newPathTextBox.TabIndex = 2;
			this.newPathTextBox.Text = "c:\\test\\newFolder";
			// 
			// compareBtn
			// 
			this.compareBtn.BackColor = System.Drawing.Color.Moccasin;
			this.compareBtn.Location = new System.Drawing.Point(291, 155);
			this.compareBtn.Margin = new System.Windows.Forms.Padding(4);
			this.compareBtn.Name = "compareBtn";
			this.compareBtn.Size = new System.Drawing.Size(156, 57);
			this.compareBtn.TabIndex = 4;
			this.compareBtn.Text = "Compare";
			this.compareBtn.UseVisualStyleBackColor = false;
			this.compareBtn.Click += new System.EventHandler(this.btnCompare_Click);
			// 
			// labelText
			// 
			this.labelText.AutoSize = true;
			this.labelText.Location = new System.Drawing.Point(17, 250);
			this.labelText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.labelText.Name = "labelText";
			this.labelText.Size = new System.Drawing.Size(52, 17);
			this.labelText.TabIndex = 5;
			this.labelText.Text = "Result:";
			// 
			// xmlTextBoxDiff
			// 
			this.xmlTextBoxDiff.Location = new System.Drawing.Point(20, 271);
			this.xmlTextBoxDiff.Margin = new System.Windows.Forms.Padding(4);
			this.xmlTextBoxDiff.Multiline = true;
			this.xmlTextBoxDiff.Name = "xmlTextBoxDiff";
			this.xmlTextBoxDiff.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.xmlTextBoxDiff.Size = new System.Drawing.Size(735, 179);
			this.xmlTextBoxDiff.TabIndex = 6;
			// 
			// exitBtn
			// 
			this.exitBtn.BackColor = System.Drawing.Color.Red;
			this.exitBtn.Location = new System.Drawing.Point(643, 458);
			this.exitBtn.Margin = new System.Windows.Forms.Padding(4);
			this.exitBtn.Name = "exitBtn";
			this.exitBtn.Size = new System.Drawing.Size(112, 25);
			this.exitBtn.TabIndex = 7;
			this.exitBtn.Text = "Exit";
			this.exitBtn.UseVisualStyleBackColor = false;
			this.exitBtn.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// saveBtn
			// 
			this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
			this.saveBtn.Location = new System.Drawing.Point(13, 458);
			this.saveBtn.Margin = new System.Windows.Forms.Padding(4);
			this.saveBtn.Name = "saveBtn";
			this.saveBtn.Size = new System.Drawing.Size(112, 25);
			this.saveBtn.TabIndex = 8;
			this.saveBtn.Text = "Save XML";
			this.saveBtn.UseVisualStyleBackColor = false;
			this.saveBtn.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(195, 221);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(359, 23);
			this.progressBar1.TabIndex = 9;
			// 
			// Progress
			// 
			this.Progress.AutoSize = true;
			this.Progress.Font = new System.Drawing.Font("Bahnschrift", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Progress.Location = new System.Drawing.Point(105, 221);
			this.Progress.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.Progress.Name = "Progress";
			this.Progress.Size = new System.Drawing.Size(84, 21);
			this.Progress.TabIndex = 10;
			this.Progress.Text = "Progress:";
			// 
			// directorySearcher1
			// 
			this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
			this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
			this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
			// 
			// oldPathLabel
			// 
			this.oldPathLabel.AutoSize = true;
			this.oldPathLabel.Location = new System.Drawing.Point(72, 35);
			this.oldPathLabel.Name = "oldPathLabel";
			this.oldPathLabel.Size = new System.Drawing.Size(67, 17);
			this.oldPathLabel.TabIndex = 11;
			this.oldPathLabel.Text = "Old Path:";
			// 
			// newPathLabel
			// 
			this.newPathLabel.AutoSize = true;
			this.newPathLabel.Location = new System.Drawing.Point(67, 125);
			this.newPathLabel.Name = "newPathLabel";
			this.newPathLabel.Size = new System.Drawing.Size(72, 17);
			this.newPathLabel.TabIndex = 12;
			this.newPathLabel.Text = "New Path:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(768, 487);
			this.Controls.Add(this.newPathLabel);
			this.Controls.Add(this.oldPathLabel);
			this.Controls.Add(this.Progress);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.saveBtn);
			this.Controls.Add(this.exitBtn);
			this.Controls.Add(this.xmlTextBoxDiff);
			this.Controls.Add(this.labelText);
			this.Controls.Add(this.compareBtn);
			this.Controls.Add(this.newPathBtn);
			this.Controls.Add(this.newPathTextBox);
			this.Controls.Add(this.oldPathBtn);
			this.Controls.Add(this.oldPathTextBox);
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox oldPathTextBox;
		private System.Windows.Forms.Button oldPathBtn;
		private System.Windows.Forms.Button newPathBtn;
		private System.Windows.Forms.TextBox newPathTextBox;
		private System.Windows.Forms.Button compareBtn;
		private System.Windows.Forms.Label labelText;
		private System.Windows.Forms.TextBox xmlTextBoxDiff;
		private System.Windows.Forms.Button exitBtn;
		private System.Windows.Forms.Button saveBtn;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label Progress;
		private System.DirectoryServices.DirectorySearcher directorySearcher1;
		private System.Windows.Forms.Label oldPathLabel;
		private System.Windows.Forms.Label newPathLabel;
	}
}

