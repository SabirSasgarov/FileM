using FileDirectory.Models;
using System.Xml.Linq;

namespace FileDirectory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Admin\\OneDrive\\İş masası\\Programs\\FileDirectory\\FileDirectory\\Files\\Database.json";
            if(!File.Exists(filePath))
                File.Create(filePath);

            Department department = new Department();



            while (true)
            {
				Console.WriteLine("Enter new operation: ");
				string operation = Console.ReadLine();
				switch (operation)
                {
                    case "1":
						Console.WriteLine("Enter employee name: ");
                        string name = Console.ReadLine();
						Console.WriteLine("Enter emplyee salary: ");
                        double salary = double.Parse(Console.ReadLine());
                        Employee newEmployee = new Employee(name, salary);
                        department.AddEmployee(newEmployee);
                        break;

                    case "2":
						Console.WriteLine("Enter book id that you are looking for: ");
                        int id = int.Parse(Console.ReadLine());
                        Employee searchedEmployee = department.GetEmployeeById(id);
                        searchedEmployee.ShowInfo();
                        break;

                    case "3":
						Console.WriteLine("Enter the book id that you want to delete: ");
                        department.RemoveEmployee(int.Parse(Console.ReadLine()));
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Wrong operation.");
                        break;

                }
            }
        }
    }
}
