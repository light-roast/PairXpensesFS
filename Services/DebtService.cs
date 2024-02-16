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

		public void CreateDebt(Debt debt)
		{
			try
			{
				Debts.Add(debt);

			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error al crear la deuda: {ex.Message}");

			}
			
		}

		public void DeleteDebt(Debt debt)
		{	
			Debts.Remove(debt);
		}


		public List<Debt> GetAllDebtsByUserId(int userId)
		{
			List<Debt> debtsByUser = Debts.Where(d => d.User.Id == userId).ToList();
			return debtsByUser;
		}

		public Debt? GetDebtById(int id)
		{
			var debt = Debts.FirstOrDefault(d => d.Id == id);
			return debt;
		}

		public long GetTotalDebtValueByUserId(int userId)
		{
			
			long totalDebtValue = Debts.Where(d => d.User.Id == userId).Sum(d => d.Value);
			return totalDebtValue;
		}

		public Debt? UpdateDebtById(Debt debtToUpdate, Debt updateDebt)
		{
			
				debtToUpdate.Name = updateDebt.Name;
				debtToUpdate.Value = updateDebt.Value;
				debtToUpdate.UpdateDate = DateTime.Now;
			
				return debtToUpdate;
		}
	}
}
