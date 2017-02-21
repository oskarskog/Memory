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

namespace Memory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel.GameViewModel vm;

        public MainWindow(string playerName)
        {
            InitializeComponent();
            vm = new ViewModel.GameViewModel(playerName);
            DataContext = vm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CommandBindings.Add(new CommandBinding(ViewModel.Commands.FlipCard, vm.flipcard_executed, 
                vm.flipcard_canexecute));
            
            CommandBindings.Add(new CommandBinding(ViewModel.Commands.StartGame, vm.startgame_executed,
               vm.startgame_canexecute));

            CommandBindings.Add(new CommandBinding(ViewModel.Commands.RestartGame, vm.restartgame_executed,
               vm.restartgame_canexecute));

            CommandBindings.Add(new CommandBinding(ViewModel.Commands.ExitGame, vm.exitgame_executed,
               vm.exitgame_canexecute));
        }
    }
}
