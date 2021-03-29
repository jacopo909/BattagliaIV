using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    abstract class Razza
    {
        public abstract int GetAttaccoRazza();
        public abstract int GetDifesaRazza();
        public abstract string GetDescrizioneRazza();
        public abstract bool Schieramento(Razza r);
    }
}
