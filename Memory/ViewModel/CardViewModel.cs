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

        public bool Visible { get; private set; }
        public Image ShownImage { get; private set; }

        public CardViewModel(string fname)
        {
            _cardModel = new Model.CardModel();
            LoadImage(fname);
        }

        private void LoadImage(string fname)
        {
            try
            {
                var root = Directory.GetCurrentDirectory();
                var uri = new Uri(string.Format(@"{0}/../../Assets/Images/{1}", root, fname), UriKind.Absolute);
                var bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.UriSource = uri;
                bmp.EndInit();
                _cardModel.Front.Source = bmp;
                _cardModel.Back.Source = bmp;
                ShownImage = _cardModel.Front;
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed to load image!");
                Console.WriteLine(e.Message);
            }

            NotifyPropertyChanged("ShownImage");
        }

        public void Flip()
        {
            if(Visible)
            {
                ShownImage = _cardModel.Back;
                Visible = false;
            }
            else
            {
                ShownImage = _cardModel.Front;
                Visible = true;
            }
            NotifyPropertyChanged("ShownImage");
        }
    }
}
