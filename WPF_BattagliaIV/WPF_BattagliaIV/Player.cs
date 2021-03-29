using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class Player
    {
        private IState state;
        private int esperienza;
        private IAttacco strategy;
        private int vita;
             
        public string Nome { get; set; }
        public Razza Razza { get; set; }
        public IAttacco Strategy
        {
            get { return strategy; }
            set { strategy = value; }
        }
        public int Esperienza
        {
            get { return esperienza; }
            set { esperienza = value; }
        }
        public IState State
        {
            get { return state; }
            set { state = value; }
        }
        public int Vita
        {
            get { return vita; }
            set { vita = value; }
        }
        public Player(string nome,Razza r)
        {
            
            Nome = nome;
            Razza = r;
            //Valori di Default...
            Vita = 8000;
            Esperienza = 0;            
            Strategy = new DeafaultAttacco();
            State = new Default();           
            Cambiastato();

        }
        public void Cambiastato()
        {
            if (Esperienza >= 50)
            {
                State = new Principiante();
                if (Esperienza >= 100)
                {
                    State = new Esperto();
                }
            }
            else if (Nome == "Akihiko Kayaba")
            {
                State = new Cheater();
                Strategy = new OnlyCheater();
                
            }
        }
        public int GetAttaccoPlayer()
        {
            return State.GetClasseAttacco() + Razza.GetAttaccoRazza();
        }
        public int GetDifesaPlayer()
        {
            return State.GetClasseDifesa() + Razza.GetDifesaRazza();
        }
        public string StatistichePlayer()
        {
            return $"Player: {Nome}" +
                $"\nClasse: {State.GetClasseDescrizione()}" +
                $"\nATK Classe: {State.GetClasseAttacco()}" +
                $"\nDEF Classe: {State.GetClasseDifesa()}" +
                $"\nEsperienza: {Esperienza}" +
                $"\nRazza: {Razza.GetDescrizioneRazza()}" +
                $"\nATK Razza: {Razza.GetAttaccoRazza()}" +
                $"\nDEF Razza: {Razza.GetDifesaRazza()}";
        }
        public string StatisticheOnlyCheater()
        {
            return $"Player: {Nome}" +
               $"\nClasse: Beater" +
               $"\nATK Classe: ∞" +
               $"\nDEF Classe: ∞" +
               $"\nEsperienza: ∞" +
               $"\nRazza: #@[]#[@[$&£%$(£$" +
               $"\nATK Razza: ∞" +
               $"\nDEF Razza: ∞";
        }
        public string EseguiStrategy(Player p1, Player p2)
        {
            
            return Strategy.Attacco(p1, p2);
        }
    }
}
