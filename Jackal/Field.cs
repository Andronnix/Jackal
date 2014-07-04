using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackal
{
    class Field
    {
        private int size;
        private Cell[,] cells;
        private List<Pirate> pirates;
        
        public Field(int size)
        {
            this.size = size;
            cells = new Cell[size, size];
        }

        private void generate()
        {
            //for(int i )
        }
    }
}
