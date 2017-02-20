using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Memory.ViewModel
{
    public class GameViewModel : ObservableObjectBase
    {
        public Model.CardCollectionModel Cards { get; private set; }
        public Model.ClockModel Clock { get; private set; }

        private bool _gameStarted;

        public GameViewModel()
        {
            Clock = new Model.ClockModel();
            Cards = new Model.CardCollectionModel();

            _gameStarted = true;

            Cards.LoadCards();
            Clock.Start();
        }

        public void flipcard_executed(object sender, ExecutedRoutedEventArgs e)
        {
            var card = sender as Model.CardModel;
            card.Flip();
        }

        public void flipcard_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _gameStarted;
        }
    }

    // Routed UI comands
    public class Commands
    {
        public static RoutedUICommand FlipCard { get; private set; }

        public static RoutedUICommand StartGame { get; private set; }
        public static RoutedUICommand ResetGame { get; private set; }
        public static RoutedUICommand ExitGame { get; private set; }

        static Commands()
        {
            FlipCard = new RoutedUICommand("FlipCard", "FlipCard", typeof(Commands));
        }
    }
}
