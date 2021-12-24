using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Student
{
    class Program
    {
        static string fileName = @"student.dat";
        [Obsolete]
        static void Main(string[] args)
        {
            
            bool cancel = false;

            GenericClass<Student> school = new GenericClass<Student>();

            while(cancel != true)
            {   
                Console.Clear();
                PrintMenu();

                uint selectMenu = ReadUInteger("Please select menu: ");
                switch (selectMenu)
                {

                    case 1:
                        {
                            Console.Clear();
                            Student student = new Student();
                            student.Name = Readstring("Studet's Name: ");
                            student.Surname = Readstring("Studet's Surname: ");
                            student.Age = ReadUInteger("Studet's Age: ");
                            student.School = Readstring("Studet's School: ");
                            student.Class = Readstring("Studet's Class: ");
                            school.Add(student);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("List of students");
                            for(int i = 0; i<school.Length; i++)
                            {
                                Student student = school[i];
                                Console.WriteLine($"{i}.{student}");
                            }
                            uint index = ReadUInteger("Please enter number of raw to remave");
                            school.RemoveAt(index);

                        goto case 3; 
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("List of Students");
                            Console.WriteLine("Name \t Surname \t Age: \t School \t Class \t");
                            foreach (var item in school)
                            {
                                Console.WriteLine(item + "\t");
                            }
                            Console.WriteLine("To see Menu press anykey");
                            Console.ReadKey();

                            break;
                        }
                    case 4:
                        {
                            SaveToFile(school,fileName);
                            Console.WriteLine("Data saved. Please any key to continue");
                            Console.ReadKey();
                            break;
                        }
                    case 5:
                        {
                           school= LoadFromFile(fileName);
                            Console.WriteLine("Loading success. Please any key to continue");
                            Console.ReadKey();
                        break;
                        }
                    case 6:
                        {
                            cancel = true;
                        break;
                        }
                }
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("1: Add new Student");
            Console.WriteLine("2: Remove Student from the List");
            Console.WriteLine("3: List of Students");
            Console.WriteLine("4: Save new List");
            Console.WriteLine("5: Load");
            Console.WriteLine("6: Exit");
        }

        static uint ReadUInteger (string caption)
        {
        step1:
            Console.WriteLine(caption);

            if (uint.TryParse(Console.ReadLine(), out uint value))
            {
                return value;
            }

            goto step1;
        }
        static string Readstring (string caption)
        {
        
            Console.WriteLine(caption);
            return Console.ReadLine();
        }

        [Obsolete]
        static void SaveToFile (GenericClass<Student> school, string filepath)
        {   
            using (FileStream fs = new FileStream(filepath,FileMode.OpenOrCreate,FileAccess.ReadWrite))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, school);
            }
        } 
        [Obsolete]
        static GenericClass<Student> LoadFromFile (string filepath)
        {
            try
            {
                using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
                {
                    BinaryFormatter bf = new BinaryFormatter();

                    return (GenericClass<Student>)bf.Deserialize(fs);
                }
            }
            catch (Exception)
            {

                return new GenericClass<Student>();
            }

        }

    }
}
