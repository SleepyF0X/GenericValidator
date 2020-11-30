using System;
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
                Age=1000
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
            Validator.GetValidator(new ValidateProfile()).Validate(student, student2, teacher, teacher2);
        }
    }
}
