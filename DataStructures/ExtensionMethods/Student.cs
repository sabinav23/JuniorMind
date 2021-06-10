using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
    class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Student (int id, string name, int age)
        {
            this.ID = id;
            this.Name = name;
            this.Age = age;
        }
    }
}
