using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Project.Models;

namespace Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        { 
            string id = Account.GetId();

            string sql = $"select * from account where id = '{id}'";
            SQLiteConnection Connection = new SQLiteConnection("Data Source=account.db;Vesrion=3;");
            Connection.Open();
            SQLiteCommand Command = new SQLiteCommand(sql, Connection);
            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                FNAME.Text = reader["fname"].ToString();
                LNAME.Text = reader["lname"].ToString();
                EMAIL.Text = reader["email"].ToString();
                AGE.Text = reader["age"].ToString();
                ID.Text = reader["id"].ToString();
            }

            reader.Close();
            Connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            string CENTER_FROM_VACCINE = VACCINE.GetCenter();
            string DATE_FROM_VACCINE = VACCINE.GetDate();
            center_vaccine.Text = CENTER_FROM_VACCINE;
            date_vaccine.Text = DATE_FROM_VACCINE;
            Cancel_Vac.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string CENTER_FROM_TEST = TEST.GetCenter();
            string DATE_FROM_TSET = TEST.GetDate();
            center_test.Text = CENTER_FROM_TEST;
            date_test.Text = DATE_FROM_TSET;
            Cancel_Tes.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        { 
            code.Visible = true;
            change.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(code.Text))
                MessageBox.Show("You Need To Write An Access Code To Change", "Access Code Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string id = Account.GetId();
                string accessCode = code.Text;
                try
                {
                    string sql = $"UPDATE account SET code = {accessCode} WHERE id = {id}";
                    SQLiteConnection Connection = new SQLiteConnection("Data Source=account.db;Vesrion=3;");
                    Connection.Open();
                    SQLiteCommand Command = new SQLiteCommand(sql, Connection);
                    Command.ExecuteNonQuery();
                    MessageBox.Show("Access Code Changed Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Changing Access Code Failed", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (VACCINE.GetCenter() == "no appointment")
                MessageBox.Show("No Appointment To Cancel","Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                VACCINE.SetData("Appointment Cancelled", "");
                center_vaccine.Text = VACCINE.GetCenter();
                date_vaccine.Text = VACCINE.GetDate();
            }
        }

        private void Cancel_Tes_Click(object sender, EventArgs e)
        {
            if (TEST.GetCenter() == "no appointment")
                MessageBox.Show("No Appointment To Cancel", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                TEST.SetData("Appointment Cancelled", "");
                center_test.Text = TEST.GetCenter();
                date_test.Text = TEST.GetDate();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            form1 form1 = new form1();
            form1.Show();
            this.Hide();
        }
    }
}
