using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Memory.Model
{
    public class CardCollectionModel : ObservableCollection<CardModel>
    {
        public CardCollectionModel()
        {

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
    }
}
