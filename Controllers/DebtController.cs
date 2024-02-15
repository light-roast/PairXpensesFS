using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace PairXpensesFS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DebtController : ControllerBase
	{
	
		public List<Debt> Debts = new List<Debt>
		{
			new Debt {
				Id = 1,
				Name = "Compra juego",
				Value = 60000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 1, Name = "Daniel" }
			},
			new Debt {
				Id = 1,
				Name = "Compra calzones",
				Value = 600000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 2, Name = "Maritza" }
			}

		};
	}
}
