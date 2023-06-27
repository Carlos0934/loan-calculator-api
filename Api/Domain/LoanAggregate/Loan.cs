

namespace Api.Domain.LoanAggregate;

public enum AmortizationType
{
    French,
    American,
    German
}
public class Loan : AggregateRoot
{

    public Loan(float principal, float interestRate, int term, AmortizationType type)
    {
        Id = Guid.NewGuid();
        Principal = principal;
        Term = term;
        InterestRate = interestRate;
    }

    public Guid Id { get; private set; }
    public float Principal { get; private set; }
    public int Term { get; private set; }
    public float InterestRate { get; private set; }
    public AmortizationType AmortizationType { get; private set; }
    public IEnumerable<Amortization> Amortizations => CalculateAmortization(AmortizationType);
    public float Interest => Amortizations.Sum(a => a.Interest);
    public float Amount => Principal + Interest;
    private IEnumerable<Amortization> CalculateAmortization(AmortizationType amortizationType)
    {
        var amortizationStrategy = AmortizationStrategyFactory.Create(amortizationType);
        return amortizationStrategy.CalculateAmortizations(this);
    }

    public void ChangePrincipal(int amount) => Principal = amount;

    public void ChangeTerm(int term) => Term = term;

    public void ChangeInterestRate(int interestRate) => InterestRate = interestRate;

    public void ChangeAmortizationType(AmortizationType amortizationType) => AmortizationType = amortizationType;

}


