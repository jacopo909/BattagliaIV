using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Orchi : Male
    {
        public int ATK { get; private set; }
        public int DEF { get; private set; }
        public string DESC { get; private set; }
        public Orchi()
        {
            ATK = 2000;
            DEF = 2000;
            DESC = "Orchi";
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
