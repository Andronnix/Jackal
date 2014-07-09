using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackal
{
    class Player
    {
        private Pirate[] pirates;
        private int color;

        public Player(int color, IPlayerStrategy strategy)
        {
            this.color = color;
        }
    }
}
