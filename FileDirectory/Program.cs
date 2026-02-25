using FileDirectory.Models;

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

			Console.WriteLine("1. Add employee\n2. Get employee by id\n3. Remove employee\n0. Quit");

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
						Console.WriteLine("Enter id: ");
						int id = int.Parse(Console.ReadLine());

                        try
                        {
                            Employee newEmployee = new Employee(name, salary, id);
                            department.AddEmployee(newEmployee);
                        }
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
						break;

                    case "2":
						Console.WriteLine("Enter book id that you are looking for: ");
                        int searchId = int.Parse(Console.ReadLine());

                        try
                        {
                            Employee searchedEmployee = department.GetEmployeeById(searchId);
                            searchedEmployee.ShowInfo();
                        }
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
						break;

                    case "3":
						Console.WriteLine("Enter the book id that you want to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        try 
                        {
						department.RemoveEmployee(deleteId);
                        }
                        catch (Exception e)
                        {
							Console.WriteLine(e.Message);
                        }
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
