namespace PairXpensesFS.Services
{
	public interface IDebtService
	{
		Task<bool> CreateDebt(Debt debt);
		Task<bool> DeleteDebt(int id);
		Task<List<Debt>> GetAllDebtsByUserId(int userId);
		Task<Debt?> GetDebtById(int id);

		Task<Debt?> UpdateDebtById(int id, Debt updateDebt);
		Task<long> GetTotalDebtValueByUserId(int userId);
	}
}
