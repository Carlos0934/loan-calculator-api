
namespace Api.Domain.LoanAggregate;

public interface IAmortizationStrategy
{
    public IEnumerable<Amortization> CalculateAmortizations(Loan loan);
}
