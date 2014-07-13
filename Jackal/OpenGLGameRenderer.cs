using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;


namespace Jackal
{
    class OpenGLGameRenderer : AbstractGameRenderer
    {
        Renderer r;
        public OpenGLGameRenderer()
            : base()
        {
            r = new Renderer();
        }

        public override void Render()
        {
            throw new NotImplementedException();
        }

        public override void SelectAt(System.Drawing.Point p)
        {
            throw new NotImplementedException();
        }

        public override void Deselect()
        {
            throw new NotImplementedException();
        }


        private class Renderer : GameWindow
        {
            public Renderer() : base()
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

            protected override void OnResize(EventArgs e)
            {
                GL.Viewport(ClientRectangle);

                Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                    MathHelper.PiOver4,
                    this.Width / (float)this.Height,
                    0.1f,
                    10.0f
                );
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadMatrix(ref projection);
            }


            protected override void OnRenderFrame(FrameEventArgs e)
            {
                base.OnRenderFrame(e);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

                float f = 1f;
                GL.Begin(PrimitiveType.LineLoop);
                GL.Color3(Color.Azure);
                GL.Vertex2(f, f);
                GL.Vertex2(f, -f);
                GL.Vertex2(-f, -f);
                GL.Vertex2(-f, f);
                GL.End();

                SwapBuffers();
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);
                Console.WriteLine(String.Format("({0}, {1})", this.Mouse.X, this.Mouse.Y));
            }
        }

        protected override void initSelf()
        {
            throw new NotImplementedException();
        }
    }
}
