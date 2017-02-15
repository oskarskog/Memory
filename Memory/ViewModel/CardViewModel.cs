using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Memory.ViewModel
{
    public class CardViewModel : ViewModelBase
    {
        private Model.CardModel _cardModel;
        public BitmapImage Image { get; private set; }

        public CardViewModel(Uri uri)
        {
            _cardModel = new Model.CardModel() { Uri = uri, Identifier = 0 };
            LoadImage();
        }

        private void LoadImage()
        {
            try
            {
                Image = new BitmapImage(_cardModel.Uri);
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to load image!");
                Console.WriteLine(e.Message);
                return;
            }

            NotifyPropertyChanged("Image");
        }
    }
}
