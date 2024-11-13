using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG272_GITHUB.Models
{
    public class Student
    {
        public string StudentID { get; set; } // Changed to string
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        public Student() { }

        public Student(string studentID, string name, int age, string course)
        {
            StudentID = studentID;
            Name = name;
            Age = age;
            Course = course;
        }

        public override string ToString()
        {
            return $"{StudentID} - {Name} - {Age} - {Course}";
        }
    }
}
