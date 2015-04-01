using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominionCards
{
    public abstract class Card
    {
        private int price;
        public Card(int price)
        {
            this.price = price;
        }
        public int getPrice()
        {
            return price;
        }
        public abstract void play();
        public abstract void addToDeck();
        public abstract void trash();
    }
}
