namespace Api.App.CalculateLoan;

using System.Threading;
using System.Threading.Tasks;
using Api.Domain.LoanAggregate;
using MediatR;

public class CalculateLoanHandler : IRequestHandler<CalculateLoanRequest, CalculateLoanResponse>
{
    public Task<CalculateLoanResponse> Handle(CalculateLoanRequest request, CancellationToken cancellationToken)
    {


        var loan = new Loan(request.Principal, request.InterestRate, request.Term, request.AmortizationType);




        return Task.FromResult(new CalculateLoanResponse(loan.Amortizations, loan.Amount, loan.Interest));
    }

}


