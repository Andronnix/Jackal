using System;
using System.Text;
using System.Drawing;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Jackal
{
    class Jackal : GameWindow
    {
        public Jackal() : base()
        {
            this.Run();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearDepth(1.0);
            GL.ClearColor(Color.Green);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(PrimitiveType.LineLoop);
            GL.Color3(Color.Azure);
            GL.Vertex2(0.7f, 0.7f);
            GL.Vertex2(0.7f, -0.7f);
            GL.Vertex2(-0.7f, -0.7f);
            GL.Vertex2(-0.7f, 0.7f);

            GL.End();
            SwapBuffers();
        }
    }
}
