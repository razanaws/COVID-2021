using Project.Models;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace Project
{
    public partial class form1 : Form
    {
        
        public form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (fname.Text == "" || lname.Text == "" || email.Text == "" || ID.Text == "" || code.Text == "")
                MessageBox.Show("You Should Fill All Fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    string sql = "insert into account (fname,lname,email,id,code,age) values('" + fname.Text + "','" + lname.Text + "','" + email.Text + "','" + ID.Text + "', '" + code.Text + "', '" + age.Text + "')";
                    SQLiteConnection Connection = new SQLiteConnection("Data Source=account.db;Vesrion=3;");
                    Connection.Open(); 
                    SQLiteCommand Command = new SQLiteCommand(sql, Connection);
                    Command.ExecuteNonQuery();
                    Connection.Close();
                    Account.SetData(fname.Text, lname.Text, email.Text, ID.Text, code.Text);
                    MessageBox.Show("Account Created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControl1.SelectedTab = tabControl1.TabPages[2];
                }
                catch
                {
                    MessageBox.Show("Insertion failed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                fname.Text = "";
                lname.Text = "";
                email.Text = "";
                ID.Text = "";
                code.Text = "";
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label16_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Account.GetId()))
            {
                Form3 newForm = new Form3();
                this.Hide();
                newForm.Show();
            }
            else
            {
                MessageBox.Show("Create an account first.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Account.GetId()))
            {
                Form4 newForm = new Form4();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Create an account first.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string id = login_nationalid.Text;
            string access = login_accesscode.Text;

            string sql = $"select * from account where id = '{id}' and code='{access}'";
            SQLiteConnection Connection = new SQLiteConnection("Data Source=account.db;Vesrion=3;");
            Connection.Open();
            SQLiteCommand Command = new SQLiteCommand(sql, Connection);
            SQLiteDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                Account.SetData(reader["fname"].ToString(), reader["lname"].ToString(), reader["email"].ToString(), reader["id"].ToString(), reader["age"].ToString());
                MessageBox.Show("Successful Login");
                tabControl1.SelectedTab = tabControl1.TabPages[2];
            }
            else
            {
                MessageBox.Show("Wrong ID or Access code");
            }
            reader.Close();
            Connection.Close();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                string msg = "we advise you to book for a COVID-19 Test by signing in then going to 'Services' tab";
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                string msg = "You should contact a medical staff before you book for any COVID-19 vaccination";
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                string msg = "you should not be leaving the house untill you book for a COVID-19 Test by signing in then going to 'Services' tab";
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Account.GetId()))
            {
                Form2 newForm = new Form2();
                newForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Create an account first.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
