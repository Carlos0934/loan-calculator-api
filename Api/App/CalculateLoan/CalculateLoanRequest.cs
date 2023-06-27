namespace Api.App.CalculateLoan;


using Api.Domain.LoanAggregate;
using MediatR;

public class CalculateLoanResponse
{
    public CalculateLoanResponse(IEnumerable<Amortization> amortizations, float amount, float interest)
    {
        Amortizations = amortizations;
        Amount = amount;
        Interest = interest;
    }
    public IEnumerable<Amortization> Amortizations { get; }
    public float Amount { get; }
    public float Interest { get; }

}

public class CalculateLoanRequest : IRequest<CalculateLoanResponse>
{
    public int Principal { get; set; }
    public int Term { get; set; }
    public float InterestRate { get; set; }
    public AmortizationType AmortizationType { get; set; }
}


