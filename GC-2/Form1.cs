using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace GC_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //E1(e);
            //E2(e);
            Att(e);
        }
        private  void E1(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Random rnd=new Random();
            int n=rnd.Next(100,200);
            Pen p=new Pen(Color.Black,3);
            int d = rnd.Next(30, 50);
            int x = rnd.Next(10, this.ClientSize.Width - 10);
            int y=rnd.Next(10, this.ClientSize.Height - 10);
            Point q=new Point(x,y);
            p.Color = Color.Yellow;
            g.DrawEllipse(p, x, y, 4, 4);
            p.Color = Color.Black;
            for(int i = 0; i < n; i++)
            {
                x = rnd.Next(10, this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                double d1 = Math.Sqrt(Math.Pow(x - q.X, 2) + Math.Pow(y - q.Y, 2));
                if (d1 <= d)
                {
                    p.Color = Color.Red;
                    g.DrawEllipse(p, x, y, 4, 4);
                    p.Color = Color.Blue;
                    g.DrawLine(p, x, y, q.X, q.Y);
                    p.Color = Color.Black;
                }
                else g.DrawEllipse(p, x, y, 4, 4);
            }
        }
        private void E2(PaintEventArgs e) 
        {
            Graphics g = e.Graphics;
            Random rnd = new Random();
            Pen p = new Pen(Color.Black, 3);
            int n = 7;
            Point[] points = new Point[n];
            int x, y;
            for(int i = 0; i < n; i++)
            {
                x=rnd.Next(10,this.ClientSize.Width - 10);
                y = rnd.Next(10, this.ClientSize.Height - 10);
                points[i]=new Point(x,y);
                g.DrawEllipse(p,x,y, 3, 3);
            }
            double amin=int.MaxValue;
            Point min1=new Point(0,0),min2=new Point(0,0),min3=new Point(0,0);

            for(int i=0;i<points.Length; i++)
            {
                for(int j = i+1; j < points.Length; j++)
                {
                    for(int k = j+1; k < points.Length; k++)
                    {
                        double d = (points[i].X * points[j].Y) + (points[j].X * points[k].Y) + (points[i].Y * points[k].X) - (points[j].Y * points[k].X) - (points[k].Y * points[i].X) - (points[j].X * points[i].Y);
                        d = 0.5 * Math.Abs(d);
                        if(d < amin)
                        {
                            amin=d;
                            min1 = points[i];
                            min2=points[j];
                            min3=points[k];
                        }
                    }
                }
            }
            p.Color = Color.Blue;
            g.DrawLine(p,min1.X,min1.Y,min2.X,min2.Y);
            g.DrawLine(p, min2.X, min2.Y, min3.X, min3.Y);
            g.DrawLine(p, min1.X, min1.Y, min3.X, min3.Y);
        }
        private void E3(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p=new Pen(Color.Black,3);
            Random rnd=new Random();
            int n = 25;
            Point[] points=new Point[n];
            for(int i = 0; i < n; i++)
            {
                int x = rnd.Next(10, this.ClientSize.Width - 10);
                int y= rnd.Next(10,this.ClientSize.Height - 10);
                points[i]=new Point(x,y);
                g.DrawEllipse(p, x, y, 3, 3);
            }
            float min = float.MaxValue;
            float xc=0,yc=0,r=0,retainedr=0;
            float t=0, q=0;
            for(int i = 0; i < n; i++)
            {
                for(int j = i+1; j < n; j++)
                {
                    for(int k = j+1; k < n; k++)
                    {
                        
                        float q1 = points[j].Y - points[i].Y,q2=points[j].X-points[i].X,q3;       
                        float ma =q1 / q2;
                        q1=points[k].Y - points[j].Y;
                        q2=points[k].X - points[j].X;
                        float mb = q1/ q2;
                        q1 = points[i].Y - points[k].Y;
                        q2 = points[i].X + points[j].X;
                        q3 = points[j].X + points[k].X;
                        xc = ma*mb*q1+mb*q2-ma*q3;
                        q1 = mb - ma;
                        q1 = 2 * q1;
                        xc = xc / q1;
                        q1 = points[i].X + points[j].X;
                        q1 = q1 / 2;
                        q1 = xc - q1;
                        q2 = points[i].Y + points[j].Y;
                        q2 = q2 / 2;
                        yc = q1 / ma;
                        yc = yc * -1;
                        yc = yc + q2; 
                        r = (float)Math.Sqrt(Math.Pow(xc - points[i].X,2)+Math.Pow(yc - points[i].Y,2));
                        float area = (float)(Math.PI*Math.Pow(r,2));
                        if (area < min) { min = area;
                            t = xc - r;
                            q = yc - r;
                            retainedr = r;
                        }
                    }              
                }
            }
            p.Color = Color.Red;
            g.DrawEllipse(p,t+retainedr,q+retainedr,4,4); 
            p.Color= Color.Blue;
            float width = 2 * retainedr;
            g.DrawEllipse(p,t,q,width,width);

            
        }
        private void Att(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Pen p = new Pen(Color.Black, 3);
            Random rnd = new Random();
            int n = 100;
            Point[] points = new Point[n];
            for (int i = 0; i < n; i++)
            {
                int x = rnd.Next(100, this.ClientSize.Width - 100);
                int y = rnd.Next(100, this.ClientSize.Height - 100);
                points[i] = new Point(x, y);
                graphics.DrawEllipse(p,x,y,4,4);    
            }
            long xc = 0, yc = 0;
            for (int i = 0; i < n; i++)
            {
                xc += points[i].X;
                yc += points[i].Y;
            }
            xc = xc / n; yc = yc / n;
            p.Color=Color.Red;
            graphics.DrawEllipse(p,xc,yc,4,4);
            double lmax = 0, l = 0;
            for (int i = 0; i < n; i++)
            {
                l = Math.Sqrt(Math.Pow(xc - points[i].X, 2) + Math.Pow(yc - points[i].Y, 2));
                if (lmax < l) lmax = l;
            }
            graphics.DrawEllipse(p, (int)((int) xc - lmax), (int)((int) yc - lmax), (int)((int)2 * lmax), (int)((int)2 * lmax));
        }
        private void Att2(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p=new Pen(Color.Black, 2);
            Random rnd=new Random();
            int n = 100;
            Point[] points = new Point[n];
            int xmin=int.MaxValue, xmax=int.MinValue, ymin=int.MaxValue, ymax=int.MinValue; 
            for(int i=0;i<n;i++)
            {
                int x=rnd.Next(100,this.ClientSize.Width-100);
                int y=rnd.Next(100,this.ClientSize.Height-100);
                if (x > xmax) { xmax = x;
                    ymax = y;
                }
                if (x < xmin) { ymin = y;
                    xmin = x;
                }
                points[i]=new Point(x,y);
                g.DrawEllipse(p,x,y,4,4);
            }
            int xc = xmax + xmin;
            xc /= 2;
            int yc = ymax + ymin;
            yc /= 2;
            p.Color= Color.Red;
            g.DrawEllipse(p,xc,yc,4,4); 
            float r=(float)Math.Sqrt(Math.Pow(xc-xmax,2)+Math.Pow(yc-ymax,2));
            g.DrawEllipse(p,xc-r,yc-r,2*r,2*r);
        }

    }
}