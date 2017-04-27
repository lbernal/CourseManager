namespace WinFormCourseManager
{
    partial class frmCourseManagerTester
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
            this.txtCourseProgramInput = new System.Windows.Forms.TextBox();
            this.lblCourseProgramInput = new System.Windows.Forms.Label();
            this.txtCourseProgramOutput = new System.Windows.Forms.TextBox();
            this.lblCourseProgramOutput = new System.Windows.Forms.Label();
            this.btnCreateCourseProgram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCourseProgramInput
            // 
            this.txtCourseProgramInput.Location = new System.Drawing.Point(139, 12);
            this.txtCourseProgramInput.Multiline = true;
            this.txtCourseProgramInput.Name = "txtCourseProgramInput";
            this.txtCourseProgramInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCourseProgramInput.Size = new System.Drawing.Size(467, 156);
            this.txtCourseProgramInput.TabIndex = 0;
            // 
            // lblCourseProgramInput
            // 
            this.lblCourseProgramInput.AutoSize = true;
            this.lblCourseProgramInput.Location = new System.Drawing.Point(13, 13);
            this.lblCourseProgramInput.Name = "lblCourseProgramInput";
            this.lblCourseProgramInput.Size = new System.Drawing.Size(112, 13);
            this.lblCourseProgramInput.TabIndex = 1;
            this.lblCourseProgramInput.Text = "Course Program Input:";
            // 
            // txtCourseProgramOutput
            // 
            this.txtCourseProgramOutput.Location = new System.Drawing.Point(139, 208);
            this.txtCourseProgramOutput.Multiline = true;
            this.txtCourseProgramOutput.Name = "txtCourseProgramOutput";
            this.txtCourseProgramOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCourseProgramOutput.Size = new System.Drawing.Size(467, 156);
            this.txtCourseProgramOutput.TabIndex = 2;
            // 
            // lblCourseProgramOutput
            // 
            this.lblCourseProgramOutput.AutoSize = true;
            this.lblCourseProgramOutput.Location = new System.Drawing.Point(12, 211);
            this.lblCourseProgramOutput.Name = "lblCourseProgramOutput";
            this.lblCourseProgramOutput.Size = new System.Drawing.Size(120, 13);
            this.lblCourseProgramOutput.TabIndex = 3;
            this.lblCourseProgramOutput.Text = "Course Program Output:";
            // 
            // btnCreateCourseProgram
            // 
            this.btnCreateCourseProgram.Location = new System.Drawing.Point(470, 175);
            this.btnCreateCourseProgram.Name = "btnCreateCourseProgram";
            this.btnCreateCourseProgram.Size = new System.Drawing.Size(135, 23);
            this.btnCreateCourseProgram.TabIndex = 4;
            this.btnCreateCourseProgram.Text = "Create Course Program";
            this.btnCreateCourseProgram.UseVisualStyleBackColor = true;
            this.btnCreateCourseProgram.Click += new System.EventHandler(this.btnCreateCourseProgram_Click);
            // 
            // frmCourseManagerTester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 374);
            this.Controls.Add(this.btnCreateCourseProgram);
            this.Controls.Add(this.lblCourseProgramOutput);
            this.Controls.Add(this.txtCourseProgramOutput);
            this.Controls.Add(this.lblCourseProgramInput);
            this.Controls.Add(this.txtCourseProgramInput);
            this.Name = "frmCourseManagerTester";
            this.Text = "Course Manager Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCourseProgramInput;
        private System.Windows.Forms.Label lblCourseProgramInput;
        private System.Windows.Forms.TextBox txtCourseProgramOutput;
        private System.Windows.Forms.Label lblCourseProgramOutput;
        private System.Windows.Forms.Button btnCreateCourseProgram;
    }
}

