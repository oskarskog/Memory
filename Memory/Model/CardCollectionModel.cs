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
            var images = new List<BitmapImage>();
            DirectoryInfo imgDir = new DirectoryInfo(@"..\..\Assets\Images");
            backSide = new BitmapImage(new Uri(imgDir.FullName + @"\backside.jpg"));

            foreach (var imgFile in imgDir.GetFiles("*.jpg"))
            {
                if (imgFile.FullName.Split('\\').Last() != "backside.jpg")
                   this.Add(new CardModel(new BitmapImage(new Uri(imgFile.FullName)), backSide));
            }
        }
    }
}
