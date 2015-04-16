using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone_CSharp
{
    class player
    {
        string name;
        int hitPoint;
        int mana;
        int manasum;
        Deck myDeck;
        List<card> inHand=new List<card>();

        public  player(string name ="new player")
        {
            this.name = name;
            this.hitPoint=30;
            this.mana = 0;
            this.manasum = 0;
            this.myDeck =new Deck();
            Console.WriteLine(name+" have 4 cards");
            for (int iPick=0;iPick<4;iPick++)
            {
                this.pickACard();
            }
        }

        public int getHitPoint()
        {
            return this.hitPoint;
        }
        public void pickACard()
        {
            if (this.myDeck.haveResidue())
            {
                this.inHand.Add(this.myDeck.pickCard());
            }
            else 
            {
                this.hitPointChange(-1);
            }
        }
        public bool getTurn(player opponent)
        {
            bool isOver=false;
            this.pickACard();
            this.manasum +=1;
            if (this.manasum > 10)
                this.manasum = 10;
            this.mana = this.manasum;
            Console.WriteLine("Now, " + this.name + ", this is your turn.");
            this.getCard(opponent);

            if (opponent.getHitPoint() < 1)
                isOver = true;
            return isOver;

        }


        public void getCard(player opponent)
        {
            while (true)
            {
                Console.WriteLine("           ------------------   ");
                Console.WriteLine("you are now " + this.hitPoint.ToString() + "/30 hit point ");
                Console.WriteLine("   your " + this.inHand.Count.ToString() + " card:");
                for (int iCard = 0; iCard < this.inHand.Count; iCard++)
                {
                    string tmp = this.inHand[iCard].show();
                    Console.WriteLine(iCard.ToString() + "  " + tmp);
                }
                Console.WriteLine("you have " + this.mana.ToString() + "/" + this.manasum.ToString() +
                    "  mana crystal");
                Console.WriteLine("your opponent have : " + opponent.getHitPoint().ToString()+" hit point.");
                Console.WriteLine("           ------------------   ");
                Console.Write("please enter which card you want to use or you can enter 'q' to quit.\nenter a number:  ");
                string input = Console.ReadLine();
                if (input == "q")
                    break;
                int index = int.Parse(input);
                if (index < 0 | index > this.inHand.Count)
                    Console.WriteLine("error input index!");
                else
                {
                    if (this.inHand[index].useCard(this, opponent))
                        this.inHand.RemoveAt(index);
                }
                if (opponent.getHitPoint() < 1)
                { break; }
            }
        }

        public bool manaChange(int x)
        {
            if (this.mana >= x)
                this.mana -= x;
            else
                return false;
            return true;
        }

        public void hitPointChange(int x)
        {
            this.hitPoint += x;
            if (this.hitPoint < 0)
            {
                this.hitPoint = 0;
            }
            if (this.hitPoint > 30)
            {
                this.hitPoint = 30;
            }
        }
    
    }
}
