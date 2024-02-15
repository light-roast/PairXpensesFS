namespace PairXpensesFS.Services
{
	public interface IUserService
	{
		void CreateUser(User user);
		void DeleteUser(int id);
		List<User> GetAllUsers();
		User GetUserById(int id);

		User UpdateUserById(int id, User updateUser);
		
	}
}

