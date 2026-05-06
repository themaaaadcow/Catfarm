using System.Windows;
using System;
using System.Windows.Media.Imaging;

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
    }
}