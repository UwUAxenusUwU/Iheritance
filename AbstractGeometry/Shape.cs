using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace AbstractGeometry
{
    abstract class Shape:IDrawable
    {
        protected static readonly int min_start_y = 10;
        protected static readonly int min_start_x = 10;
        protected static readonly int max_start_x = 800;
        protected static readonly int max_start_y = 600;
        protected static readonly int min_line_width = 3;
        protected static readonly int max_line_width = 33;
        protected static readonly int min_size = 50;
        protected static readonly int max_size = 800;

        int startX;
        int startY;
        int lineWidth;
        public Color Color { get; set; }
        public int StartX
        {
            get => startX; 
            set
            {
                if(value < min_start_x) value = min_start_x;
                if(value > max_start_x) value = max_start_x;
                startX = value;
            }
        }
        public int StartY
        {
            get => startY;
            set
            {
                if (value < min_start_y) value = min_start_y;
                if (value > max_start_y) value = max_start_y;
                startY = value;
            }
        }
        public int LineWidth
        {
            get => lineWidth;
            set
            {
                if (value < min_line_width) value = min_line_width;
                if (value > max_line_width) value = max_line_width;
                lineWidth = value;
            }
        }
        public Shape(int startX, int startY, int lineWidth, Color color)
        {
            StartX = startX;
            StartY = startY;
            LineWidth = lineWidth;
            Color = color;
        }
        //////////////////////////////
        public abstract double GetArea();
        public abstract double GetPerimiter();
        public abstract void Draw(PaintEventArgs e);
        public virtual void Info(PaintEventArgs e)
        {
            Console.WriteLine(this);
            this.Draw(e);
        }
        public override string ToString()
        {
            string result = "";
            result += $"Area:\t\t{GetArea()}\n";
            result += $"Perimiter:\t\t{GetPerimiter()}\n";
            return result; 
        }
    }
}
