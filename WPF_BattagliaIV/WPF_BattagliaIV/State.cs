using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    interface IState
    {


        int GetClasseAttacco();
        int GetClasseDifesa();
        string GetClasseDescrizione();

    }
}
