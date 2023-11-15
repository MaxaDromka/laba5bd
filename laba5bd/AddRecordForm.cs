using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba5bd
{
    public partial class AddRecordForm : Form
    {
        private readonly Form1 _parentForm;

        public AddRecordForm(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Assuming you have text boxes named txtBox1, txtBox2, txtBox3 for values

            // Get values from text boxes
            string value1 = textBox1.Text;
            string value2 = textBox2.Text;
            string value3 = textBox3.Text;
            string value4 = textBox4.Text;

            // Insert values into the database
            _parentForm.InsertRecordIntoDatabase(value1,value2, value3, value4);

            // Close this form
            this.Close();
        }
    }
}
