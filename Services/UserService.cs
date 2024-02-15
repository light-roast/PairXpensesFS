using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairXpensesFS.Services
{
	public class UserService : IUserService
	{
		public List<User> Users = new List<User>
		{
			new User {
				Id = 1,
				Name = "Daniel",
				Debts = new List<Debt> {},
				Payments =  new List<Payment> {}
			},
			new User {
				Id = 2,
				Name = "Maritza",
				Debts = new List<Debt> {},
				Payments =  new List<Payment> {}
			}
		};

		public Task<bool> CreateUser(User user)
		{
			try
			{
				Users.Add(user);

				return Task.FromResult(true);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al crear el usuario: {ex.Message}");
				return Task.FromResult(false);
			}
		}

		public Task<bool> DeleteUser(int id)
		{
			try
			{
				
				var userToRemove = Users.FirstOrDefault(u => u.Id == id);

				
				if (userToRemove != null)
				{
					
					Users.Remove(userToRemove);

				
					return Task.FromResult(true);
				}
				else
				{
				
					return Task.FromResult(false);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
				return Task.FromResult(false);
			}
		}

		public Task<List<User>> GetAllUsers()
		{
			return Task.FromResult(Users);
		}


		public Task<User?> UpdateUserById(int id, User updateUser)
		{
			var existingUser = Users.FirstOrDefault(u => u.Id == id);
			if (existingUser != null)
			{
				existingUser.Name = updateUser.Name;
	
				return Task.FromResult<User?>(existingUser);
			}
			else
			{
				
				return Task.FromResult<User?>(null);
			}
		}
	}
}
