using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PairXpensesFS.Services
{
	public class DebtService : IDebtService
	{
		private readonly List<Debt> Debts = new List<Debt>
		{
			new Debt
			{
				Id = 1,
				Name = "Compra juego",
				Value = 60000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 1, Name = "Daniel" }
			},
			new Debt
			{
				Id = 2,
				Name = "Compra calzones",
				Value = 600000,
				CreateDate = DateTime.Now,
				UpdateDate = DateTime.Now,
				User = new User { Id = 2, Name = "Maritza" }
			}
		};

		public Task<bool> CreateDebt(Debt debt)
		{
			try
			{
				Debts.Add(debt);

				return Task.FromResult(true);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al crear la deuda: {ex.Message}");
				return Task.FromResult(false);
			}
			
		}

		public Task<bool> DeleteDebt(int id)
		{
			
			var debtToDelete = Debts.FirstOrDefault(d => d.Id == id);
			if (debtToDelete != null)
			{
				
				Debts.Remove(debtToDelete);
				
				return Task.FromResult(true);
			}
			else
			{
				
				return Task.FromResult(false);
			}
		}


		public Task<List<Debt>> GetAllDebtsByUserId(int userId)
		{
			List<Debt> debtsByUser = Debts.Where(d => d.User.Id == userId).ToList();
			return Task.FromResult(debtsByUser);
		}

		public Task<Debt?> GetDebtById(int id)
		{
			var debt = Debts.FirstOrDefault(d => d.Id == id);
			return Task.FromResult(debt);
		}

		public Task<long> GetTotalDebtValueByUserId(int userId)
		{
			// Calcular el total de la deuda del usuario con el ID dado
			long totalDebtValue = Debts.Where(d => d.User.Id == userId).Sum(d => d.Value);
			return Task.FromResult(totalDebtValue);
		}

		public Task<Debt?> UpdateDebtById(int id, Debt updateDebt)
		{
			
			var debtToUpdate = Debts.FirstOrDefault(d => d.Id == id);
			if (debtToUpdate != null)
			{
				debtToUpdate.Name = updateDebt.Name;
				debtToUpdate.Value = updateDebt.Value;
				debtToUpdate.UpdateDate = DateTime.Now;
			}
			return Task.FromResult(debtToUpdate);
		}
	}
}
