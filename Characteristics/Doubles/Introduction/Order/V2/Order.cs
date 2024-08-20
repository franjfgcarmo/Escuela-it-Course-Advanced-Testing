namespace Characteristics.Doubles.Introduction.Order.V2;

public class Order
{
    private string name;
    private int amount;
    private bool isFilled;
    private MailService mailService;

    public Order(string name, int amount, MailService mailService)
    {
        this.name = name;
        this.amount = amount;
        this.mailService = mailService;
    }

    public void Fill(Warehouse warehouse)
    {
        isFilled = warehouse.GetInventory(name) >= amount;
        if (isFilled)
        {
            warehouse.Remove(name, amount);
        }
        else
        {
            mailService.Send(new Message());
        }
    }

    public bool IsFilled()
    {
        return isFilled;
    }
}
