using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jackal
{
    class Brain
    {
        public Brain()
        {
            Game g = new Game(4);
            OpenGLGameRenderer r = new OpenGLGameRenderer(g);
            r.Render();
        }
    }
}
