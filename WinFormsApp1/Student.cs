using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Student : Human
    {
        public string Institute { get; set; }
        public string Group { get; set; }
        public string Course { get; set; }
        public float Avgmark { get; }
        public float AvgMark { get; set; }
        public Student(int id, string fullname, DateTime birthday, string institute, string group, string course, float avgmark) : base(id, fullname, birthday)
        {
            Institute = institute;
            Group = group;
            Course = course;
            Avgmark = avgmark;
        }
        public Student() : base(0, "Пупкин Василий", new DateTime(2000, 1, 1))
        {
            Institute = "ITKN";
            Group = "BIVT-22-10";
            Course = "1";
            Avgmark = 0f;
        }
    }
}
