using System;
using System.Collections.Generic;
using GenericValidator;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student
            {
                Name = "Ale",
                Age = 1
            };
            Student student2 = new Student
            {
                Name = "Alex",
                Age = 1000
            };
            Teacher teacher = new Teacher
            {
                Name = "Karl",
                Age = 42
            };
            Teacher teacher2 = new Teacher
            {
                Name = "Karlos",
                Age = 60
            };
            Group group = new Group
            {
                Name="IA",
                StudentsCount = 2
            };
            var list = new List<Student>();
            list.Add(student);
            list.Add(student2);
            var dynamicList = new List<dynamic>();
            dynamicList.Add(student2);
            dynamicList.Add(teacher2);
            var exceptions = Validator.GetValidator(new ValidateProfile()).Validate(dynamicList);
            var exceptions2 = Validator.GetValidator(new ValidateProfile()).Validate(student, student2, teacher, teacher2);
            var exceptions3 = Validator.GetValidator(new ValidateProfile()).Validate(list);
            var exceptions4 = Validator.GetValidator(new ValidateProfile()).Validate(group);
            Console.WriteLine("First Validator");
            if (exceptions.Count == 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                foreach (var exceptionInfo in exceptions)
                {
                    Console.WriteLine(exceptionInfo.Key, exceptionInfo.Value.ToString());
                }
            }
            Console.WriteLine("\n\nSecond Validator\n");
            if (exceptions2.Count == 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                foreach (var exceptionInfo in exceptions2)
                {
                    Console.WriteLine(exceptionInfo.Key, exceptionInfo.Value.ToString());
                }
            }
            Console.WriteLine("\n\nThird Validator\n");
            if (exceptions3.Count == 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                foreach (var exceptionInfo in exceptions3)
                {
                    Console.WriteLine(exceptionInfo.Key, exceptionInfo.Value.ToString());
                }
            }
            Console.WriteLine("\n\nGroup validator\n");
            if (exceptions4.Count == 0)
            {
                Console.WriteLine("ok");
            }
            else
            {
                foreach (var exceptionInfo in exceptions4)
                {
                    Console.WriteLine(exceptionInfo.Key, exceptionInfo.Value.ToString());
                }
            }
        }
    }
}
