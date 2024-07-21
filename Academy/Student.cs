using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Student:Human
    {
        static readonly int SPECIALITY_WIDTH = 25;
        static readonly int GROUP_WIDTH = 8;
        static readonly int RATING_WIDTH = 8;
        static readonly int ATTENDANCE_WIDTH = 8;
        private string speciality;
		private string group;
		private double rating;
		private double attendance;

		public string Speciality
		{
			get => speciality; 
			set { speciality = value; }
		}

		public string Group
		{
			get => group;
			set { group = value; }
		}

		public double Rating
		{
			get { return rating; }
			set { rating = value; }	
		}

		public double Attendance
		{
			get { return attendance; }
			set { attendance = value; }	
		}
		public Student()
		{
			Speciality = null;
			Group = null;
			Rating = 0;
			Attendance = 0;
		}
		public Student(string lastName, string firstName, int age,
			string speciality, string group, double ratring, double attendance) : base(lastName, firstName, age)
		{
			Speciality = speciality;
			Group = group;
			Rating = ratring;
			Attendance = attendance;
            Console.WriteLine($"Student constructor {this.GetHashCode()}");
        }
		public Student(Human human, string specialitty, string group, double ratring, double attendance):base(human)
		{
			Speciality = specialitty;
			Group = group;
			Rating = ratring;
			Attendance = attendance;
		}
		public Student(Student other):base(other)
		{
			Speciality = other.speciality;
			Group = other.Group;
			Rating = other.Rating;
			Attendance = other.Attendance;
		}

        public override string ToString()
        {
            return base.ToString() + $" {Speciality.PadRight(SPECIALITY_WIDTH)} {Group.PadRight(GROUP_WIDTH)} {Rating.ToString().PadRight(RATING_WIDTH)} {Attendance.ToString().PadRight(ATTENDANCE_WIDTH)}";
        }
		public override string ToStringFile()
		{
			return base.ToStringFile().Replace(';',',')+$"{speciality},{group},{rating},{attendance};";
		}
        public override void Init(string[] values)
        {
            base.Init(values);
			Speciality = values[4];
			Group = values[5];
			Rating = Convert.ToDouble(values[6]);
			Attendance = Convert.ToDouble(values[7]);
        }



    }
}
