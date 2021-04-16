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

namespace lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void encrypt_Click(object sender, RoutedEventArgs e)
        {

            Keys key = new Keys();
            int q = key.GenerateQ();
            int p = key.GenerateP(q);
            int g = key.GenerateG(q, p);
            int x = key.GenerateX(q);
            int y = key.FastExponentiation(p, g, x);

            cipher_r.Text = "";
            cipher_s.Text = "";

            string src = source.Text;

            DSA dsa = new DSA();
            int[] res;
 
            res = dsa.Signature(src, q, p, g, x);
            cipher_r.Text += Convert.ToString(res[0]);
            cipher_s.Text += Convert.ToString(res[1]);

            keyP.Text = Convert.ToString(p);
            keyQ.Text = Convert.ToString(q);
            keyY.Text = Convert.ToString(y);
            keyX.Text = Convert.ToString(x);
        }

        private void decrypt_Click(object sender, RoutedEventArgs e)
        {
            int q = Convert.ToInt32(keyQ.Text);
            int p = Convert.ToInt32(keyP.Text);
            int y = Convert.ToInt32(keyY.Text);

            int r = Convert.ToInt32(textR.Text);
            int s = Convert.ToInt32(textS.Text);

            Keys key = new Keys();
            int g = key.GenerateG(q, p);

            string src = source.Text;

            DSA dsa = new DSA();
            if (dsa.CheckingSignature(q, p, r, y, g, s, src))
            {
                cipher.Text = "The signature is correct";
            }
            else
            {
                cipher.Text = "The signature isn't correct";
            }
        }
    }
}
