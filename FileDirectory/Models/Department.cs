using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

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
			Employees.Add(newEmployee);
			using FileStream fileStream = new FileStream(path, FileMode.Create);
			using StreamWriter writer = new StreamWriter(fileStream);
			string newJson = JsonSerializer.Serialize(Employees);
			writer.WriteLine(newJson);
		}

		public Employee GetEmployeeById(int id)
		{
			using FileStream fileStream = new FileStream(path, FileMode.Open);
			using StreamReader reader = new StreamReader(fileStream);
			string newJson = reader.ReadToEnd();
			List<Employee>? newList = JsonSerializer.Deserialize<List<Employee>>(newJson);
			foreach (var item in newList)
			{
				if (item.Id == id)
				{
					return item;
				}
			}
			return null;
		}

		public void RemoveEmployee(int id)
		{
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
			{
				using (StreamReader reader = new StreamReader(fileStream))
				{
					string newJson = reader.ReadToEnd();
					List<Employee> newList = JsonSerializer.Deserialize<List<Employee>>(newJson);
					Employees = newList;
					foreach (var item in newList)
					{
						if(id == item.Id)
						{
							newList.Remove(item);
							break;
						}
					}
				}
				using (FileStream fileStream1 = new FileStream(path, FileMode.Create))
				{
					using (StreamWriter writer = new StreamWriter(fileStream1))
					{
						string newJson = JsonSerializer.Serialize(Employees);
						writer.WriteLine(newJson);
					}
				}
			}
		}
	}
}
