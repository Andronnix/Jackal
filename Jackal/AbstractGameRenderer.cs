using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Jackal
{
    abstract class AbstractGameRenderer
    {
        private Game game;
        private Field gameField;
        public AbstractGameRenderer(Game g)
        {
            game = g;
            gameField = g.field;
        }

        /// <summary>
        /// Reneder game
        /// </summary>
        abstract void Render();

        /// <summary>
        /// Select object at screen position, deselect previous, if selected
        /// </summary>
        abstract void SelectAt(Point p);

        /// <summary>
        /// Deselect last object, if selected
        /// </summary>
        abstract void Deselect();
    }
}
