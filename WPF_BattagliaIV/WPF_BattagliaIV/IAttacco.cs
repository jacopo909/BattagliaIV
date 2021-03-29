using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    interface IAttacco
    {
        string Attacco(Player p1, Player p2);
        string Tipodiattacco();
        
    }
}
