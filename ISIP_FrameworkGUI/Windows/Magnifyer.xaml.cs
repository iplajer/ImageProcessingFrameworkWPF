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

using Emgu.CV;
using Emgu.CV.Structure;
using ISIP_FrameworkHelpers;

namespace ISIP_FrameworkGUI.Windows
{
    /// <summary>
    /// Interaction logic for Magnifyer.xaml
    /// </summary>
    public partial class Magnifyer : Window
    {
        Image<Gray, byte> InitialImage;
        Image<Gray, byte> ProcessedImage;

        public Magnifyer(Image<Gray, byte> image, Image<Gray, byte> pimage)
        {
            InitializeComponent();
            InitialImage = image;
            ProcessedImage = pimage;
        }
        public void RedrawMagnifyer(Point point)
        {
            OrigMagnif.Children.Clear();
            ProcMagnif.Children.Clear();
            int dim = 9; byte color = 255;
            for (int j = 0; j < dim; j++)
                for (int i = 0; i < dim; i++)
                {
                    int x, y;
                    x = j + (int)point.X - dim / 2;
                    y = i + (int)point.Y - dim / 2;
                    if (x >= 0 && x < InitialImage.Width && y >= 0 && y < InitialImage.Height)
                    {
                        SolidColorBrush br = new SolidColorBrush();
                        color = InitialImage.Data[y, x, 0];

                        Color brush_color = Color.FromRgb(color, color, color);

                        br.Color = brush_color;


                        DrawHelper.DrawAndGetRectangle(OrigMagnif, new Point(j * 25, i * 25), new Point((j + 1) * 25, (i + 1) * 25), br, brush_color, 255);
                        DrawHelper.DrawText(OrigMagnif, color.ToString(), new Point(j * 25 + 2, (i + 1) * 25 - 20), 12, Colors.Red);
                    }
                    else DrawHelper.DrawAndGetRectangle(OrigMagnif, new Point(j * 25, i * 25), new Point((j + 1) * 25, (i + 1) * 25), Brushes.Black, Colors.Black, 255);

                }
            string text = "(" + (int)point.X + "," + point.Y + ")";

            DrawHelper.DrawText(OrigMagnif, text, new Point(OrigMagnif.ActualWidth / 2, OrigMagnif.ActualHeight - 25), 12, Colors.Red);

            if (ProcessedImage != null)
            {

                for (int j = 0; j < dim; j++)
                    for (int i = 0; i < dim; i++)
                    {
                        int x, y;
                        x = j + (int)point.X - dim / 2;
                        y = i + (int)point.Y - dim / 2;
                        if (x >= 0 && x < ProcessedImage.Width && y >= 0 && y < ProcessedImage.Height)
                        {
                            SolidColorBrush br = new SolidColorBrush();
                            color = ProcessedImage.Data[y, x, 0];

                            Color brush_color = Color.FromRgb(color, color, color);

                            br.Color = brush_color;


                            DrawHelper.DrawAndGetRectangle(ProcMagnif, new Point(j * 25, i * 25), new Point((j + 1) * 25, (i + 1) * 25), br, brush_color, 255);
                            DrawHelper.DrawText(ProcMagnif, color.ToString(), new Point(j * 25 + 2, (i + 1) * 25 - 20), 12, Colors.Red);
                        }
                        else DrawHelper.DrawAndGetRectangle(ProcMagnif, new Point(j * 25, i * 25), new Point((j + 1) * 25, (i + 1) * 25), Brushes.Black, Colors.Black, 255);

                    }
            }
        }
    }
}
