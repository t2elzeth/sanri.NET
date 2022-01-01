using System;
using Sanri.Core.Users;

namespace Sanri.Core;

public enum BalanceTransaction
{
    Cash = 1,
    Cashless = 2,
}

public enum BalanceAction
{
    Replenishment = 1,
    Withdrawal = 2
}

public class Balance
{
    public User User { get; set; }

    public DateTime Date { get; set; }

    public long JpySum { get; set; }

    public long UsaSum { get; set; }

    public decimal Rate { get; set; }

    public string Sender { get; set; }

    public string Comment { get; set; }

    public BalanceTransaction Transaction { get; set; }

    public BalanceAction Action { get; set; }
}