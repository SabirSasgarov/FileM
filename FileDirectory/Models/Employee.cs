
namespace FileDirectory.Models
{
	internal class Employee
	{
		private static int ID;
		public int Id { get; }
		public string Name { get; set; }
		public double Salary {  get; set; }
		public void ShowInfo()
		{
			Console.WriteLine($"Name - {Name}, Salary - {Salary}");
		}
		public Employee(string name, double salary)
		{
			Name = name;
			Salary = salary;
			ID++;
			Id = ID;
		}
	}
}
