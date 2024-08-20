namespace Characteristics.Doubles.Introduction.Order.V2;

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
        if (products.ContainsKey(name))
        {
            products[name] = amount;
        }
        else
        {
            products.Add(name,amount);
        }
    }

    public virtual int GetInventory(string name)
    {
        return products.TryGetValue(name, out int inventory) ? inventory : 0;
    }

    public virtual void Remove(string name, int amount)
    {
        if (products.ContainsKey(name))
        {
            products[name] -= amount;
        }
        else
        {
            products.Add(name,-amount);
        }
    }
}
