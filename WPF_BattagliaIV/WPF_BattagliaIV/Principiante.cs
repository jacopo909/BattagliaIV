using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Principiante : IState
    {
        public int GetClasseAttacco() => 1000;
        public string GetClasseDescrizione() => "Principiante";
        public int GetClasseDifesa() => 1000;
    }
}
