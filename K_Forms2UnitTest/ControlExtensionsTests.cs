using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_Forms2;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using Extensions;
using static Extensions.ControlExtensions;

namespace ControlExtensionsTests
{
    [TestClass]
    public class GetRootFormTests
    {
        [TestMethod]
        public void Correct()
        {
            // Arrange
            Form parentForm = new Form();
            TableLayoutPanel tbl = new TableLayoutPanel();
            Panel panel = new Panel();
            Button button = new Button();
            panel.Controls.Add(button);
            tbl.Controls.Add(panel);
            parentForm.Controls.Add(tbl);
            Form expected = parentForm;

            // Act
            Form actual = button.GetRootForm();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Incorrect()
        {
            // Arrange
            TableLayoutPanel tbl = new TableLayoutPanel();
            Panel panel = new Panel();
            Button button = new Button();
            panel.Controls.Add(button);
            tbl.Controls.Add(panel);

            // Act
            Form actual = button.GetRootForm();

            // Assert
            Assert.IsNull(actual);
        }
    }

    [TestClass]
    public class GetTreeOfParentsTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            Form parentForm = new Form();
            TableLayoutPanel tbl = new TableLayoutPanel();
            Panel panel = new Panel();
            Button button = new Button();
            panel.Controls.Add(button);
            tbl.Controls.Add(panel);
            parentForm.Controls.Add(tbl);

            // Act
            Control[] actual = button.GetTreeOfParents();

            // Assert
            CollectionAssert.AreEqual(actual, new Control[] { parentForm, tbl, panel });
        }
    }

    [TestClass]
    public class GetLocationsTests
    {
        [TestMethod]
        public void Test()
        {
            // Arrange
            Button button1 = new Button() { Location = new Point(0, 0) };
            Button button2 = new Button() { Location = new Point(1, 1) };
            Button button3 = new Button() { Location = new Point(2, 2) };
            Button button4 = new Button() { Location = new Point(3, 3) };

            // Act
            Point[] actual = new Control[] { button1, button2, button3, button4 }.GetLocations();

            // Assert
            CollectionAssert.AreEqual(actual, new Point[] 
                { new Point(0, 0), new Point(1, 1), new Point(2, 2), new Point(3, 3) });
        }
    }
}
