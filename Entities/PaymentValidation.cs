using System.ComponentModel.DataAnnotations;

namespace PairExpensesFS.Entities
{
	public class PaymentValidation
	{
		[Required(ErrorMessage = "Name is required.")]
		[StringLength(30, ErrorMessage = "Name cannot exceed 30 characters.")]
		public string? Name { get; set; }

		[Range(0, int.MaxValue, ErrorMessage = "Value must be non-negative.")]
		public int Value { get; set; } = 0;
	}
}
