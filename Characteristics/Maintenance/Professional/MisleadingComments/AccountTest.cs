using FluentAssertions;

namespace Characteristics.Maintenance.Professional.MisleadingComments;

public class AccountTest
{
    [Fact]
    public void PastDueDateDebtFlagsAccountNotInGoodStanding()
    {
        // create a basic account
        Customer customer = new Customer();
        DeliquencyPlan deliquencyPlan = DeliquencyPlan.Monthly;
        Account account = new CorporateAccount(customer, deliquencyPlan);

        // register a debt that has a due date in the future
        Money amount = new Money("EUR", 1000);
        account.Add(new Liability(customer, amount, Time.FromNow(1, Time.DAYS)));

        // account should still be in good standing
        account.InGoodStanding().Should().BeTrue();

        // fast-forward past the due date
        Time.MoveForward(1, Time.DAYS);

        // account shouldn't be in good standing anymore
        account.InGoodStanding().Should().BeFalse();
    }
}