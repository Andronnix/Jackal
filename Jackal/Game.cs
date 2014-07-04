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
        public const int FIELD_SIZE = 11;
        private IGameRenderer renderer;
        private Player[] players;
        private Field field;

        public Game(int playersNumber, IGameRenderer gameRenderer)
        {
            field = new Field(FIELD_SIZE);

            for (int i = 0; i < playersNumber; i++)
                players[i] = new Player(PlayerColor[i % PlayerColor.Length], new HumanStategy());

            renderer = gameRenderer;
        }
    }    
}
