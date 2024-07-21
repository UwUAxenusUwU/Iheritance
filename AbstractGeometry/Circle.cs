using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbstractGeometry
{
    internal class Circle : Shape, IHaveDiameter
    {
        double radius;
        public double Radius
            {
                get { return radius; } 
                set => radius = value < min_size ? min_size : value > max_size? max_size: value;
            }
        public Circle(double radius, int startX, int startY, int lineWidth, System.Drawing.Color color):
            base(startX, startY, lineWidth, color)
        {
            Radius = radius;
        }
        public double GetDiameter()
        {
            return Radius*2;
        }
        public override double GetArea()
        {
            return Math.PI*Math.Pow(Radius, 2);
        }
        public override double GetPerimiter()
        {
            return 2*Math.PI*Radius;
        }
        public override void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(new System.Drawing.Pen(Color, LineWidth), StartX, StartY, (float)GetDiameter(), (float)GetDiameter());
        }
        public override string ToString()
        {
            string result = base.ToString();
            result += $"Radius: {Radius}\n";
            result += $"Diameter: {GetDiameter()}\n";
            return result; 
        }

    }
}
