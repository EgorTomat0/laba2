using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Database
    {
        private string FILE_PATH;
        List<Student> students = new List<Student>();
        public Database()
        {
            // C:\Users\egork\source\repos\laba2\WinFormsApp1\bin\Debug\net6.0-windows\Students.txt
            FILE_PATH = Path.GetFullPath("students.txt");
            
        }

        public List<Student> getStudents()
        {
            return new List<Student>(students);

        }
        public void addNewStudent(Student newStudent)
        {
            students.Add(newStudent);
        }
        public void deleteStudent(int studentId)
        {

            Student? studentToRemove = null;
            foreach (Student student in students)
            {
                if (student.Id == studentId)
                {
                    studentToRemove = student;
                }
            }
            if (studentToRemove != null)
            {
                students.Remove(studentToRemove);
            }
        }
        public List<Student> findByName(string fio)
        {
            return students.Where(st => st.FullName.IndexOf(fio) > -1).ToList();
        }
        public void load()
        {
            string[] allStudents;
            try
            {
                allStudents = File.ReadAllLines(FILE_PATH);
            } catch
            {
                File.Create(FILE_PATH).Close();
                allStudents = File.ReadAllLines(FILE_PATH);
            }
            foreach (string infoStudent in allStudents)
            {
                string[] information = infoStudent.Split(',');
                var birthdayDate = information[2].Split(' ').Select(x => Int32.Parse(x)).ToList();
                Student newStudent = new(id: Int32.Parse(information[0]), fullname: information[1], birthday: new DateTime(birthdayDate[0], birthdayDate[1], birthdayDate[2]),
                    institute: information[3], group: information[4], course: information[5], avgmark: float.Parse(information[6]));
                students.Add(newStudent);
            }

        }
        public void save()
        {
            File.WriteAllText(FILE_PATH, String.Empty);
            for (int i = 0; i < students.Count; i++)
            {
                File.AppendAllText(FILE_PATH, $"{students[i].Id},{students[i].FullName},{students[i].BirthdayDate.Year} {students[i].BirthdayDate.Month} {students[i].BirthdayDate.Day}," +
                    $"{students[i].Institute},{students[i].Group},{students[i].Course},{students[i].Avgmark}\n");
            }         
        }
    }
}
