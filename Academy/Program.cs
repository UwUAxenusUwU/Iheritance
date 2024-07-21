//#define INHERITANCE1
//#define INHERITANCE2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
#if INHERITANCE1
            Human human = new Human("Vercetti", "Tommy", 30);
            Console.WriteLine(human);

            Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_228", 95, 97);
            Console.WriteLine(student);

            Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
            Console.WriteLine(teacher);

            Graduate graduate = new Graduate("Schrader", "Hank", 40, "Crime", "OBN", 80, 70, "How to catch Heisenderg");
            Console.WriteLine(graduate); 
#endif

#if INHERITANCE2
            Human human = new Human("Vercetty", "Tommy", 30);
            Student student = new Student(human, "Theft", "Vice", 95, 98);
            Console.WriteLine(student);
            Graduate graduate = new Graduate(student, "How to make money");
            Console.WriteLine(graduate);
            Human human1 = new Human("Diaz", "Ricardo", 50);
            Teacher teacher = new Teacher(human1, "Weapons distribuion", 20);
            Console.WriteLine(teacher); 
#endif

            Human[] group = new Human[]
            {
                new Human("Musk", "Elon", 50),
                new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_228", 95, 97),
                new Teacher("White", "Walter", 50, "Chemistry", 25),
                new Graduate("Schrader", "Hank", 40, "Crime", "OBN", 80, 70, "How to catch Heisenderg"),
                new Student("Vercetty", "Tommy", 30, "Theft", "Vice", 95, 98),
                new Teacher("Diaz", "Ricardo", 50, "Weapons distribuion", 20)
            };
            Save(group);
            Print(group);
            Console.WriteLine("*------------------*");
            Console.WriteLine();
            Human[] group_copy = new Human[group.Length];
            Load(group_copy);
            Console.WriteLine();
            Print(group_copy);

            //string cmd = "group.txt";
            //System.Diagnostics.Process.Start("notepad",cmd);
            
        } 
        static void Save(Human[] group)
        {
            StreamWriter writer = new StreamWriter("group.txt");
            for (int i = 0; i < group.Length; i++)
            {
                writer.WriteLine(group[i]);
            }
            writer.Close();
            StreamWriter writer1 = new StreamWriter("group_to_read.txt");
            for (int i = 0; i < group.Length; i++)
            {
                writer1.WriteLine(group[i].ToStringFile());
            }
            writer1.Close();
        }
        static void Print(Human[] group)
        {
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine(group[i]);    
            }        
        }
        static void Load(Human[] group) //считывание пока не закончил, не успел. Но логику поймал: считываем в стринг, разбиваем на части, 
                                         //определяем тип, создаём класс, вносим в него инфу в зависимости от класса
        {
            StreamReader reader = new StreamReader("Group.txt");
            string line;
            int i = 0;
            while (!reader.EndOfStream) 
            {
                line = reader.ReadLine();
                string[] data = line.Split(' ');
                //data = data.Where(item => item != " ").ToArray();
                for (int m = 0; m < data.Length; m++)
                {
                    if (data[m] == " ")
                    {
                        data[m] = data[m + 1];
                    }
                }
                //for (int j = 0; j < data.Length; j++) { Console.WriteLine($"{data[j]}\t"); }
                //int size = data.Length;
                //Console.WriteLine(size);
                if (data[i] == "Academy.Student:") 
                {
                    Console.WriteLine("-------------------");
                    group[i] = new Student(data[1], data[2], Convert.ToInt32(data[3]), data[4], data[5], Convert.ToDouble(data[6]), Convert.ToDouble(data[7]));
                    Console.WriteLine(group[i]);
                }
                if (data[i] == "Academy.Teacher:")
                {
                    Console.WriteLine("-------------------------");
                    group[i] = new Teacher(data[1], data[2], Convert.ToInt32(data[3]), data[4], Convert.ToInt32(data[5]));
                    Console.WriteLine(group[i]);
                }    
                i++;
            }
            reader.Close();
        }

    }
}
