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
        public ObservableCollection<CardViewModel> Cards { get; private set; }
        public ClockViewModel Clock { get; private set; }

        public GameViewModel()
        {
            Clock = new ClockViewModel();
            Cards = new ObservableCollection<CardViewModel>();
            Setup();
        }

        private void Setup()
        {
            DirectoryInfo imgDir = new DirectoryInfo(@"..\..\Assets\Images");
            foreach(var imgFile in imgDir.GetFiles("*.jpg"))
            {
                var uri = new Uri(imgFile.FullName);
                Cards.Add(new CardViewModel(uri));
            }
        }
    }
}
