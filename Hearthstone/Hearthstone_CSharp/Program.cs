using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hearthstone_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Deck tmp=new Deck();
            player[] players=new player[2];
            //Console.WriteLine("who is the first player :");
            players[0] = new player("First");
            players[1]=new player("Second");
            int turnCount = 0;
            bool isEnd = false;
            while (true)
            {
                Console.WriteLine("************** A new turn ******************");
                player currentPlayer = players[turnCount % 2];
                player nextPlayer = players[(turnCount+1) % 2];
                if(currentPlayer.getTurn(nextPlayer))
                {

                }
                
                turnCount += 1;
            }
        }
    }



}
