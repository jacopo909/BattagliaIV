using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Uomini : Bene
    {
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public string DESC { get; private set; }
        public Uomini()
        {
            ATK = 1600;
            DEF = 1000;
            DESC = "Uomini";
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
