using Ardalis.SmartEnum;

namespace Domain.Enums;

public sealed class FlightClassesEnum : SmartEnum<FlightClassesEnum>
{
    public static readonly FlightClassesEnum FirstClass = new(nameof(FirstClass), 1);
    public static readonly FlightClassesEnum Business = new(nameof(Business), 2);
    public static readonly FlightClassesEnum PremiumEconomy = new(nameof(PremiumEconomy), 3);
    public static readonly FlightClassesEnum Economy = new(nameof(Economy), 4);

    public FlightClassesEnum(string name, int value) : base(name, value)
    {
    }
}