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
    public class GameViewModel : NotifyChange
    {
        public ObservableCollection<Model.CardModel> Cards;
        public Model.ClockModel Clock;

        public Image CurrentImage;
        
        public GameViewModel()
        {
            Clock = new Model.ClockModel();
            Cards = new ObservableCollection<Model.CardModel>();
            CurrentImage = new Image();
            Setup();
           
        }

        private void Setup()
        {
            var imagesPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            var imageNames = Directory.GetFiles(@imagesPath + @"/Assets/Images/", "*.jpg", SearchOption.AllDirectories);

            CurrentImage.Source = new BitmapImage(new Uri(imageNames.Last()));
            NotifyPropertyChanged("CurrentImage");
        }
    }
}
