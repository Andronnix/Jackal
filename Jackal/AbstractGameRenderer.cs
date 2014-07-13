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
        public event EventHandler Close;

        protected Game game;
        protected Field gameField;
        public AbstractGameRenderer() {}

        public void ApplyGame(Game g)
        {
            Console.Write("base");
            game = g;
            gameField = g.field;
            initSelf();
        }

        /// <summary>
        /// This should contain all initialization logic, called after game value is set
        /// </summary>
        abstract protected void initSelf();

        /// <summary>
        /// Render game
        /// </summary>
        abstract public void Render();

        /// <summary>
        /// Select object at screen position, deselect previous, if selected
        /// </summary>
        abstract public void SelectAt(Point p);

        /// <summary>
        /// Deselect last object, if selected
        /// </summary>
        abstract public void Deselect();

        protected virtual void RaiseClose()
        {
            EventHandler handler = Close;

            if (handler != null)
            {
                handler(this, null);
            }
        }
    }
}
