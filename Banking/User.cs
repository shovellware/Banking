using System;

namespace Banking
{
    class User : IAtm
    {
        enum AccountType { checking = 1, savings }

        private string _username;
        private int _account;

        public User(string username)
        {
            _username = username;
            Console.WriteLine("Hello " + _username);
            Console.WriteLine("---------------------");
        }

        public decimal Checking { get; private set; }
        public decimal Savings { get; private set; }
        

        public void MakeDeposit(decimal depAmount)
        {
            switch (_account)
            {
                case (int)AccountType.checking:
                    Checking += depAmount;
                    break;
                case (int)AccountType.savings:
                    Savings += depAmount;
                    break;
            }
        }

        public void MakeWithdraw(decimal withAmount)
        {
            switch(_account)
            {
                // decide where to take money from based on AccountType
                // make sure there is enough money in the account before making withdraw
                case (int)AccountType.checking:
                    {
                        if (withAmount > Checking)
                            Console.WriteLine("You don't have that much money!");
                        else
                        Checking -= withAmount;
                    break;
                    }
                case (int)AccountType.savings:
                    {
                        if (withAmount > Savings)
                            Console.WriteLine("You don't have that much money!");
                        else
                            Savings -= withAmount;
                    break;
                    }
            }
        }

        // I need to know which account the user is working with (checking or savings)
        // Also testing my usage of enum and how necessary it would be in this case,
        // when AccountType is always associated with 1 and 2
        public void ChooseAccount()
        {
            Console.WriteLine("Choose an account:\n " +
                "1 - Checking\n " +
                "2 - Savings");

            int choice;
            //loop until a valid selection is found
            bool invalid = true;
            do
            {
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _account = (int)AccountType.checking;
                        invalid = false;
                        break;
                    case 2:
                        _account = (int)AccountType.savings;
                        invalid = false;
                        break;
                    default:
                        Console.WriteLine("Invalid selection");
                        break;
                }
            } while (invalid);
        }

        public void GetStatus()
        {
            Console.WriteLine("Checking Balance: {0:C2} \nSavings Balance: {1:C2}\n", Checking, Savings);
        }
    }
}
