using Project.Models;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class Form3 : Form
    {
        SQLiteConnection DbConnection;
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime dateTime = dateTimePicker1.Value;
            string DATE = dateTime.ToShortDateString();
            string Center = "";
            if (radioButton1.Checked)
                Center = radioButton1.Text;
            if (radioButton2.Checked)
                Center = radioButton2.Text;
            if (radioButton3.Checked)
                Center = radioButton3.Text;
            if (radioButton4.Checked)
                Center = radioButton4.Text;
            if (radioButton5.Checked)
                Center = radioButton5.Text;
            string msg = "Center: " + Center + ", Date: " + DATE + ". \n";
            VACCINE.SetData(Center, DATE);

            string userid = Account.GetId();
            MessageBox.Show(msg, "Appointment", MessageBoxButtons.OK);
            form1 form1 = new form1();
            form1.Show();
            this.Hide();
        }


        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
