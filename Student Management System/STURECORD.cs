using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net;
using System.Reflection;

namespace Student_Management_System
{
    public partial class STURECORD : Form
    {
        string query;
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\vagha\\source\\repos\\Student Management System\\Student Management System\\sturecord.mdf\";Integrated Security=True");
        public STURECORD()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            query = "INSERT INTO data (NAME, BRANCH, SEM,CITY,GENDER,CHOICE)VALUES(@NAME, @BRANCH, @SEM, @CITY, @GENDER,@CHOICE)";
            SqlCommand cmd = new SqlCommand(query, con);
            //int id;
            //int.TryParse(textBox4.Text, out id);
            //cmd.Parameters.AddWithValue("@ID",id);
            cmd.Parameters.AddWithValue("@NAME", textBox1.Text);
            cmd.Parameters.AddWithValue("@BRANCH", textBox2.Text);
            int sem;
            int.TryParse(textBox3.Text, out sem);
            cmd.Parameters.AddWithValue("@SEM", sem);
            cmd.Parameters.AddWithValue("@CITY", comboBox1.SelectedItem.ToString());

            string gender, choice;
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }
            cmd.Parameters.AddWithValue("@Gender", gender);

            List<string> choices = new List<string>();
            if (checkBox1.Checked)
            {
                choices.Add("ASP.NET");
            }
            if (checkBox2.Checked)
            {
                choices.Add("C#");
            }
            choice = string.Join(", ", choices);
            cmd.Parameters.AddWithValue("@CHOICE", choice);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Registered Successfully!!! ");
        }

        private void STURECORD_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            string gender, choice;
            if (radioButton1.Checked)
            {
                gender = "Male";
            }
            else
            {
                gender = "Female";
            }

            List<string> choices = new List<string>();
            if (checkBox1.Checked)
            {
                choices.Add("ASP.NET");
            }
            if (checkBox2.Checked)
            {
                choices.Add("C#");
            }
            choice = string.Join(", ", choices);
            query = "update data set NAME='" + textBox1.Text + "',BRANCH ='" + textBox2.Text + "',SEM = '" + textBox3.Text + "',CITY='" + comboBox1.SelectedItem.ToString() + "',GENDER = '" + gender + "',CHOICE='" + choice + "' where ID='" + textBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Update Successfully!!! ");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            query = "Delete from data where ID='" + textBox4.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Dalete Successfully!!! ");
        }
    }
}