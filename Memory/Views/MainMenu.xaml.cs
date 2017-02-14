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

namespace Memory.views
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public string Name { get; private set; }
        public MainMenu()
        {
            InitializeComponent();
        }

        private void nameButton_Click(object sender, RoutedEventArgs e)
        {
            Name = nameInput.Text;
            this.Close();
        }
    }
}
