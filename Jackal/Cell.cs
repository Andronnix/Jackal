using System;
using System.Collections.Generic;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using System.Collections;

namespace Jackal
{
    class Cell : IDrawable
    {
        public static const int CELL_ROTATION_UP    = 0;
        public static const int CELL_ROTATION_RIGHT = 1;
        public static const int CELL_ROTATION_DOWN  = 2;
        public static const int CELL_ROTATION_LEFT  = 3;
        public static int GetRandomRotation() {
            return (new Random()).Next(4);
        }


        public int rotation;
        public CellType type;

        public Cell(CellType type): this(type, CELL_ROTATION_UP) { }        

        public Cell(CellType type, int rotation)
        {
            this.type = type;
            this.rotation = rotation;
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
        Diagonal3WayArrow,
        Straight4WayArrow,
        Diagonal4WayArrow,

        /* Forths */
        Forth,
        AmazonForth,

        /* Slow */
        Slow2Step,
        Slow3Step,
        Slow4Step,
        Slow5Step,

        /* Traps */
        Trap, 
        Rum,
        Troll,

        /* Others */
        Cannon,                      /* fly into the sea */
        Lake,                        /* Repeat */
        Horses,                      /* Knight-like */
        Crocodile,                   /* Turn backwards */
        Airplane,                    /* TP anywhere */
        Parashute,                   /* TP to your ship */


        /* Gold chests */
        MoneyChest1,
        MoneyChest2,
        MoneyChest3,
        MoneyChest4,
        MoneyChest5
    }

    public static class CellTypeCount {
        private static Dictionary<CellType, int> storage = new Dictionary<CellType, int>
        {
            {CellType.Airplane,           1},
            {CellType.AmazonForth,        1},
            {CellType.Cannon,             2},
            {CellType.Crocodile,          4},
            {CellType.Diagonal2WayArrow,  3},
            {CellType.Diagonal3WayArrow,  3},
            {CellType.Diagonal4WayArrow,  3},
            {CellType.DiagonalArrow,      3},
            {CellType.Empty,             40},
            {CellType.Forth,              2},
            {CellType.Horses,             2},
            {CellType.Lake,               6},
            {CellType.MoneyChest1,        5},
            {CellType.MoneyChest2,        5},
            {CellType.MoneyChest3,        3},
            {CellType.MoneyChest4,        2},
            {CellType.MoneyChest5,        1},
            {CellType.NonSwimmableSea,   12},
            {CellType.Parashute,          2},
            {CellType.Rum,                4},
            {CellType.Sea,               40},
            {CellType.Slow2Step,          5},
            {CellType.Slow3Step,          4},
            {CellType.Slow4Step,          2},
            {CellType.Slow5Step,          1},
            {CellType.Straight2WayArrow,  3},
            {CellType.Straight4WayArrow,  3},
            {CellType.StraightArrow,      3},
            {CellType.Trap,               3},
            {CellType.Troll,              1}
        };

        public static IEnumerable<CellType> GetTypes()
        {
            return storage.Keys;
        }

        public static int GetCount(CellType t) {return storage[t]; }
    }
}
