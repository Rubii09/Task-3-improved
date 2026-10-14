using System;
using System.Xml.Linq;
namespace medicalCenter
{
    class Person
    {
        public string Name;
        public int Age;
        public string ContactNumber;

        public Person(string Name, int Age, string ContactNumber)
        {
            this.Name = Name;
            this.Age = Age;
            this.ContactNumber = ContactNumber;
        }
        public void DisplayBasicInfo()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Contact: " + ContactNumber);
        }
        public bool isValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Age > 0;
        }
    }

    class Student : Person
    {
        public int StudentId;
        public string Program;

        public Student(string name, int age, string contactNumber, int StudentId, string Program) : base(name, age, contactNumber)
        {

            this.StudentId = StudentId;
            this.Program = Program;
        }
        public void DisplayStudentInfo()
        {
            DisplayBasicInfo();
            Console.WriteLine("Student ID: " + StudentId);
            Console.WriteLine("Program: " + Program);
        }
    }
    class Faculty : Person
    {
        public int EmployeeId;
        public string Department;
        public double Salary;

        public Faculty(string name, int age, string contactNumber, int employeeId, string department, double salary) : base(name, age, contactNumber)
        {
            Name = name; Age = age; ContactNumber = contactNumber;
            EmployeeId = employeeId; Department = department; Salary = salary;
        }
        public void DisplayFacultyInfo()
        {
            DisplayBasicInfo();
            Console.WriteLine("Employee ID: " + EmployeeId);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Salary: " + Salary);
        }
    }
    class Doctor : Person
    {
        public int EmployeeId;
        public string Specialization;
        public double Salary;

        public Doctor(string name, int age, string contactNumber, int employeeId, string specialization, double salary) : base(name, age, contactNumber)
        {
            Name = name; Age = age; ContactNumber = contactNumber;
            EmployeeId = employeeId; Specialization = specialization; Salary = salary;
        }
        public void DisplayDoctorInfo()
        {
            DisplayBasicInfo();
            Console.WriteLine("Employee ID: " + EmployeeId);
            Console.WriteLine("Specialization: " + Specialization);
            Console.WriteLine("Salary: " + Salary);
        }
    }
    class Program
    {
        static void PrintRoleSummary(object person, string role)
        {
            if (role == "Student")
            {
                Student s = (Student)person;
                Console.WriteLine("Student " + s.Name + " is enrolled in " + s.Program);
            }
            else if (role == "Faculty")
            {
                Faculty f = (Faculty)person;
                Console.WriteLine("Faculty " + f.Name + " teaches in " + f.Department);
            }
            else if (role == "Doctor")
            {
                Doctor d = (Doctor)person;
                Console.WriteLine("Doctor " + d.Name + " specializes in " + d.Specialization);
            }
            else
            {
                Console.WriteLine("Unknown role");
            }
        }

        static double CalculateMonthlyPay(object person, string role)
        {
            if (role == "Faculty")
                return ((Faculty)person).Salary;
            else if (role == "Doctor")
                return ((Doctor)person).Salary + 20000;   // on-call allowance
            else
                return 0;
        }

        static void Main()
        {
            List<object> people = new List<object>();
            List<string> roles = new List<string>();

            people.Add(new Student("Ali", 20, "0300-1111111", 101, "BSCS"));
            roles.Add("Student");
            people.Add(new Faculty("Dr. Sana", 38, "0300-2222222", 501, "Computer Science", 150000));
            roles.Add("Faculty");
            people.Add(new Doctor("Dr. Imran", 45, "0300-3333333", 701, "Cardiology", 250000));
            roles.Add("Doctor");

            for (int i = 0; i < people.Count; i++)
            {
                PrintRoleSummary(people[i], roles[i]);
                Console.WriteLine("Monthly pay: " + CalculateMonthlyPay(people[i], roles[i]));
            }
        }
    }

}

