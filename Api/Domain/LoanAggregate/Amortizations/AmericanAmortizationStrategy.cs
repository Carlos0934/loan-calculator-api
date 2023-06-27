namespace Api.Domain.LoanAggregate;

public class AmericanAmortizationStrategy : IAmortizationStrategy
{


    public IEnumerable<Amortization> CalculateAmortizations(Loan loan)
    {
        {
            float totalAmount = loan.Amount;
            float monthlyInterestRate = loan.InterestRate / 100 / 12;

            float interestPayment = totalAmount * monthlyInterestRate;
            float principalPayment = 0;
            float remainingBalance = totalAmount;

            // Generate amortization for each period except the last one
            for (int paymentNumber = 1; paymentNumber < loan.Term; paymentNumber++)
            {
                yield return new Amortization(paymentNumber, interestPayment, interestPayment, principalPayment, remainingBalance);

                remainingBalance = totalAmount;
                interestPayment = remainingBalance * monthlyInterestRate;
            }

            // Generate amortization for the last period (includes principal payment)
            principalPayment = remainingBalance;
            yield return new Amortization(loan.Term, totalAmount, interestPayment, principalPayment, 0);
        }
    }
}
