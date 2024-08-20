namespace Characteristics.Doubles.Introduction.Order.V1;

public class Order
{
    private string name;
    private int amount;
    private bool isFilled;

    public Order(string name, int amount)
    {
        this.name = name;
        this.amount = amount;
        this.isFilled = false;
    }

    public void Fill(Warehouse warehouse)
    {
        isFilled = warehouse.GetInventory(name) >= amount;
        if (isFilled)
        {
            warehouse.Remove(name, amount);
        }
    }

    public bool IsFilled()
    {
        return isFilled;
    }
}
