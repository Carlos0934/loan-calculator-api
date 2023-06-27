
namespace Api.Domain.LoanAggregate;

public class Amortization : ValueObject
{
    public Amortization(int paymentNumber, float amount, float interest, float principal, float balance)
    {
        this.PaymentNumber = paymentNumber;
        this.Amount = amount;
        this.Interest = interest;
        this.Principal = principal;
        this.Balance = balance;

    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Amount;
        yield return Interest;
        yield return Principal;
        yield return Balance;
        yield return PaymentNumber;
    }

    public float Interest { get; }
    public float Principal { get; }
    public float Balance { get; }
    public float Amount { get; }
    public int PaymentNumber { get; }
}