using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChessWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDragging;
        private Point startPoint;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Image_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            startPoint = e.GetPosition(null);
            var image = sender as Image;
            image.CaptureMouse();
        }

        private void Image_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var image = sender as Image;
                var currentPosition = e.GetPosition(null);
                var offset = startPoint - currentPosition;

                if (e.LeftButton == MouseButtonState.Pressed && Math.Abs(offset.X) > SystemParameters.MinimumHorizontalDragDistance && Math.Abs(offset.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    // Create data object for dragging
                    var dataObject = new DataObject(DataFormats.Serializable, image.Source);
                    DragDrop.DoDragDrop(image, dataObject, DragDropEffects.Move);
                }
            }
        }

        private void Image_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            var image = sender as Image;
            image.ReleaseMouseCapture();
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
