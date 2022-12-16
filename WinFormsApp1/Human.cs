using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Human
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthdayDate { get; set; }

        public Human(int id, string fullname, DateTime birthday)
        {
            Id = id;
            FullName = fullname;
            BirthdayDate = birthday;
        }
        public override string ToString()
        {
            return Id.ToString() + FullName;
        }
    }
}
