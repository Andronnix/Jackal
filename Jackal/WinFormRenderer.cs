using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Jackal
{
    class WinFormRenderer : AbstractGameRenderer
    {
        private int width  = 800;
        private int height = 600;

        private delegate void RenderDelegate(); 
        private Form f;
        private Image buffer;
        private DrawableCell[,] cells;

        protected override void initSelf()
        {
            Console.Write("child");
            Thread t = new Thread(new ThreadStart(formInit));
            t.Start();
            
            SpinWait sw = new SpinWait();
            while (f == null) { sw.SpinOnce(); } //Wait, while form is being created
            f.FormClosing += formClosing;
            f.Paint += formPaint;
            f.Resize += formResize;            
        }

        private void formInit()
        {
            f = new Form();
            f.Size = new Size(width, height);
            f.Load += formLoad; // Should be there before showing

            buffer = new Bitmap(width, height);

            f.ShowDialog(); //Must be the last call to form in this method
        }

        void formLoad(object sender, EventArgs e)
        {
            cells = new DrawableCell[gameField.Cells.GetLength(0), gameField.Cells.GetLength(1)];
        }

        void formResize(object sender, EventArgs e)
        {
            int border = 4;            

            width = f.ClientRectangle.Width;
            height = f.ClientRectangle.Height;

            if (width == 0 || height == 0) return;
            buffer = new Bitmap(width, height);

            int w = gameField.Cells.GetLength(0);
            int h = gameField.Cells.GetLength(1);

            int step = Math.Min(width / w, height / h);
            Size correction = new Size(
                f.ClientRectangle.X + (width - Math.Min(width, height)) / 2,
                f.ClientRectangle.Y + (height - Math.Min(width, height)) / 2
            );

            Size cellSize = new Size(step - border, step - border);            
            if (cells == null)
            {
                
            }

            Point p = new Point(0, 0);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    p.X = i * step + border / 2;
                    p.Y = j * step + border / 2;
                    p += correction;

                    if (cells[i, j] == null)
                    {
                        cells[i, j] = new DrawableCell(gameField.Cells[i, j], p, cellSize);
                    }
                    else
                    {
                        cells[i, j].position = p;
                        cells[i, j].size = cellSize;
                    }                    
                }
            }

            f.Invalidate();
        }

        void formPaint(object sender, PaintEventArgs e)
        {
            if (buffer == null) return;
            Graphics g = e.Graphics;
            g.DrawImage(buffer, new Point(0, 0));
        }

        void formClosing(object sender, FormClosingEventArgs e)
        {
            RaiseClose();
        }

        public override void Render()
        {
            RenderDelegate rd = new RenderDelegate(draw);
            try
            {
                if(f.Visible)
                    f.Invoke(rd);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private void draw()
        {
            if (buffer == null) return;
            Graphics g = Graphics.FromImage(buffer);
            g.Clear(Color.White);

            if (cells == null || cells[0, 0] == null) return; //nothing to draw

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j].Draw(g);
                }
            }

            f.Invalidate();
        }
       
        public override void SelectAt(System.Drawing.Point p)
        {
            throw new NotImplementedException();
        }

        public override void Deselect()
        {
            throw new NotImplementedException();
        }
    }

    class DrawableCell
    {
        private Cell cell;
        public Point position;
        public Size size;
        
        public DrawableCell(Cell c, Point p, Size s)
        {
            cell = c;
            position = p;
            size = s;
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, new Rectangle(position, size));
        }
    }
}
