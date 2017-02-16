using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Memory.Model
{
    public class CardModel : ObservableObjectBase
    {
        public BitmapImage Image { get; private set; }
        public bool Matched { get; set; }

        private BitmapImage _front;
        private BitmapImage _back;

        public CardModel(BitmapImage f, BitmapImage b)
        {
            _back = b;
            _front = f;
            Image = b;
            NotifyPropertyChanged("Image");
        }

        public void Flip()
        {
            Image = Image == _front ? _back : _front;
            NotifyPropertyChanged("Image");
        }
    }
}
