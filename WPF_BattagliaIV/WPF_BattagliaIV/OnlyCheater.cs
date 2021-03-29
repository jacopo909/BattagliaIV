using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class OnlyCheater : IAttacco
    {
        
        string risultato;
        public string Tipodiattacco() => "OnlyCheater";
        public string Attacco(Player p1, Player p2)
        {
            int DannoTotale;
            if (p1.GetAttaccoPlayer() > p2.GetDifesaPlayer() && p1.Vita > 0 && p2.Vita > 0)
            {
                DannoTotale = p1.GetAttaccoPlayer();
                p2.Vita -= 8000;
                if (p2.Vita <= 0)
                {
                    risultato = ($"\nil Giocatore: {p1.Nome} ha inflitto: {DannoTotale} danni al Giocatore: {p2.Nome}" +
                    $"\nHP {p2.Nome}: {p2.Vita}" +
                    $"\nXP {p2.Nome}: {p2.Esperienza}" +
                    $"\nHP {p1.Nome}: {p1.Vita}" +
                    $"\nXP {p1.Nome}: {p1.Esperienza + 100}");
                    risultato = ($"{p2.Nome} ha perso...");
                    p1.Esperienza += 100;
                    p2.Vita = 8000;
                }
                else
                {
                    p1.Esperienza = p1.Esperienza;
                    p2.Vita = p2.Vita;
                    risultato = ($"\nil Giocatore: {p1.Nome} ha inflitto: {DannoTotale} danni al Giocatore: {p2.Nome}" +
                    $"\nHP {p2.Nome}: {p2.Vita}" +
                    $"\nXP {p2.Nome}: {p2.Esperienza}" +
                    $"\nHP {p1.Nome}: {p1.Vita}" +
                    $"\nXP {p1.Nome}: {p1.Esperienza}");
                }

            }
            return risultato;
        }

        
    }
}
