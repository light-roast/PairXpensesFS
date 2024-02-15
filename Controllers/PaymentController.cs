using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PairXpensesFS.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PaymentController : ControllerBase
	{
		public List<Payment> Payments = new List<Payment>
		{
			new Payment {
				Id = 1,
				Name = "Servicio de agua",
				Value = 110000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 1, Name = "Daniel" }
			},
			new Payment {
				Id = 1,
				Name = "Pizza",
				Value = 600000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 2, Name = "Maritza" }
			}

		};
	}
}
