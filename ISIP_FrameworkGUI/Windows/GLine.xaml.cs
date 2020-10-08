using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ISIP_FrameworkHelpers;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ISIP_FrameworkGUI.Windows
{
    /// <summary>
    /// Interaction logic for GLine.xaml
    /// </summary>
    public partial class GLine : Window
    {
        Image<Gray, byte> InputImage;
        Image<Gray, byte> PrelImage;
        public GLine(Image<Gray, byte> image, Image<Gray, byte> pimage)
        {

            InitializeComponent();
            InputImage = image;
            PrelImage = pimage;
        }
        public void Redraw(int row)
        {
            List<Point> glevels = new List<Point>();
            List<Point> glevels2 = new List<Point>();
            GL_ROW.Children.Clear();

            for (int x = 0; x < InputImage.Width; x++)
            {

                glevels.Add(new Point(x, GL_ROW.ActualHeight - 10 - InputImage.Data[row, x, 0]));

            }
            DrawHelper.DrawAndGetPolyline(GL_ROW, glevels, Brushes.Red, 1);
            if (PrelImage != null)
            {
                for (int x = 0; x < PrelImage.Width; x++)
                {
                    glevels2.Add(new Point(x, GL_ROW.ActualHeight - 10 - PrelImage.Data[row, x, 0]));
                }

                DrawHelper.DrawAndGetPolyline(GL_ROW, glevels2, Brushes.Blue, 1);
            }
        }
    }
}
