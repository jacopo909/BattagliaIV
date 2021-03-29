using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Default : IState
    {
        public int GetClasseAttacco() => 0;
        public string GetClasseDescrizione() => "Default";
        public int GetClasseDifesa() => 0;
    }
}
