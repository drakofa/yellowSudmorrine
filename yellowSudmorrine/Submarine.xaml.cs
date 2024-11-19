using System;
using System.Windows;
using System.Windows.Controls;
using System.Timers;
using System.Windows.Threading; 

namespace yellowSudmorrine
{
    /// <summary>
    /// Логика взаимодействия для Submarine.xaml
    /// </summary>
    /// 

    public partial class Submarine : UserControl 
    {
        private const int MinX = 0;
        private const int MaxX = 714;
        private const int MinY = 66;
        private const int MaxY = 370;

        private System.Windows.Threading.DispatcherTimer _moveTimer;

        public int DownSpeed
        {
            get { return (int)GetValue(DownSpeedProperty); }
            set { SetValue(DownSpeedProperty, value); }
        }

        public static readonly DependencyProperty DownSpeedProperty =
            DependencyProperty.Register("DownSpeed", typeof(int), typeof(Submarine), new PropertyMetadata(0));
        public int Position
        {
            get { return (int)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(int), typeof(Submarine), new PropertyMetadata(100, OnPositionChanged));
        public int PositionY
        {
            get { return (int)GetValue(PositionYProperty); }
            set { SetValue(PositionYProperty, value); }
        }

        public static readonly DependencyProperty PositionYProperty =
            DependencyProperty.Register("PositionY", typeof(int), typeof(Submarine),
                new PropertyMetadata(100, OnPositionYChanged));
        private static void OnPositionYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var submarine = d as Submarine;
            int newTop = (int)e.NewValue;

            // Устанавливаем позицию на Canvas
            Canvas.SetTop(submarine, newTop);

            // Обновляем глубину: чем ниже, тем больше значение Deep
            submarine.Deep = newTop;
        }
        private static void OnPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var submarine = d as Submarine;
            int newLeft = (int)e.NewValue;
            Canvas.SetLeft(submarine, newLeft);
        }




        // Dependency Property для Speed
        public int Speed
        {
            get { return (int)GetValue(SpeedProperty); }
            set { SetValue(SpeedProperty, value); }
        }

        public static readonly DependencyProperty SpeedProperty =
            DependencyProperty.Register("Speed", typeof(int), typeof(Submarine), new PropertyMetadata(0));

        // Dependency Property для Deep
        public int Deep
        {
            get { return (int)GetValue(DeepProperty); }
            set { SetValue(DeepProperty, value); }
        }

        public static readonly DependencyProperty DeepProperty =
            DependencyProperty.Register("Deep", typeof(int), typeof(Submarine), new PropertyMetadata(0));

       

        public Submarine()
        {
           
            InitializeComponent();

            _moveTimer = new System.Windows.Threading.DispatcherTimer();
            _moveTimer.Interval = TimeSpan.FromMilliseconds(50);
            _moveTimer.Tick += (s, e) => MoveSubmarine();
            _moveTimer.Tick += (s, e) => MoveDown();
            _moveTimer.Start();

        }
        private void MoveSubmarine()
        {
            int newPosition = this.Position + this.Speed;

            
            if (newPosition >= MinX && newPosition <= MaxX)
            {
                this.Position = newPosition;
            }
            else
            {
                this.Speed = 0;
            }
        }
        public void MoveDown()
        {
            
            int newPositionY = this.PositionY + this.DownSpeed;

            if (newPositionY >= MinY && newPositionY <= MaxY)
            {
                this.PositionY = newPositionY;
            }
            else
                this.DownSpeed = 0;
            
        }

    }
}
