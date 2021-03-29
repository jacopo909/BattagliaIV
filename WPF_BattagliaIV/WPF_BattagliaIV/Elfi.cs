using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Elfi : Bene
    {
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public string DESC { get; private set; }
        public Elfi()
        {
            ATK = 1800;
            DEF = 1500;
            DESC = "Elfi";
        }
        public override int GetAttaccoRazza() => ATK;
        public override string GetDescrizioneRazza() => DESC;
        public override int GetDifesaRazza() => DEF;
        public override bool Schieramento(Razza r)
        {
            bool flag = false;
            if (r is Bene)
            {
                flag = true;
            }
            return flag;
        }
    }
}
