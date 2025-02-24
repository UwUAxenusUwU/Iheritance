﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    internal class Human
    {
        static readonly int LAST_NAME_WIDTH = 15;
        static readonly int FIRST_NAME_WIDTH = 15;
        static readonly int AGE_WIDTH = 15;
        string lastName;
        string firstName;
        int age;
        public string LastName
        {
            get => lastName; set { lastName = value; }
        }
        public string FirstName
        {
            get => firstName; set { firstName = value;}
        }
        public int Age
        {
            get => age; set { age = value;}
        }
        public Human()
        {
            LastName = null;
            FirstName = null;
            Age = 0;
        }
        public Human( string lastName, string firstName, int age)
        {
            LastName = lastName;
            FirstName = firstName;
            Age = age;
            Console.WriteLine($"Human constructor initiated;{this.GetHashCode()}");
        }
        public Human(Human other)
        {
            this.LastName = other.LastName;
            this.FirstName = other.FirstName;
            this.Age = other.Age; Console.WriteLine("Copy Human Constr");
        }
        public override string ToString()
        {
            return $"{GetType().ToString().Split('.').Last()}: ".PadRight(12) + $"{LastName.PadRight(LAST_NAME_WIDTH)} {FirstName.PadRight(FIRST_NAME_WIDTH)} {Age.ToString().PadRight(AGE_WIDTH)}";
        }
        public virtual string ToStringFile()
        {
            return $"{GetType().ToString().Split('.').Last()}:" + $"{LastName},{FirstName},{Age.ToString()};";
        }
        public virtual void Init(string[] values)
        {
            LastName = values[1];
            FirstName = values[2];
            Age = Convert.ToInt32(values[3]);
        }
    }
}
