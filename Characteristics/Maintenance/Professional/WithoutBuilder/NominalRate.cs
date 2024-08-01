using System.Reflection;

namespace Characteristics.Maintenance.Professional.WithoutBuilder;

public class NominalRate
{
    public static NominalRate A = new(9, nameof(A));
    public static NominalRate B = new(7, nameof(B));
    public static NominalRate C = new(5, nameof(C));
    public static NominalRate D = new(3, nameof(D));
    public static NominalRate E = new(0, nameof(E));

    protected NominalRate(int id, string name)
    {
        (Id, Name) = (id, name);
    }

    public string Name { get; private set; }

    public int Id { get; }

    public static NominalRate? GetAll(double rate)
    {
        var rates = typeof(NominalRate).GetFields(BindingFlags.Public |
                                                  BindingFlags.Static |
                                                  BindingFlags.DeclaredOnly)
            .Select(f => f.GetValue(null))
            .Cast<NominalRate>();
        return rates.FirstOrDefault(f => rate >= f.Id);
    }
}