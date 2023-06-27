
using Api.Domain.LoanAggregate;


namespace Tests
{
    public class LoanAmortizationTests
    {
        [Fact]
        public void CalculateAmortizations_FrenchAmortization()
        {
            // Arrange
            var loanTerm = 12;
            var loanPrincipal = 1000;
            var loanAmortizationType = AmortizationType.French;

            // Act
            var loan = CreateBasicLoan(term: loanTerm, principal: loanPrincipal, type: loanAmortizationType);

            // Assert
            AssertAmortization(loan);
        }

        [Fact]
        public void CalculateAmortizations_AmericanAmortization()
        {
            // Arrange
            var loanTerm = 12;
            var loanPrincipal = 1000;
            var loanInterestRate = 5;
            var loanAmortizationType = AmortizationType.American;

            // Act
            var loan = CreateBasicLoan(term: loanTerm, principal: loanPrincipal, interestRate: loanInterestRate, type: loanAmortizationType);

            // Assert
            AssertAmortization(loan);
        }

        [Fact]
        public void CalculateAmortizations_GermanAmortization()
        {
            // Arrange
            var loanTerm = 12;
            var loanPrincipal = 1000;
            var loanInterestRate = 5;
            var loanAmortizationType = AmortizationType.German;

            // Act
            var loan = CreateBasicLoan(term: loanTerm, principal: loanPrincipal, interestRate: loanInterestRate, type: loanAmortizationType);

            // Assert
            AssertAmortization(loan);
        }


        private void AssertAmortization(Loan loan)
        {

            var amortizations = loan.Amortizations;
            float totalPayments = amortizations.Sum(a => a.Amount);
            float totalInterest = amortizations.Sum(a => a.Interest);
            float totalPrincipal = amortizations.Sum(a => a.Principal);
            float finalBalance = amortizations.Last().Balance;


            Assert.NotNull(amortizations);
            Assert.Equal(loan.Term, amortizations.Count());
            Assert.Equal(loan.Principal, Math.Round(totalPrincipal));
            Assert.Equal(Math.Round(loan.Interest), Math.Round(totalInterest));
            Assert.Equal(Math.Round(loan.Amount), Math.Round(totalPayments));


            Assert.Equal(0, Math.Round(finalBalance));


        }

        private Loan CreateBasicLoan(float principal = 10000, float interestRate = 5, int term = 12, AmortizationType type = AmortizationType.French)
        {
            return new Loan(principal, interestRate, term, type);
        }



    }
}
