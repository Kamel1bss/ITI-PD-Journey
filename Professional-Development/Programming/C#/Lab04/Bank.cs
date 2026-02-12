namespace Lab04;

interface IPrintable
{
    void PrintDetails();
}

interface ITransactable
{
    void Withdraw(double _amount);
    void deposit(double _amount);
}

internal abstract class Account : IPrintable, ITransactable
{
    int accountNum;
    double balance;
    string ownerName;

    protected Account(int _accountNum, double _balance, string _ownerName)
    {
        AccountNum = _accountNum;
        Balance = _balance;
        OwnerName = _ownerName;
    }
    public int AccountNum { get; }
    public double Balance { get; set; }
    public string OwnerName { get; set; }

    public abstract double CalculateInterest();

    public virtual void deposit(double _amount)
    {
        balance += _amount;
    }

    public void PrintDetails()
    {
        Console.WriteLine($"Account Num: {AccountNum}");
        Console.WriteLine($"Name: {ownerName}");
        Console.WriteLine($"Balance: {Balance}");
    }

    public virtual void Withdraw(double _amount)
    {
        balance -= _amount;
    }
}

class SavingAccount : Account
{
    int interstRate;
    double minimumBalance;

    public int InterstRate
    {
        set { interstRate = value; }
        get { return interstRate; }
    }

    public double MininumBalance
    {
        set { minimumBalance = value; }
        get { return minimumBalance; }

    }
    public SavingAccount(int _accountNum, double _balance, string _ownerName) : base(_accountNum, _balance, _ownerName)
    {
        
    }
    public override double CalculateInterest()
    {
        return interstRate * Balance;
    }

    public override void Withdraw(double _amount)
    {
        Balance -= _amount;
        if (Balance < minimumBalance)
        {
            Balance += _amount;
            Console.WriteLine("Error Min Withdraw!");
        }
        Console.WriteLine("Accepted");
    }
}

class CheckingAccount : Account
{
    int overDraftLimit;
    int freeTransactions;

    public int OverdraftLimit
    {
        set { overDraftLimit = value;}
        get { return overDraftLimit; }
    }

    public int FreeTransactions
    {
        set { freeTransactions = value;}
        get { return freeTransactions; }
    }
    public CheckingAccount(int _accountNum, double _balance, string _ownerName) : base(_accountNum, _balance, _ownerName)
    {
        
    }

    public override double CalculateInterest()
    {
        return 0;
    }

    public override void Withdraw(double _amount)
    {
        if (Balance - _amount > overDraftLimit)
            Console.WriteLine("Error over Limit!");
        else
        {
            Balance -= _amount;
            Console.WriteLine("Accepted");
        }
    }
}
