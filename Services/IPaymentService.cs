namespace PairXpensesFS.Services
{
	public interface IPaymentService
	{
		Task<bool> CreatePayment(Payment payment);
		Task<bool> DeletePayment(int id);
		Task<List<Payment>> GetAllPaymentsByUserId(int userId);
		Task<Payment?> GetPaymentById(int id);

		Task<Payment?> UpdatePaymentById(int id, Payment updatePayment);
		Task<long> GetTotalPaymentValueByUserId(int userId);
	}
}
