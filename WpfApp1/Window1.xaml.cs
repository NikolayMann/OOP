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
using System.Windows.Shapes;

namespace WpfApp1
{
    public static class BetweenTwoForms
    {
        public static int HowMuch;
    }
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            int zahlen = 0;

            if (e.Key == Key.Enter)
            {
                try
                {
                    zahlen = Convert.ToInt32(Zahlen.Text);
                    BetweenTwoForms.HowMuch = zahlen;
                }
                catch
                {
                    BetweenTwoForms.HowMuch = 0;
                }
                this.Close();
            }
        }
    }
}
