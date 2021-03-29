using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_BattagliaIV
{
    
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Razza[] razze = new Razza[] { new Maghi(),new Elfi(), new Uomini(), new Troll(), new Stregoni(), new Orchi() };
        private IAttacco[] attacchi = new IAttacco[] { new DeafaultAttacco(), new SuperAttacco(),new RaddoppiaXP() };      
        private string[] emoji = new string[] {" ;)\n ... xD", "Wow!...", "gg........(￣y▽,￣)╭", "emm...ok\nψ(._. ) >", "(⓿_⓿)\nwow", "ผ(•̀_•́ผ)", "(/ ω＼*)………", "(/ ω•＼*)", "(✿◕‿◕✿)", "( ͡°( ͡° ͜ʖ( ͡° ͜ʖ ͡°)ʖ ͡°) ͡°)", " ( ͡° ͜ʖ ͡°)", " ( ͠° ͟ʖ ͡°)", "(ʘ ͟ʖ ʘ)", " (ʘ ͜ʖ ʘ)", "(★ ω ★)", "w(ﾟДﾟ)w", "(⊙_(⊙_⊙)_⊙)", "(*/ ω＼*)", "(●'◡'●)"," (o = ^•ェ•)o" };
        private List<Player> giocatori = new List<Player>();
        Random r = new Random();
        
        

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < razze.Length; i++)
            {
                cmbRazza.Items.Add(razze[i].GetDescrizioneRazza());

            }
            for (int j = 0; j < attacchi.Length; j++)
            {
                cmbAttacco.Items.Add(attacchi[j].Tipodiattacco());
            }
            
        }
        private void Tema_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbTemi.SelectedIndex)
            {
                case 0:
                    nameWinfow.Background = Brushes.Black;
                    StackPanel1.Background = Brushes.Black;
                    labBattagliaIV.Foreground = Brushes.White;
                    labNome.Foreground = Brushes.White;
                    labP1.Foreground = Brushes.White;
                    labP2.Foreground = Brushes.White;
                    labRazza.Foreground = Brushes.White;
                    labSeleziona_player.Foreground = Brushes.White;                    
                    break;
                default:
                    nameWinfow.Background = Brushes.White;
                    StackPanel1.Background = Brushes.White;
                    labBattagliaIV.Foreground = Brushes.Black;
                    labNome.Foreground = Brushes.Black;
                    labP1.Foreground = Brushes.Black;
                    labP2.Foreground = Brushes.Black;
                    labRazza.Foreground = Brushes.Black;
                    labSeleziona_player.Foreground = Brushes.Black;
                    break;

            }           
        }
        private void Inserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbRazza.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleziona una razza!", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Player p = new Player(txtNome.Text, razze[cmbRazza.SelectedIndex]);
                    if (txtNome.Text != "")
                    {                       
                        txtNome.Text = "";
                    }
                    else throw new Exception("Inserire un nome!");
                    giocatori.Add(p);
                    cmbPersonaggi.Items.Add(p.Nome);
                    cmbPlayer1.Items.Add(p.Nome);
                    cmbPlayer2.Items.Add(p.Nome);
                }               
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
                     
        }
        private void Statistiche_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbPersonaggi.SelectedIndex != -1)
                {
                    lbStampa1.Items.Clear();
                    if (giocatori[cmbPersonaggi.SelectedIndex].Nome == "Akihiko Kayaba")
                    {
                        lbStampa1.Items.Clear();
                        lbStampa1.Items.Add(giocatori[cmbPersonaggi.SelectedIndex].StatisticheOnlyCheater());
                    }
                    else
                    {
                        lbStampa1.Items.Clear();
                        lbStampa1.Items.Add(giocatori[cmbPersonaggi.SelectedIndex].StatistichePlayer());
                    }

                }
                else
                {
                    MessageBox.Show("Seleziona un personaggio!", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
                       
        }

        private void Pulisci_Click(object sender, RoutedEventArgs e)
        {
            lbStampa1.Items.Clear();
            lbStampa2.Items.Clear();
            txtNome.Text = "";
        }

        
       
        private void Combatti_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                ControlloSchieramento();
            }
            catch(Exception)
            {
                MessageBox.Show("inserisci P1 e P2");
            }               
        }
        
        private void ControlloCheat()
        {
            try
            {
                if (giocatori[cmbPlayer1.SelectedIndex].Nome == "Akihiko Kayaba" && giocatori[cmbPlayer2.SelectedIndex].Nome != "Akihiko Kayaba")
                {
                    lbStampa2.Items.Clear();
                    lbStampa2.Items.Add(giocatori[cmbPlayer1.SelectedIndex].EseguiStrategy(giocatori[cmbPlayer1.SelectedIndex], giocatori[cmbPlayer2.SelectedIndex]));
                    lbStampa2.Items.Add(emoji[r.Next(0, emoji.Length)]);
                }
                else if (giocatori[cmbPlayer2.SelectedIndex].Nome == "Akihiko Kayaba" && giocatori[cmbPlayer1.SelectedIndex].Nome == "Akihiko Kayaba")
                {
                    MessageBox.Show("Questo non è divertente _-_", "NOPE!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else if (giocatori[cmbPlayer2.SelectedIndex].Nome == "Akihiko Kayaba")
                {
                    MessageBox.Show("Nope...", "NOPE!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Errore...");
            }
            
             
        }
        private void ControlloSchieramento()
        {
            try
            {
                if (giocatori[cmbPlayer1.SelectedIndex].Razza.Schieramento(giocatori[cmbPlayer1.SelectedIndex].Razza) != giocatori[cmbPlayer2.SelectedIndex].Razza.Schieramento(giocatori[cmbPlayer2.SelectedIndex].Razza) && giocatori[cmbPlayer1.SelectedIndex].Nome != "Akihiko Kayaba" && giocatori[cmbPlayer2.SelectedIndex].Nome != "Akihiko Kayaba")
                {
                    lbStampa2.Items.Clear();
                    lbStampa2.Items.Add(giocatori[cmbPlayer1.SelectedIndex].EseguiStrategy(giocatori[cmbPlayer1.SelectedIndex], giocatori[cmbPlayer2.SelectedIndex]));
                }
                else if (giocatori[cmbPlayer1.SelectedIndex].Nome == "Akihiko Kayaba" || giocatori[cmbPlayer2.SelectedIndex].Nome == "Akihiko Kayaba")
                {
                    ControlloCheat();
                }
                else
                {
                    MessageBox.Show("I DUE PERSONAGGI FANNO PARTE DELLA STESSA RAZZA", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Inserisci P1 e P2");
            }
            
        }

        private void SelezionaAttacco_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmbAttacco.SelectedIndex != -1)
                {
                    if(cmbPlayer1.SelectedIndex != -1)
                    {
                        if(giocatori[cmbPlayer1.SelectedIndex].Nome != "Akihiko Kayaba")
                        {
                            giocatori[cmbPlayer1.SelectedIndex].Strategy = attacchi[cmbAttacco.SelectedIndex];
                        }
                        else
                        {
                            MessageBox.Show("Non c'è bisogno di un attacco, tanto vinco io ogni caso xD", "-_-", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Seleziona un il Player P1!", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Seleziona un Attacco!", "ATTENZIONE", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            
        }
    }
}
