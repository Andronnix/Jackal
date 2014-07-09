using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackal
{
    class Game
    {
        public const int[] PlayerColor = { 0, 1, 2, 3 };
        private Player[] players;
        public Field field;

        public Game(int playersNumber)
        {
            field = new Field();

            for (int i = 0; i < playersNumber; i++)
                players[i] = new Player(PlayerColor[i % PlayerColor.Length], new HumanStategy());

        }
    }    
}
