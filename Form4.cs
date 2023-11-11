using Project.Models;
using System;
using System.Data.SQLite;
using System.Windows.Forms;


namespace Project
{
    public partial class Form4 : Form
    {
       
        public Form4()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            string center = "";
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Make sure to select the center and pick a date.", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                center = listBox1.SelectedItem.ToString();
                DateTime dateTime = dateTimePicker1.Value;
                string DATE = dateTime.ToShortDateString();
                string test = "Center: " + center + ", Date: " + DATE + ". \n";
                MessageBox.Show(test, "Appointment", MessageBoxButtons.OK);
              
                string userid = Account.GetId();
            
                 TEST.SetData(center, DATE);
               
                form1 form1 = new form1();
                form1.Show();
                this.Hide();
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
        }
    }
}
