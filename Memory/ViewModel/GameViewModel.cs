using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


namespace Memory.ViewModel
{
    public class GameViewModel : ObservableObjectBase
    {
        public Model.CardCollectionModel Cards { get; private set; }
        public Model.ClockModel Clock { get; private set; }

        public int MatchedCards { get; private set; }
        public int Tries { get; private set; }
        public string PlayerName { get; private set; }

        private bool _gameStarted;
        private int _clicks;

        public GameViewModel(string playerName)
        {
            PlayerName = playerName;
            MatchedCards = 0;
            Tries = 0;

            Clock = new Model.ClockModel();
            Cards = new Model.CardCollectionModel();
            _gameStarted = false;
            _clicks = 0;
        }

        // Flip Card
        //
        public void flipcard_executed(object sender, ExecutedRoutedEventArgs e)
        {
            int index = (int)e.Parameter;
            if (Cards.FlipAtIndex(index)) // returns true if match
            {
                MatchedCards++;
                NotifyPropertyChanged("MatchedCards");
            }

            _clicks++;
            if(_clicks % 2 == 0)
            {
                Tries++;
                NotifyPropertyChanged("Tries");
            }
        }

        public void flipcard_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _gameStarted;
        }

        // Start Game
        //
        public void startgame_executed(object sender, ExecutedRoutedEventArgs e)
        {
            StartGame();
        }

        public void startgame_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !_gameStarted;
        }

        // Restart Game
        //
        public void restartgame_executed(object sender, ExecutedRoutedEventArgs e)
        {
            ResetGame();
            StartGame();
        }

        public void restartgame_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = _gameStarted && Clock.ElapsedTime > new TimeSpan(0,0,2);
        }

        // Exit Game
        //
        public void exitgame_executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void exitgame_canexecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        // Starts game async in order to show cards
        //
        private async void StartGame()
        {
            await Task.Delay(500);
            foreach (var c in Cards)
                c.Flip();
            await Task.Delay(2000);
            foreach (var c in Cards)
                c.Flip();

            _gameStarted = true;
            Clock.Start();
        }

        // Resets game
        //
        private void ResetGame()
        {
            Cards.Reset();
            Cards.Shuffle();
            Clock.Reset();
            Clock.Stop();
            Tries = 0;
            _clicks = 0;
        }
    }

    // Routed UI comands
    //
    public class Commands
    {
        public static RoutedUICommand FlipCard { get; private set; }

        public static RoutedUICommand StartGame { get; private set; }
        public static RoutedUICommand RestartGame { get; private set; }
        public static RoutedUICommand ExitGame { get; private set; }

        static Commands()
        {
            FlipCard = new RoutedUICommand("FlipCard", "FlipCard", typeof(Commands));
            StartGame = new RoutedUICommand("StartGame", "StartGame", typeof(Commands));
            RestartGame = new RoutedUICommand("RestartGame", "RestartGame", typeof(Commands));
            ExitGame = new RoutedUICommand("ExitGame", "ExitGame", typeof(Commands));
        }
    }
}
