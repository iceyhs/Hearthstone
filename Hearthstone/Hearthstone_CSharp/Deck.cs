using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hearthstone_CSharp
{


    enum cardType  {a, b, c, d, e, f, g, h, i };

    class Deck
    {
        int length=0;
        int nextPick=0 ;
        card[] mycard;
        public Deck(int length = 30)
        {
            //Console.WriteLine(this.length.ToString());
            this.length = length;
            this.mycard = new card[length];
            char[] typelist = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i' };
            int[] typenum = new int[] { 10, 4, 2, 2, 2, 5, 2, 2, 1 };
            StringBuilder sbCardType = new StringBuilder();
            for (int iType = 0; iType < typelist.Length; iType++)
            {
                for (int jCount = 0; jCount < typenum[iType]; jCount++)
                {
                    sbCardType.Append(typelist[iType]);
                }
            }//build 30 card

            string cardsType = sbCardType.ToString();
            System.Collections.ArrayList rnd = MakeRand(0,29,30);
            int[] randIndex = new int[rnd.Count];
            rnd.CopyTo(randIndex);
            for (int iCard = 0; iCard < cardsType.Length; iCard++)
            {
                this.mycard[iCard] = new card(cardsType[randIndex[iCard]]);
                string tmp=this.mycard[iCard].show();
                //Console.WriteLine(tmp);
            }
            //Console.WriteLine(this.length.ToString()+" asdf "+this.nextPick.ToString());
           // Console.ReadKey();
        }
        public bool haveResidue()
        {
            return this.nextPick<this.length;

        }
        private System.Collections.ArrayList MakeRand(int intLower, int intUpper, int intNum)
        {
            System.Collections.ArrayList arrayRand = new System.Collections.ArrayList();
            Random random = new Random((int)DateTime.Now.Ticks);
            int intRnd;
            while (arrayRand.Count < intNum)
            {
                intRnd = random.Next(intLower, intUpper + 1);
                if (!arrayRand.Contains(intRnd))
                {
                    arrayRand.Add(intRnd);
                }
            }
            return arrayRand;
        }
        public card pickCard()
        {

            return this.mycard[this.nextPick++];
        }


    }

    class card
    {
        cardType type;
        int manaCost = 0;
        int damage = 0;
        int heal = 0;
        bool isDrawCard = false;
        string display = "";
        public card(char type)
        {
            switch (type)
            {
                case 'a':
                    this.damage = 1;
                    this.manaCost = 1;
                    this.type = cardType.a;
                    break;
                case 'b':
                    this.damage = 2;
                    this.manaCost = 2;
                    this.type = cardType.b;
                    break;
                case 'c':
                    this.damage = 3;
                    this.manaCost = 3;
                    this.type = cardType.c;
                    break;
                case 'd':
                    this.damage = 4;
                    this.manaCost = 4;
                    this.type = cardType.d;
                    break;
                case 'e':
                    this.damage = 5;
                    this.manaCost = 5;
                    this.type = cardType.e;
                    break;
                case 'f':
                    this.heal = 1;
                    this.manaCost = 1;
                    this.type = cardType.f;
                    break;
                case 'g':
                    this.heal = 2;
                    this.manaCost = 2;
                    this.type = cardType.g;
                    break;
                case 'h':
                    this.damage = 1;
                    this.manaCost = 1;
                    this.isDrawCard = true;
                    this.type = cardType.h;
                    break;
                case 'i':
                    this.damage = 4;
                    this.manaCost = 5;
                    this.display = "You will never defeat me!";
                    this.type = cardType.i;
                    break;
            }
           
        }
        public string show()
        {
            string info;
            info = "cardType " + this.type.ToString()
                + " manaCost: " + manaCost.ToString();
            if (!damage.Equals(0)) 
            {
                info = info + " damage: " + damage.ToString();
            }
            if(!heal.Equals(0))
            {
                info=info+" heal: " + heal.ToString() ;
            }
            if(!isDrawCard.Equals(false))
            {
                info = info + " and Draw 1 new Card " + isDrawCard.ToString();
            }
            if(display.Length!=0)
            {
                info=info+" Display:"+ display;
            }
            return info; 
        }
        public bool useCard(player owner, player opponent)
        {
            if (owner.manaChange(this.manaCost))
            {
                owner.hitPointChange(this.heal);
                opponent.hitPointChange(this.damage*(-1));
                if (this.isDrawCard)
                    owner.pickACard();
                if (this.display != "")
                {
                    Console.WriteLine(this.display);
                }
                return true;
            }
            else
            {
                Console.WriteLine("you don't have enough mana crystal!");
                return false;
            }
        }
    }
}
    
