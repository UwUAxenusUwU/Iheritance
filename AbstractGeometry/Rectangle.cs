using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
    class Rectangle : Shape
    {
        double width;
        double height;
        public double Width
        {
            get => width;
            set => width = value < min_size ? min_size : value > max_size ? max_size : value;
        }
        public double Height
        {
            get => height;
            set => height = value < min_size ? min_size : value > max_size ? max_size : value;
        }
        public Rectangle(double width, double height, int startX, int startY, int lineWidth, Color color) : base(startX, startY, lineWidth, color)
        {
            Width = width;
            Height = height;
        }
        public override double GetArea()
        {
            return Width*Height;
        }
        public override double GetPerimiter()
        {
            return Width*2+Height*2;
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color, LineWidth), StartX, StartY, (float)Width, (float)Height);
        }
        public override string ToString()
        {
            string result = "";
            result += $"Width:\t{Width}\n";
            result += $"Heigth:\t{Height}\n";
            result += base.ToString();
            return result;
        }
    }
}
