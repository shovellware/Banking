using System;

namespace Banking
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: ask for login info, PIN number

            // stand-in object with pre-defined account balance
            User dom = new User("shovelware")
            {
                Checking = 5000,
                Savings = 2000
            };

            // this loop is designed to make 1 transaction at a time, like an ATM
            // at the end, you are given the option to make another transaction, or quit
            bool deciding = true;
            do
            {
                dom.ChooseAccount();            

                // switch will execute MainMenu() and make a decision based on whatever that method returns
                // case 1 and 2 will prompt for a transaction amount
                switch (MainMenu())
                {
                    case 1:
                        dom.MakeDeposit(MakeTransaction());
                        break;
                    case 2:
                        dom.MakeWithdraw(MakeTransaction());
                        break;
                    case 3:
                        dom.GetStatus();
                        break;
                    case 0:
                        deciding = false;
                        break;
                }

                Console.Write("Make another transaction? y/n \n>");
                string startOver = Console.ReadLine();

                if (startOver.ToLower().Equals("n"))
                    deciding = false;


                Console.Clear();
            } while (deciding);
        }


        public static int MainMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine(" 1 - Deposit \n" +
                              " 2 - Withdraw \n" +
                              " 3 - Check Balance \n" +
                              " 0 - Quit");

            // i must cast as int here, because getNumbersFromString() returns decimal
            return (int)getNumbersFromString(Console.ReadLine());
        }

        public static decimal MakeTransaction()
        {
            Console.Write("Type in the amount: $");
            // getNumbersFromString() contains input validation using a TryParse
            // so i do not need to type it again here
            // i am still okay with returning a "0" if any weird input is given
            return getNumbersFromString(Console.ReadLine());
        }

        // i am using this wherever input is needed
        private static decimal getNumbersFromString(string input)
        {
            decimal success = 0;
            if (decimal.TryParse(input, out success))
                return success;
            else
                return 0;
            // 0 is used to return a "quit" condition as the default
        }
    }
}
