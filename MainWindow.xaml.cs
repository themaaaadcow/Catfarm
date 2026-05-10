using System.Windows;
using System;
using System.Windows.Media.Imaging;
using System.Windows.Input;

namespace CatFarm
{
    public partial class MainWindow : Window
    {
        private Pet _pet;
            
        public MainWindow()
        {
            InitializeComponent();
            PetImage.Source = new BitmapImage(new Uri("pack://application:,,,/Assets/idle_1.png"));

            _pet = new Pet(PetImage, this);
            _pet.Start();

        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _pet.Movement.IsDragging = true;

            Point mouse = e.GetPosition(this);

            _pet.Movement.StartDrag(mouse);

            CaptureMouse();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (_pet.Movement.IsDragging)
            {
                Point screenPos = PointToScreen(e.GetPosition(this));

                _pet.Movement.Drag(screenPos);
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _pet.Movement.EndDrag();

            ReleaseMouseCapture();
        }
    }
}