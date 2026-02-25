using System.Text.Json;


namespace FileDirectory.Models
{
	internal class Department
	{
		private static int ID;
		public int Id { get; }
		public string Name { get; set; }
		private static List<Employee> Employees = new List<Employee>();
		string path = "C:\\Users\\Admin\\OneDrive\\İş masası\\Programs\\FileDirectory\\FileDirectory\\Files\\Database.json";
		public Department()
		{
			ID++;
			Id = ID;
		}
		public void AddEmployee(Employee newEmployee)
		{
			using (FileStream fileStreamR = new FileStream(path, FileMode.Open))
			{
				using (StreamReader reader = new StreamReader(fileStreamR))
				{
					string json = reader.ReadToEnd();
					Employees = JsonSerializer.Deserialize<List<Employee>>(json);
				}
			}
			Employees.Add(newEmployee);
			string newJson = JsonSerializer.Serialize(Employees);

			using FileStream fileStream = new FileStream(path, FileMode.Create);
			using StreamWriter writer = new StreamWriter(fileStream);
			writer.Write(newJson);
		}

		public Employee GetEmployeeById(int id)
		{
			using FileStream fileStream = new FileStream(path, FileMode.Open);
			using StreamReader reader = new StreamReader(fileStream);
			string json = reader.ReadToEnd();
			Employees = JsonSerializer.Deserialize<List<Employee>>(json);
			return Employees.FirstOrDefault(e=> e.Id == id);
		}

		public void RemoveEmployee(int id)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				using (StreamReader reader = new StreamReader(fileStream))
				{
					string json = reader.ReadToEnd();
					Employees = JsonSerializer.Deserialize<List<Employee>>(json);
				}
			}
			Employees.Remove(Employees.FirstOrDefault(e => e.Id == id));
			string newJson = JsonSerializer.Serialize(Employees);
			using (FileStream fileStream1 = new FileStream(path, FileMode.Create))
			{
				using (StreamWriter writer = new StreamWriter(fileStream1))
				{						
					writer.Write(newJson);
				}
			}
			
		}


	}
}
