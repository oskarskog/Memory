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
        public BitmapImage View { get; private set; }
        public bool Matched { get; set; }
        public bool Flipped { get; set; }

        public int Index { get; private set; }
        public int PairIndex { get; private set; }

        private BitmapImage _front;
        private BitmapImage _back;

        public CardModel(BitmapImage f, BitmapImage b, int i, int pi)
        {
            Index = i;
            PairIndex = pi;

            _back = b;
            _front = f;
            View = b;
            NotifyPropertyChanged("View");
        }

        public void Flip()
        {
            if (View == _front)
            {
                View = _back;
                Flipped = false;
            }
            else
            {
                View = _front;
                Flipped = true;
            }

            NotifyPropertyChanged("Flipped");
            NotifyPropertyChanged("View");
        }
    }
}
