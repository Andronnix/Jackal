using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackal
{
    class Field
    {
        private const int FIELD_SIZE = 11 + 2;
        private Cell[,] cells;
        private List<Pirate> pirates;
        
        public Field()
        {
            cells = new Cell[FIELD_SIZE, FIELD_SIZE];
        }

        private void generate()
        {
            for (int i = 0; i < FIELD_SIZE; i++)
            {
                for (int j = 0; j < FIELD_SIZE; j++)
                {
                    cells[i, j] = null;
                }
            }
    
            #region Manually added sea
            int max = FIELD_SIZE - 1;
            /* Top-left corner */
            cells[0, 0] = new Cell(CellType.NonSwimmableSea);
            cells[0, 1] = new Cell(CellType.NonSwimmableSea);
            cells[1, 0] = new Cell(CellType.NonSwimmableSea);
            cells[1, 1] = new Cell(CellType.Sea);

            /* Top-right corner */
            cells[max, 0]     = new Cell(CellType.NonSwimmableSea);
            cells[max, 1]     = new Cell(CellType.NonSwimmableSea);
            cells[max - 1, 0] = new Cell(CellType.NonSwimmableSea);
            cells[max - 1, 1] = new Cell(CellType.Sea);

            /* Bottom-left corner */
            cells[0, max]     = new Cell(CellType.NonSwimmableSea);
            cells[1, max]     = new Cell(CellType.NonSwimmableSea);
            cells[0, max - 1] = new Cell(CellType.NonSwimmableSea);
            cells[1, max - 1] = new Cell(CellType.Sea);

            /* Bottom-left corner */
            cells[max, max]         = new Cell(CellType.NonSwimmableSea);
            cells[max - 1, max]     = new Cell(CellType.NonSwimmableSea);
            cells[max, max - 1]     = new Cell(CellType.NonSwimmableSea);
            cells[max - 1, max - 1] = new Cell(CellType.Sea);

            for (int i = 1; i < FIELD_SIZE - 1; i++)
            {
                cells[0, i] = new Cell(CellType.Sea);
                cells[max, i] = new Cell(CellType.Sea);
                cells[i, max] = new Cell(CellType.Sea);
                cells[i, 0] = new Cell(CellType.Sea);
            }
            #endregion

            #region Randomly generated island
            RandomGettingPool<CellType> typePool = new RandomGettingPool<CellType>();
            foreach(CellType t in CellTypeCount.GetTypes()) {
                if (t == CellType.Sea || t == CellType.NonSwimmableSea) continue;   //Added manually
                for (int i = 0; i < CellTypeCount.GetCount(t); i++)
                {
                    typePool.Add(t);
                }
            }

            RandomGettingPool<Point> positionPool = new RandomGettingPool<Point>();
            for (int i = 1; i < FIELD_SIZE - 1; i++)
            {
                for (int j = 1; j < FIELD_SIZE - 1; j++)
                {
                    if (i == j && (i == 1 || i == FIELD_SIZE - 1)) continue;        //Skip corners, already added
                    positionPool.Add(new Point(i, j));
                }
            }

            if (typePool.Count != positionPool.Count)
                throw new InvalidProgramException("Field Generation. Cell pools do not match");

            while (!positionPool.IsEmpty())
            {
                Point p = positionPool.GetRandom();
                cells[p.X, p.Y] = new Cell(typePool.GetRandom(), Cell.GetRandomRotation());
            }

            #endregion
        }
        

    }

    /// <summary>
    /// Class describes pool, providing random getting of items*/
    /// </summary>
    /// <typeparam name="T">Item type</typeparam> 
    class RandomGettingPool<T>
    {
        private List<T> storage = new List<T>();
        private Random r = new Random();       

        /// <summary>
        /// Add item to the pool
        /// </summary>
        /// <param name="item">item to add</param>
        public void Add(T item)
        {
            storage.Add(item);
        }

        /// <summary>
        /// Returns random item from pool 
        /// </summary>        
        public T GetRandom()
        {
            int n = r.Next(storage.Count);
            T result = storage.ElementAt(n);
            storage.RemoveAt(n);
            return result;
        }

        /// <summary>
        /// Returns items number in the pool
        /// </summary>
        public int Count
        {
            get { return storage.Count; }
        }

        /// <summary>
        /// Check if pool is empty 
        /// </summary>
        public bool IsEmpty()
        {
            return storage.Count == 0;
        }

    }
}
