using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BattagliaIV
{
    class RaddoppiaXP : IAttacco
    {
        
        string risultato;
        public string Tipodiattacco() => "RaddoppiaXP";
        
        public string Attacco(Player p1, Player p2)
        {
            int DannoTotale;
            if (p1.GetAttaccoPlayer() > p2.GetDifesaPlayer() && p1.Vita > 0 && p2.Vita > 0)
            {
                DannoTotale = p1.GetAttaccoPlayer() - p2.GetDifesaPlayer();
                p2.Vita -= DannoTotale;
                if (p2.Vita <= 0)
                {
                    p1.Esperienza += 10 * 2;
                    p2.Vita = 8000;
                    risultato = ($"\nil Giocatore: {p1.Nome} ha inflitto: {DannoTotale} danni al Giocatore: {p2.Nome}" +
                    $"\nHP {p2.Nome}: {p2.Vita}" +
                    $"\nXP {p2.Nome}: {p2.Esperienza}" +
                    $"\nHP {p1.Nome}: {p1.Vita}" +
                    $"\nXP {p1.Nome}: {p1.Esperienza}" +
                    $"\n   {p2.Nome} ha perso...");                                     
                    p1.Cambiastato();
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
            else if (p1.GetAttaccoPlayer() <= p2.GetDifesaPlayer() && p1.Vita > 0 && p2.Vita > 0)
            {
                DannoTotale = p2.GetDifesaPlayer() - p1.GetAttaccoPlayer();
                p1.Vita -= DannoTotale;
                if (p1.Vita <= 0)
                {
                    p2.Esperienza += 10 * 2;
                    p1.Vita = 8000;
                    risultato = ($"\nil Giocatore: {p2.Nome} ha inflitto: {DannoTotale} danni al Giocatore: {p1.Nome}" +
                    $"\nHP {p1.Nome}: {p1.Vita}" +
                    $"\nXP {p1.Nome}: {p1.Esperienza}" +
                    $"\nHP {p2.Nome}: {p2.Vita}" +
                    $"\nXP {p2.Nome}: {p2.Esperienza}" +
                    $"\n   {p1.Nome} ha perso...");
                                      
                    p2.Cambiastato();
                }
                else
                {
                    p1.Esperienza = p1.Esperienza;
                    p2.Vita = p2.Vita;
                    risultato = ($"\nil Giocatore: {p2.Nome} ha inflitto: {DannoTotale} danni al Giocatore: {p1.Nome}" +
                    $"\nHP {p1.Nome}: {p1.Vita}" +
                    $"\nXP {p1.Nome}: {p1.Esperienza}" +
                    $"\nHP {p2.Nome}: {p2.Vita}" +
                    $"\nXP {p2.Nome}: {p2.Esperienza}");
                }

            }
            return risultato;
        }       
    }
}
