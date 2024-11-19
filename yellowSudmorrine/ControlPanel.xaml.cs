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
using System.Windows.Shapes;

namespace yellowSudmorrine
{
    /// <summary>
    /// Логика взаимодействия для ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        private System.Windows.Threading.DispatcherTimer _moveTimer;
        private System.Windows.Threading.DispatcherTimer _downTimer;

       
        public Submarine CurrentSubmarine
        {
            get { return (Submarine)GetValue(CurrentSubmarineProperty); }
            set { SetValue(CurrentSubmarineProperty, value); }
        }

        public static readonly DependencyProperty CurrentSubmarineProperty =
            DependencyProperty.Register("CurrentSubmarine", typeof(Submarine), typeof(ControlPanel),
                new PropertyMetadata(null, OnCurrentSubmarineChanged));


        private static void OnCurrentSubmarineChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var controlPanel = (ControlPanel)d;
            controlPanel.UpdateBindings();
        }


        public ControlPanel(MainWindow mainWindow)
        {
            InitializeComponent();

            // Привязки
            Binding speedBinding = new Binding("Speed")
            {
                Source = CurrentSubmarine,
                Mode = BindingMode.OneWay
            };
            speedLabel.SetBinding(ContentProperty, speedBinding);

            Binding speedBinding_Y = new Binding("DownSpeed")
            {
                Source = CurrentSubmarine,
                Mode = BindingMode.OneWay
            };
            YSpeed.SetBinding(ContentProperty, speedBinding_Y);

            Binding deepBinding = new Binding("Deep")
            {
                Source = CurrentSubmarine,
                Mode = BindingMode.OneWay
            };
            DeepLabel.SetBinding(ContentProperty, deepBinding);

            Binding positionBinding_X = new Binding("Position")
            {
                Source = CurrentSubmarine,
                Mode = BindingMode.OneWay
            };
            XCoord.SetBinding(ContentProperty, positionBinding_X);

    
        }

        private void UpdateBindings()
        {
            if (CurrentSubmarine != null)
            {
                BindingOperations.SetBinding(speedLabel, ContentProperty, new Binding("Speed")
                {
                    Source = CurrentSubmarine,
                    Mode = BindingMode.OneWay
                });

                BindingOperations.SetBinding(YSpeed, ContentProperty, new Binding("DownSpeed")
                {
                    Source = CurrentSubmarine,
                    Mode = BindingMode.OneWay
                });

                BindingOperations.SetBinding(DeepLabel, ContentProperty, new Binding("Deep")
                {
                    Source = CurrentSubmarine,
                    Mode = BindingMode.OneWay
                });

                BindingOperations.SetBinding(XCoord, ContentProperty, new Binding("Position")
                {
                    Source = CurrentSubmarine,
                    Mode = BindingMode.OneWay
                });
            }
        }




        private void ChangeSpeed_Plus(object sender, RoutedEventArgs e)
        {
            if (CurrentSubmarine == null) return;
            CurrentSubmarine.Speed += 2;
        }

        private void ChangeSpeed_Minus(object sender, RoutedEventArgs e)
        {
            if (CurrentSubmarine == null) return;
            CurrentSubmarine.Speed -= 2;
        }

        private void ChangeDeep_Down(object sender, RoutedEventArgs e)
        {
            if (CurrentSubmarine == null) return;
            CurrentSubmarine.DownSpeed += 2;
        }

        private void ChangeDeep_Up(object sender, RoutedEventArgs e)
        {
            if (CurrentSubmarine == null) return;
            CurrentSubmarine.DownSpeed -= 2;
        }

        private void Handbrake(object sender, RoutedEventArgs e)
        {
            if (CurrentSubmarine == null) return;
            CurrentSubmarine.Speed = 0;
            CurrentSubmarine.DownSpeed = 0;
        }
    }


}
