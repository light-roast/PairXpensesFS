namespace PairXpensesFS.Services
{
	public interface IUserService
	{
		Task<bool> CreateUser(User user);
		Task<bool> DeleteUser(int id);
		Task<List<User>> GetAllUsers();

		Task<User?> UpdateUserById(int id, User updateUser);
		
	}
}

