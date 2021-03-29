using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Troll : Male
    {
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public string DESC { get; private set; }
        public Troll()
        {
            ATK = 800;
            DEF = 2300;
            DESC = "Troll";
        }
        public override int GetAttaccoRazza() => ATK;
        public override string GetDescrizioneRazza() => DESC;
        public override int GetDifesaRazza() => DEF;
        public override bool Schieramento(Razza r)
        {
            bool flag = true;
            if (r is Male)
            {
                flag = false;
            }
            return flag;
        }
    }
}
