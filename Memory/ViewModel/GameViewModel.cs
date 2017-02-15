using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Memory.ViewModel
{
    public class GameViewModel : ViewModelBase
    {
        public CardViewModel Card { get; private set; }
        
        public GameViewModel()
        {
            Card = new CardViewModel("pikachu.jpg");
           
        }

        private void Setup()
        {
           
        }
    }
}
