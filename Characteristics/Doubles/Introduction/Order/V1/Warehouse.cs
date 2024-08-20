namespace Characteristics.Doubles.Introduction.Order.V1;

using System.Collections.Generic;

public class Warehouse
{
    private Dictionary<string, int> products;

    public Warehouse()
    {
        products = new Dictionary<string, int>();
    }

    public void Add(string name, int amount)
    {
        products[name] = amount;
    }

    public virtual int GetInventory(string name)
    {
        return products.TryGetValue(name, out int inventory) ? inventory : 0;
    }

    public void Remove(string name, int amount)
    {
        if (products.ContainsKey(name))
        {
            products[name] -= amount;
        }
    }
}
