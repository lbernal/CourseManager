using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCourseManager
{
    public partial class frmCourseManagerTester : Form
    {
        public frmCourseManagerTester()
        {
            InitializeComponent();
        }

        private void btnCreateCourseProgram_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCourseProgramInput.Text))
                {
                    var courses = txtCourseProgramInput.Text.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                    var program = new CourseProgram.Program(courses);
                    txtCourseProgramOutput.Text = program.ToString();
                }
            }
            catch (Exception exc)
            {
                txtCourseProgramOutput.Text = exc.ToString();
            }
        }
    }
}
