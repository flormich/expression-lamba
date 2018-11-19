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

namespace ExpressionLamba
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Int32[] tab = { 12, 6, 9, 7, 0, 52, 4 };
        Int32 y = 3;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            afficher("Bienvenue dans ce monde de fous", devoyeller);
            afficher("Bienvenue dans ce monde de fous", crypter);
            afficher("Bienvenue dans ce monde de fous", renverser);

            //Expression lamba se reconnait au signe =>
            // A gauche les paramètres d'entrée
            //A droite le traitement            
            afficher("Bienvenue dans ce monde de fous", (foo) => foo.ToUpper());
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            int[] tab = { 1, 5, 4, 45, 21, 58, 74, 9, 58, 12, 32, 58 };
            int n1 = tab.Count();
            MessageBox.Show("Il y a " + n1.ToString() + " nombres");
            int n2 = tab.Count((x) => x > 20);
            MessageBox.Show("Il y a " + n2.ToString() + " nombres supérieure à 20");
            int n3 = tab.Count(truc);
            MessageBox.Show("Il y a " + n3.ToString() + " chiffres numérotés 58");
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Int32[] nbres = new Int32[1000];
            Random rnd = new Random();
            for (Int32 i = 0; i < nbres.Length; i++)
            {
                nbres[i] = rnd.Next(0, 100);
            }
            int n4 = nbres.Count((x) => x > 50);
            int n5 = nbres.Count((y) => (y % 2) == 0);
            MessageBox.Show("Il y a " + n4.ToString() + " chiffres supérieur à 50");
            MessageBox.Show("Il y a " + n5.ToString() + " chiffres paires");

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            calculer(tab, (x) => x * y);
        }

        public void calculer(int[] tab, Func<int, int> trait)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                tab[i] = trait(tab[i]);
                MessageBox.Show("Le chiffre " + tab[i]/y + " multiplié par " + y + " vaux : " + tab[i].ToString());
            }
        }

        Boolean truc(int x)
        {
            return x == 58;
        }

        public void afficher(String s, Func<String, String> fct)
        {
            MessageBox.Show(fct(s));
        }

        private String devoyeller(String s)
        {
            String[] voyelles = { "a", "e", "i", "o", "u", "y" };
            foreach (String c in voyelles)
            {
                s = s.Replace(c, "");
            }
            return s;
        }
        private String crypter(String s)
        {
            return s.Replace('e', '1').Replace(' ', '2').Replace('n', '3').Replace('u', '4').Replace('c', '5').Replace('f', '6').Replace('o', '7');
        }
        private String renverser(String s)
        {
            return String.Concat(s.ToCharArray().Reverse());
        }
    }
}
