using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }

        public Student (int id, string name, double age)
        {
            this.ID = id;
            this.Name = name;
            this.Age = age;
        }
    }
}
