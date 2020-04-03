using K_Forms2;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Extensions
{
    public static class PointExtensions
    {
        public static Point AddPoints(Point addendum1, Point addendum2) =>
           new Point(addendum1.X + addendum2.X, addendum1.Y + addendum2.Y);

        public static Point AddPoints(params Point[] addendums)
        {
            Point sum = new Point(0, 0);
            foreach (var addendum in addendums)
            {
                sum = AddPoints(addendum, sum);
            }
            return sum;
        }

        public static Point SubtractPoints(Point minuend, Point subtrahend) =>
           new Point(minuend.X - subtrahend.X, minuend.Y - subtrahend.Y);

        public static bool ComparePoints(Point compared1, Point compared2, int error = 0) =>
            !(Math.Abs(compared1.X - compared2.X) > error ||
            Math.Abs(compared1.Y - compared2.Y) > error);
    }

    public static class ControlExtensions
    {
        public static Form GetRootForm(this Control control) =>
            control.GetTreeOfParents().First() as Form;

        public static Control[] GetTreeOfParents(this Control control)
        {
            List<Control> parents = new List<Control>();
            while (true)
            {
                control = control.Parent;
                if (control is null)
                {
                    return parents.ToArray();
                }
                else
                {
                    parents.Insert(0, control);
                }
            }
        }

        public static Point[] GetLocations(this Control[] controls)
        {
            List<Point> points = new List<Point>();
            foreach (var control in controls)
            {
                points.Add(control.Location);
            }
            return points.ToArray();
        }

        public static void PerformPageBtAnimation(this Button pageBt, Button mockBt, FlowLayoutPanel flp)
        {
            pageBt.MoveToControl(mockBt);
            flp.Controls.Remove(mockBt);
            flp.Controls.Add(pageBt);
            flp.Controls.Add(mockBt);
        }

        public static void PerformPageBtAnimation(this Button pageBt, Button mockBt, FlowLayoutPanel flp, double speed)
        {
            pageBt.MoveToControl(mockBt, speed);
            flp.Controls.Remove(mockBt);
            flp.Controls.Add(pageBt);
            flp.Controls.Add(mockBt);
        }
    }
}