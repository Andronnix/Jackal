using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Jackal
{
    class Brain
    {
        Timer t;
        bool renderInProgress = false;        
        AbstractGameRenderer r;
        public Brain(AbstractGameRenderer gr)
        {
            Game g = new Game(4);
            r = gr;
            r.Close += r_Close;
            r.ApplyGame(g);

            Render();
        }

        void r_Close(object sender, EventArgs e)
        {
            renderInProgress = false;
            if (t != null)
                t.Dispose();
        }

        public void Render()
        {
            renderInProgress = true;


            t = new Timer(new TimerCallback(t_Elapsed));
            t.Change(0, 1000 / 60);
            
            while (renderInProgress)
            {                
                
            }            
        }

        void t_Elapsed(Object o)
        {
            Console.Write("q");
            r.Render();
        }

    }
}
