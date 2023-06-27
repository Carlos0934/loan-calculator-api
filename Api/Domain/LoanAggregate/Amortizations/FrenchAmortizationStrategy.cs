namespace Api.Domain.LoanAggregate;


public class FrenchAmortizationStrategy : IAmortizationStrategy
{
    public IEnumerable<Amortization> CalculateAmortizations(Loan loan)
    {
        var interestRate = loan.InterestRate / 100;

        float monthlyPayment = (loan.Principal * interestRate) / (1 - (float)Math.Pow(1 + interestRate, -loan.Term));

        float remainingPrincipal = loan.Principal;

        for (int paymentNumber = 1; paymentNumber <= loan.Term; paymentNumber++)
        {
            float interestPayment = remainingPrincipal * interestRate;
            float principalPayment = monthlyPayment - interestPayment;

            remainingPrincipal -= principalPayment;

            yield return new Amortization(paymentNumber, monthlyPayment, interestPayment, principalPayment, remainingPrincipal);


        }
    }


}
