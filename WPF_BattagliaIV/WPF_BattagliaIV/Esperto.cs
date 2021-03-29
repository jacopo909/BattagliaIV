using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Esperto : IState
    {
        public int GetClasseAttacco() => 2000;
        public string GetClasseDescrizione() => "Esperto";
        public int GetClasseDifesa() => 2000;
    }
}
