namespace Api.Domain.LoanAggregate;

public class AmortizationStrategyFactory
{
    public static IAmortizationStrategy Create(AmortizationType type)
    {
        return type switch
        {
            AmortizationType.French => new FrenchAmortizationStrategy(),
            AmortizationType.American => new AmericanAmortizationStrategy(),
            AmortizationType.German => new GermanAmortizationStrategy(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}