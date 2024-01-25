using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class Student : Entity<int>
    {
        public string Name { get; set; }

        public string School { get; set; }

        public Student(int Id, string Name, string School) : base(Id)
        {
            this.Name = Name;
            this.School = School;
        }

        public override string ToString()
        {
            return "Id Student: " + Id + ", Name: " + Name + ", School: " + School;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (!(obj is Student))
                return false;
            Student student = (Student)obj;
                return Name.Equals(student.Name) & School.Equals(student.School);
        }
    }
}