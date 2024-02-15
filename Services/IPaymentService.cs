namespace PairXpensesFS.Services
{
	public interface IPaymentService
	{
		void CreatePayment(Payment payment);
		void DeletePayment(int id);
		List<Payment> GetAllPaymentsByUserId(int userId);
		Payment GetPaymentById(int id);

		Payment UpdatePaymentById(int id, Payment updatePayment);
		long GetTotalPaymentValueByUserId(int userId);
	}
}
