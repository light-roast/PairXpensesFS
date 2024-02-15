using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PairXpensesFS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		public List<User> Users = new List<User>
		{
			new User {
				Id = 1,
				Name = "Daniel",
				Total = 0,
				TotalDebt = 0,
				Debts = new List<Debt> {},
				Payments =	new List<Payment> {}
			},
			new User {
				Id = 2,
				Name = "Maritza",
				Total = 0,
				TotalDebt = 0,
				Debts = new List<Debt> {},
				Payments =  new List<Payment> {}
			}
		};
	}
}
