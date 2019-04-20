using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    public interface IAtm
    {
        void ChooseAccount();

        void MakeDeposit(decimal depAmount);

        void MakeWithdraw(decimal withAmount);

        void GetStatus();
    }
}