using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Graduate:Student
    {
        string subject;
        public string Subject
        { get { return subject; } set {  subject = value; } }
        public Graduate
            (
            string firstName, string lastName, int age,
            string speciality, string group, double rating, double attendance,
            string subject
            ) : base(firstName, lastName, age, speciality, group, rating, attendance)
        {
            Subject = subject;
            Console.WriteLine($"Graduate constr {this.GetHashCode()}");
        }
        public Graduate(Student student, string subject) : base(student)
        {
            this.Subject = subject;
            Console.WriteLine("Grad constr");
        }
        public override string ToString()
        {
            return base.ToString() + $" \"{Subject}\""; 
        }
        public override string ToStringFile()
        {
            return base.ToStringFile().Replace(';',',')+$"{subject};";
        }
    }
}
