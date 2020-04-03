using System;
using System.Drawing;
using System.Windows.Forms;
using static Extensions.ControlExtensions;
using static Extensions.PointExtensions;

namespace K_Forms2
{
    public static class Animation
    {
        private const double AnimationSpeed = 0.2;

        /// <summary>
        /// Moves control to specified point with specified speed.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="destination">Location control needs to be moved to</param>
        /// <param name="speed">Coefficient of speed control must move with. Must be bigger than 0 and not bigger than 1.</param>
        private static void MoveToPoint(this Control control, Point destination, double speed = AnimationSpeed)
        {
            const double speedBottomLimit = 0;
            const double speedTopLimit = 1;
            if (speed <= speedBottomLimit || speed > speedTopLimit)
            {
                throw new ArgumentOutOfRangeException(nameof(speed),
                    $"{nameof(speed)} must be bigger than {speedBottomLimit} and less or equal than {speedTopLimit}");
            }

            // if need to be moved by center
            //destination = new Point(destination.X - control.Width / 2, destination.Y - control.Height / 2);

            Point distance = SubtractPoints(destination, control.Location);
            double xInc = 1, yInc = 1;

            if (Math.Abs(distance.X) < Math.Abs(distance.Y) && distance.Y != 0)
            {
                xInc = distance.X / Math.Abs((double)distance.Y);
                yInc = distance.Y / Math.Abs(distance.Y);
            }
            else if (distance.X != 0)
            {
                xInc = distance.X / Math.Abs(distance.X);
                yInc = distance.Y / Math.Abs((double)distance.X);
            }

            double x = control.Location.X;
            double y = control.Location.Y;

            while (!ComparePoints(control.Location, destination, (int)(1 / speed) - 1))
            {
                x += xInc / speed;
                y += yInc / speed;

                control.Location = new Point((int)Math.Round(x), (int)Math.Round(y));
                control.Refresh();
                System.Threading.Thread.Sleep(1);
            }

            control.Location = destination;
        }

        /// <summary>
        /// Moves control to specified control with specified speed.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="destControl">Destintaion control control needs to be moved to</param>
        /// <param name="speed">Coefficient of speed control must move with. Must be bigger than 0 and not bigger than 1.</param>
        public static void MoveToControl(this Control control, Control destControl, double speed = AnimationSpeed)
        {
            Form mainForm = control.GetRootForm();
            var prevLoc = control.Location;
            Point prevParentLocToForm;
            Point destParentLocToForm;
            if (control.Parent is Form) 
            {
                prevParentLocToForm = new Point(0, 0);
            }
            else
            {
                var parents = control.GetTreeOfParents();
                var parentsLocations = parents.GetLocations();
                var parentLocToScreen = AddPoints(parentsLocations);
                var parentLocToForm = SubtractPoints(parentLocToScreen, mainForm.Location);
                prevParentLocToForm = parentLocToForm;
            }
            mainForm.Controls.Add(control);
            control.Location = AddPoints(prevParentLocToForm, prevLoc);
            control.BringToFront();

            if (destControl.Parent is Form)
            {
                destParentLocToForm = new Point(0, 0);
            }
            else
            {
                var parents = destControl.GetTreeOfParents();
                var parentsLocations = parents.GetLocations();
                var parentLocToScreen = AddPoints(parentsLocations);
                var parentLocToForm = SubtractPoints(parentLocToScreen, mainForm.Location);
                destParentLocToForm = parentLocToForm;
            }
            var destLoc = AddPoints(destParentLocToForm, destControl.Location);

            control.MoveToPoint(destLoc, speed);
        }
    }

    public static class Graphic
    {
        private static readonly Random Rnd = new Random();

        public static Color GetRandomLightColor()
        {
            return Color.FromArgb(Rnd.Next(128, 192), Rnd.Next(128, 192), Rnd.Next(128, 192));
        }

        public static Bitmap GetTileWithNumber(int number, Size bitmapSize, Color fore, Color back)
        {
            return GetTileWithString(number.ToString(), bitmapSize, fore, back);
        }

        private static Bitmap GetTileWithString(string str, Size bitmapSize, Color fore, Color back)
        {
            Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.FillRectangle(
                    new SolidBrush(back),
                    new Rectangle(new Point(0, 0), bitmapSize));
                if (str.Length == 1)
                {
                    g.DrawString(
                    str,
                    new Font(FontFamily.GenericSansSerif, bitmapSize.Height, GraphicsUnit.Pixel),
                    new SolidBrush(Color.FromArgb(64, fore.R, fore.G, fore.B)),
                    5f, -5f);
                }
                else if (str.Length == 2)
                {
                    g.DrawString(
                    str,
                    new Font(FontFamily.GenericSansSerif, bitmapSize.Height, GraphicsUnit.Pixel),
                    new SolidBrush(Color.FromArgb(64, fore.R, fore.G, fore.B)),
                    -20f, -5f);
                }
            }
            return bitmap;
        }
    }
}