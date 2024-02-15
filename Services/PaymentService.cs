using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairXpensesFS.Services
{
	public class PaymentService : IPaymentService
	{
		private readonly List<Payment> Payments = new List<Payment>
		{
			new Payment
			{
				Id = 1,
				Name = "Servicio de agua",
				Value = 110000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 1, Name = "Daniel" }
			},
			new Payment
			{
				Id = 2,
				Name = "Pizza",
				Value = 600000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 2, Name = "Maritza" }
			}
		};

		public Task<bool> CreatePayment(Payment payment)
		{
			try
			{
				Payments.Add(payment);
				return Task.FromResult(true);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al crear el pago: {ex.Message}");
				return Task.FromResult(true);
			}
		}

		public Task<bool> DeletePayment(int id)
		{
			try
			{
				var paymentToDelete = Payments.FirstOrDefault(p => p.Id == id);
				if (paymentToDelete != null)
				{
					Payments.Remove(paymentToDelete);
					return Task.FromResult(true);
				}
				return Task.FromResult(false);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al eliminar el pago: {ex.Message}");
				return Task.FromResult(false);
			}
		}

		public Task<List<Payment>> GetAllPaymentsByUserId(int userId)
		{
			List<Payment> paymentsByUser = Payments.Where(p => p.User.Id == userId).ToList();
			return Task.FromResult(paymentsByUser);
		}

		public Task<Payment?> GetPaymentById(int id)
		{
			var payment = Payments.FirstOrDefault(p => p.Id == id);
			return Task.FromResult<Payment?>(payment);
		}

		public Task<long> GetTotalPaymentValueByUserId(int userId)
		{
			long totalPaymentValue = Payments.Where(p => p.User.Id == userId).Sum(p => p.Value);
			return Task.FromResult(totalPaymentValue);
		}

		public Task<Payment?> UpdatePaymentById(int id, Payment updatePayment)
		{
			var paymentToUpdate = Payments.FirstOrDefault(p => p.Id == id);
			if (paymentToUpdate != null)
			{
				paymentToUpdate.Name = updatePayment.Name;
				paymentToUpdate.Value = updatePayment.Value;
				paymentToUpdate.UpdateDate = DateTime.Now;
			}
			return Task.FromResult<Payment?>(paymentToUpdate);
		}
	}
}
