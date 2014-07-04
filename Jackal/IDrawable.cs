using System.Drawing;

namespace Jackal
{
    public interface IDrawable
    {
        Rectangle GetBoundingRect();
        void Render();
    }
}
