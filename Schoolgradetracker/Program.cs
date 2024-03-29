﻿using System;
using System.Collections.Generic;

namespace School_grade_tracker_v2
{
    enum teacherorstudent
    {
        Teacher = 0,
        Student = 1,
    }
    enum School
    {
        WC = 0,
        UCW = 1,
        UWE = 2,
    }
    enum iSubject
    {
        Maths = 0,
        English = 1,
        Science = 2,
        ICT = 3,
        Art = 4,
        Languages = 5,

    }
    class Program
    {
        static List<Student> students = new List<Student>();
        static List<Teacher> teachers = new List<Teacher>();

        static void Main(string[] args)
        {
            {
                Console.WriteLine("Teacher or student (type the corresponding number): \n 0:Teacher \n 1:Student \n");

                var TeacherorStudent = int.Parse(Console.ReadLine());

                switch (TeacherorStudent)
                {
                    case 0:
                        NewTeacherFunction();
                        Console.WriteLine("Teacher count: {0}", Teacher.Count);
                        TeacherExports();
                        break;

                    case 1:
                        NewStudentFunction();
                        Console.WriteLine("Student count: {0}", Student.Count);
                        StudentExports();
                        break;
                }
            }
        }

        static void NewTeacherFunction()
        {
            var adding = true;

            while (adding)
            {
                try
                {
                    var newTeacher = new Teacher();


                    newTeacher.Name = Util.Console.Ask("Teacher Name: ");

                    newTeacher.Subject = (iSubject)Util.Console.AskInt("Teacher Subject (type the corresponding number): \n 0: Maths \n 1: English \n 2: Science \n 3: ICT \n 4: Art \n 5: Languages \n ");

                    newTeacher.School = (School)Util.Console.AskInt("Teacher School (type the corresponding number): \n 0: WC \n 1: UCW \n 2: UWE \n)");

                    newTeacher.Birthday = Util.Console.Ask("Teacher Birthday: ");

                    newTeacher.Address = Util.Console.Ask("Teacher Address: ");

                    newTeacher.Phone = Util.Console.AskLong("Teacher PhoneNumber : ");

                    teachers.Add(newTeacher);


                    Console.WriteLine("Add Another? y/n");

                    if (Console.ReadLine() != "y")
                        adding = false;
                }

                catch (FormatException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error adding Teacher, please try again");
                }


            }
        }

        static void NewStudentFunction()
        {
            var adding = true;

            while (adding)
            {
                try
                {
                    var newStudent = new Student();


                    newStudent.Name = Util.Console.Ask("Student Name: ");

                    newStudent.Grade = Util.Console.AskInt("Student Grade: ");

                    newStudent.School = (School)Util.Console.AskInt("Student School (type the corresponding number): \n 0: WC \n 1: UCW \n 2: UWE \n)");

                    newStudent.Birthday = Util.Console.Ask("Student Birthday: ");

                    newStudent.Address = Util.Console.Ask("Student Address: ");

                    newStudent.Phone = Util.Console.AskLong("Student PhoneNumber : ");

                    students.Add(newStudent);


                    Console.WriteLine("Add Another? y/n");

                    if (Console.ReadLine() != "y")
                        adding = false;
                }

                catch (FormatException msg)
                {
                    Console.WriteLine(msg.Message);
                }
                catch (Exception)
                {

                    Console.WriteLine("Error adding student, please try again");
                }


            }


        }
        static void StudentExports()
        {
            Console.WriteLine(students.Count);
            foreach (var student in students)
            {
                switch (student.School)
                {
                    case School.WC:
                        Console.WriteLine("Exporting to Weston College");
                        break;

                    case School.UCW:
                        Console.WriteLine("Exporting to UCW");
                        break;

                    case School.UWE:
                        Console.WriteLine("Exporting to UWE");
                        break;
                }
            }


        }
        static void TeacherExports()
        {
            Console.WriteLine("Number of teachers to be exported: {0}",teachers.Count);
            foreach (var teacher in teachers)
            {
                switch (teacher.School)
                {
                    case School.WC:
                        Console.WriteLine("Exporting to Weston College");
                        break;

                    case School.UCW:
                        Console.WriteLine("Exporting to UCW");
                        break;

                    case School.UWE:
                        Console.WriteLine("Exporting to UWE");
                        break;
                }

                switch (teacher.Subject)
                {
                    case iSubject.Maths:
                        Console.WriteLine("Registered as maths teacher");
                        break;

                    case iSubject.English:
                        Console.WriteLine("Registered as English teacher");
                        break;

                    case iSubject.ICT:
                        Console.WriteLine("Registered as ICT teacher");
                        break;

                    case iSubject.Art:
                        Console.WriteLine("Registered as Art teacher");
                        break;

                    case iSubject.Languages:
                        Console.WriteLine("Registered as Languages teacher");
                        break;
                }
            }

        }
        class Member
        {
            public string Name;
            public string Address;
            public School School;
            public string Birthday;
            protected long phone;

            public long Phone
            {
                set { phone = value; }
            }
        }

        class Student : Member
        {
            public static int Count = 0;
            public int Grade;



            public Student()
            {
                Count++;
            }

            public Student(string name, int grade, School school, string birthday, string address, int phone)
            {
                Name = name;
                Grade = grade;
                Birthday = birthday;
                Address = address;
                Phone = phone;
                Count++;
            }

        }

        class Teacher : Member
        {

            public static int Count = 0;
            public iSubject Subject;



            public Teacher()
            {
                Count++;
            }

            public Teacher(string name, iSubject subject, School school, string birthday, string address, int phone)
            {
                Name = name;
                Subject = subject;
                Birthday = birthday;
                Address = address;
                Phone = phone;
                Count++;
            }

        }
    }

}
