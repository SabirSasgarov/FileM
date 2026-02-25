
namespace FileDirectory.Models
{
	internal class Employee
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Salary {  get; set; }
		public void ShowInfo()
		{
			Console.WriteLine($"ID - {Id}, Name - {Name}, Salary - {Salary}");
		}
		public Employee(string name, double salary, int id)
		{
			Name = name;
			Salary = salary;
			Id = id;
		}
	}
}
