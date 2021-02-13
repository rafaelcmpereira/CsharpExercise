using System;
using Course.Entiites.Enums;
using Course.Entiites;
using System.Globalization;

namespace Course
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter departament's name:");
            string depatName = Console.ReadLine();
            Console.WriteLine("Enter Worker data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/Midlevel/Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary:");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depatName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts for this worker:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY):");
                //  DateTime date = DateTime.Parse(Console.ReadLine());
                DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.Write("Value per hour:");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours):");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY):");
            string mmonthAndYear = Console.ReadLine();
            int month = int.Parse(mmonthAndYear.Substring(0, 2));
            int year = int.Parse(mmonthAndYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine($"Income for {mmonthAndYear}: " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
