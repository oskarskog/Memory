using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Memory.Model
{
    public class CardModel
    {
        public Image Front;
        public Image Back;

        public int Identifier;

        public CardModel()
        {
            Front = new Image();
            Back = new Image();
        }
    }
}
