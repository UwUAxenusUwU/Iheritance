//#define ABSTRACT_CHECK
#define INTERFACE_CHECK
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;       //эта бибилиотека позволит подключать к файлу другие длл файлы и использовать ф-ии из этих длл файлов

namespace AbstractGeometry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntPtr hwnd = GetConsoleWindow();
            Graphics graphics = Graphics.FromHwnd(hwnd);
            System.Drawing.Rectangle window_rectangle = new System.Drawing.Rectangle(Console.WindowLeft, Console.WindowTop, Console.WindowWidth, Console.WindowHeight);
            PaintEventArgs e = new PaintEventArgs(graphics, window_rectangle);
#if ABSTRACT_CHECK
            //Shape shape = new Shape();

            Rectangle rectangle = new Rectangle(100, 80, 100, 200, 5, Color.Red);
            rectangle.Info(e);

            Square square = new Square(80, 100, 350, 9, Color.AliceBlue);
            square.Info(e);

            Circle circle = new Circle(45, 300, 350, 4, Color.Orange);
            circle.Info(e); 
#endif
#if INTERFACE_CHECK

            Shape[] shapes = new Shape[]
            {
                new Square(80, 100, 350, 9, Color.AliceBlue),
                new Rectangle(100, 80, 350, 200, 5, Color.Red),
                new Circle(45, 300, 350, 4, Color.Orange)
            };
            foreach (Shape i in shapes) 
            {
                if (i is IHaveDiagonal)
                i.Info(e);
            }
            //оператор is проверяет объект по признаку "является" и "способен"

#endif
        }
        [DllImport("kernel32.dll")]
        public static extern bool GetStdHandle(int nStdHandle);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetConsoleWindow();
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

    }
}
