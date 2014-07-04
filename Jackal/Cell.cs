using System;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Jackal
{
    class Cell : IDrawable
    {
        Point pos;
        public Cell(CellType type, Point position)
        {
            pos = position;
        }
    }

    enum CellType {
        /* Landscape */
        Empty,
        Sea,
        NonSwimmableSea,            //TODO: Better Name??
        
        /* Directions */
        StraightArrow,
        DiagonalArrow,
        Straight2WayArrow,
        Diagonal2WayArrow,
        Straight4WayArrow,
        Diagonal4WayArrow,
        Horses,
        Crocodile,

        /* Forths */
        Forth,
        AmazonForth,

        /* Slow */
        Slow2Step,
        Slow3Step,
        Slow4Step,
        Slow5Step,

        /* Traps */
        Rum,
        Troll,


        MoneyChest
    }
}
