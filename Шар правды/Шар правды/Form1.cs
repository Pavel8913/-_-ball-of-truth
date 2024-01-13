using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Шар_правды
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GraphicsPath gp = new GraphicsPath();
            Graphics g = CreateGraphics();
            // Создадим новый прямоугольник с размерами кнопки 
            Rectangle smallRectangle = button1.ClientRectangle;
            // уменьшим размеры прямоугольника 
            smallRectangle.Inflate(-10, -10 );
            // создадим эллипс, используя полученные размеры 
            gp.AddEllipse(smallRectangle);
            button1.Region = new Region(gp);
            // рисуем окантовоку для круглой кнопки 
            g.DrawEllipse(new Pen(Color.Gray, 2),
            button1.Left + 1,
            button1.Top + 1,
            button1.Width - 3,
            button1.Height - 3);
            // освобождаем ресурсы 
            g.Dispose();
            button1.BackColor = Color.DarkSalmon;
            button1.ForeColor = Color.Cornsilk;



        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public static GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            // Верхний левый угол
            path.AddArc(arc, 180, 90);

            // Верхний правый угол
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Нижний правый угол
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Нижний левый угол
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Region = new Region(
                    RoundedRect(
                        new Rectangle(0, 0, this.Width, this.Height)
                        , 10
                    )
                );

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            Random rnd=new Random();
            int value=rnd.Next(0,3);
            if(value==1)
            {
                button1.ForeColor = Color.Green;
                button1.Text = "Да";
            }
            if(value==2)
            {
                button1.ForeColor = Color.Red;
                button1.Text = "Нет";
            }
            if (value==0)
            {
                button1.ForeColor = Color.White;
                button1.Text = "Спросите ещё раз";
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
           
            using (Graphics g = Graphics.FromImage(button1.Image))
            {
                g.Clear(Color.DarkSalmon);
            }
        }
        int iFormX, iFormY, iMouseX, iMouseY;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            iFormX = this.Location.X;
            iFormY = this.Location.Y;
            iMouseX = MousePosition.X;
            iMouseY = MousePosition.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            int iMouseX2 = MousePosition.X;
            int iMouseY2 = MousePosition.Y;
            if (e.Button == MouseButtons.Left)
                this.Location = new Point(iFormX + (iMouseX2 - iMouseX), iFormY + (iMouseY2 - iMouseY));
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            if (button1.Image == null) button1.Image = new Bitmap(button1.Width, button1.Height);
            using (Graphics g = Graphics.FromImage(button1.Image))
            {
                g.Clear(Color.Coral);
            }
        }
    }
}
