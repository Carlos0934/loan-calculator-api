


using Api.App.CalculateLoan;
using Api.Domain.LoanAggregate;

namespace Tests
{
    public class LoanCalculatorTests
    {


        [Fact]
        public async void BalanceShouldBePositive()
        {
            // Arrange
            var loanTerm = 12;
            var loanPrincipal = 1000;
            var loanInterestRate = 5;
            var loanAmortizationType = AmortizationType.French;

            var request = new CalculateLoanRequest()
            {
                AmortizationType = loanAmortizationType,
                InterestRate = loanInterestRate,
                Principal = loanPrincipal,
                Term = loanTerm
            };

            var handler = new CalculateLoanHandler();

            // Act  

            var response = await handler.Handle(request, new CancellationToken());
            var lastAmortization = response.Amortizations.LastOrDefault();


            // Assert
            Assert.NotNull(lastAmortization);
            Assert.Equal(0, Math.Round(lastAmortization.Balance));
        }


    }
}
