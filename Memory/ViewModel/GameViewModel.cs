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

        public GameViewModel()
        {
            Clock = new Model.ClockModel();
            Cards = new Model.CardCollectionModel();

            Cards.LoadCards();
            Clock.Start();
        }


        // Routed UI comands
        public class Commands
        {
            

        }
    }
}
