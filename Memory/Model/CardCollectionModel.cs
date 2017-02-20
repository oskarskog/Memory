using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Memory.Model
{
    public class CardCollectionModel : ObservableCollection<CardModel>
    {
        private int _flippedCards;

        private DispatcherTimer _timer;
        private CardModel firstFlipped;
        private CardModel secondFlipped;

        public int MatchedPairs { get; private set; }

        public CardCollectionModel()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 1);
            _timer.Tick += new EventHandler(onTimerTick);

            MatchedPairs = 0;
            _flippedCards = 0;
            LoadCards();
            Shuffle();
        }

        public void LoadCards()
        {
            BitmapImage backSide = null;
            DirectoryInfo imgDir = new DirectoryInfo(@"..\..\Assets\Images");
            backSide = new BitmapImage(new Uri(imgDir.FullName + @"\backside.jpg"));

            int index = 0;
            foreach (var imgFile in imgDir.GetFiles("*.jpg"))
            {
                if (imgFile.FullName.Split('\\').Last() == "backside.jpg")
                    continue;

                this.Add(new CardModel(new BitmapImage(new Uri(imgFile.FullName)), backSide, index, index+1));
                this.Add(new CardModel(new BitmapImage(new Uri(imgFile.FullName)), backSide, index+1, index));
                index += 2;
            }
        }

        public void Shuffle()
        {
            var rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                this.Move(rnd.Next(0, this.Count), rnd.Next(0, this.Count));
            }
        }

       public bool FlipAtIndex(int index)
        {
            var c = this.First(x => x.Index == index);

            // !Flipped = backside up
            if (!c.Flipped && _flippedCards < 2)
            {
                if (_flippedCards < 1)
                    firstFlipped = c;
                else
                    secondFlipped = c;

                c.Flip();
                _flippedCards++;
            }

            if(_flippedCards > 1)
            {
                if(firstFlipped.PairIndex == secondFlipped.Index)
                {
                    MatchedPairs++;
                    _flippedCards = 0;
                    return true;
                }
                else
                    _timer.Start();
            }

            return false;
        }

        private void onTimerTick(object o, EventArgs args)
        {
            firstFlipped.Flip();
            secondFlipped.Flip();
            _flippedCards = 0;
            _timer.Stop();
        }
    }
}
