using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{
    public partial class MainMenu : Form
    {
        Database db = new();
        DataTable table = new();
        public MainMenu()
        {
            InitializeComponent();
            FormClosing += MainMenu_Close;
        }
        private void MainMenu_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("fullname", typeof(string));
            table.Columns.Add("date", typeof(DateTime));  
            table.Columns.Add("institute", typeof(string));
            table.Columns.Add("group", typeof(string));
            table.Columns.Add("course", typeof(string));
            table.Columns.Add("avg", typeof(float));
            db.load();
            refreshTable();
        }
        private void MainMenu_Close(object sender, EventArgs e)
        {
            db.save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            db.getStudents();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] information = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text };
            var birthdayDate = information[2].Split(' ').Select(x => Int32.Parse(x)).ToList();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            Student newStudent = new(id: Int32.Parse(information[0]), fullname: information[1], birthday: new DateTime(birthdayDate[0], birthdayDate[1], birthdayDate[2]),
                institute: information[3], group: information[4], course: information[5], avgmark: float.Parse(information[6]));
            db.addNewStudent(newStudent);
            refreshTable();
        }
        private void refreshTable()
        {
            table.Rows.Clear();

            foreach (Student student in db.getStudents())
            {

                table.Rows.Add(student.Id, student.FullName, student.BirthdayDate, student.Institute, student.Group, student.Course, student.Avgmark);

            }

            dataGridView1.DataSource = table;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table.Rows.Clear();
            foreach (Student student in db.getStudents().Where(x => $"{x.BirthdayDate.Year} {x.BirthdayDate.Month} {x.BirthdayDate.Day}" == textBox9.Text).ToList())
            {
                table.Rows.Add(student.Id, student.FullName, student.BirthdayDate, student.Institute, student.Group, student.Course, student.Avgmark);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table.Rows.Clear();
            foreach (Student student in db.getStudents().Where(x => x.FullName == textBox8.Text).ToList())
            {
                table.Rows.Add(student.Id, student.FullName, student.BirthdayDate, student.Institute, student.Group, student.Course, student.Avgmark);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.deleteStudent(Int32.Parse(textBox1.Text));
            refreshTable();
        }
    }
}
