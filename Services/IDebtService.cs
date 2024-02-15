namespace PairXpensesFS.Services
{
	public interface IDebtService
	{
		void CreateDebt(Debt debt);
		void DeleteDebt(int id);
		List<Debt> GetAllDebtsByUserId(int userId);
		Debt GetDebtById(int id);

		Debt UpdateDebtById(int id, Debt updateDebt);
		long GetTotalDebtValueByUserId(int userId);
	}
}
