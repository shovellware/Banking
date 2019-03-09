using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class User
    {
        enum AccountType { checking = 1, savings }

        private string _username;
        private decimal _checking;
        private decimal _savings;
        private int _account;

        public User(string username)
        {
            _username = username;
            Console.WriteLine("Hello " + _username);
            Console.WriteLine("---------------------");
        }


        public decimal Checking
        {
            get { return _checking; }
            set { _checking = value; }
        }

        public decimal Savings
        {
            get { return _savings; }
            set { _savings = value; }
        }

        public void MakeDeposit(decimal depAmount)
        {
            switch (_account)
            {
                case (int)AccountType.checking:
                    _checking += depAmount;
                    break;
                case (int)AccountType.savings:
                    _savings += depAmount;
                    break;
            }
        }

        //TODO: can't take out more money than you have! add these conditions
        public void MakeWithdrawal(decimal withAmount)
        {
            switch(_account)
            {
                case (int)AccountType.checking:
                    _checking -= withAmount;
                    break;
                case (int)AccountType.savings:
                    _savings -= withAmount;
                    break;
            }
        }

        // I need to know which account the user is working with (checking or savings)
        // this method is called in the User() constructor, at the top of this class...
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
            Console.WriteLine("Checking Balance: {0:C2} \nSavings Balance: {1:C2}\n", _checking, _savings);
        }
    }
}
