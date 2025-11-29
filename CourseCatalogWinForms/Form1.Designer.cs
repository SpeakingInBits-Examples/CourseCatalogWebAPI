namespace CourseCatalogWinForms
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
            nudNumCredits = new NumericUpDown();
            dtpStartDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddCourse = new Button();
            txtTitle = new TextBox();
            lstCourses = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudNumCredits).BeginInit();
            SuspendLayout();
            // 
            // nudNumCredits
            // 
            nudNumCredits.Location = new Point(521, 114);
            nudNumCredits.Name = "nudNumCredits";
            nudNumCredits.Size = new Size(120, 23);
            nudNumCredits.TabIndex = 2;
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(521, 169);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(434, 71);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 4;
            label1.Text = "Title";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(387, 122);
            label2.Name = "label2";
            label2.Size = new Size(105, 15);
            label2.TabIndex = 5;
            label2.Text = "Number of Credits";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(434, 175);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 6;
            label3.Text = "Start Date";
            // 
            // btnAddCourse
            // 
            btnAddCourse.Location = new Point(483, 221);
            btnAddCourse.Name = "btnAddCourse";
            btnAddCourse.Size = new Size(149, 67);
            btnAddCourse.TabIndex = 7;
            btnAddCourse.Text = "Add Course";
            btnAddCourse.UseVisualStyleBackColor = true;
            btnAddCourse.Click += btnAddCourse_Click;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(521, 68);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(100, 23);
            txtTitle.TabIndex = 8;
            // 
            // lstCourses
            // 
            lstCourses.FormattingEnabled = true;
            lstCourses.Location = new Point(45, 43);
            lstCourses.Name = "lstCourses";
            lstCourses.Size = new Size(300, 139);
            lstCourses.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstCourses);
            Controls.Add(txtTitle);
            Controls.Add(btnAddCourse);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpStartDate);
            Controls.Add(nudNumCredits);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudNumCredits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstCourses;
        private TextBox textBox1;
        private NumericUpDown nudNumCredits;
        private DateTimePicker dtpStartDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAddCourse;
        private TextBox txtTitle;
    }
}
