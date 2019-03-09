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
                Console.Clear();
                dom.ChooseAccount();
                MainMenu();

                
                int mainMenuChoice = int.Parse(Console.ReadLine());

                decimal transactionAmount = 0;
                // the program only needs to know the amount being put in or taken out if 
                // a deposit or withdrawal action is being taken
                if (mainMenuChoice == 1 || mainMenuChoice == 2)
                {
                    Console.WriteLine("How much: ");
                    transactionAmount = decimal.Parse(Console.ReadLine());
                }

                switch (mainMenuChoice)
                {
                    case 1:
                        dom.MakeDeposit(transactionAmount);
                        break;
                    case 2:
                        dom.MakeWithdraw(transactionAmount);
                        break;
                    case 3:
                        dom.GetStatus();
                        break;
                    case 4:
                        deciding = false;
                        break;
                }

                Console.Write("Make another transaction? y/n \n>");
                string startOver = Console.ReadLine();

                if (startOver.ToLower().Equals("n"))
                    deciding = false;


            } while (deciding);
        }


        public static void MainMenu()
        {
            Console.WriteLine("\nWhat would you like to do?");
            Console.WriteLine(" 1 - Deposit \n" +
                              " 2 - Withdraw \n" +
                              " 3 - Check Balance \n" +
                              " 4 - Quit");
        }

        //TODO: keep track of all transactions


        //tryparse method needs to be added here
    }
}
