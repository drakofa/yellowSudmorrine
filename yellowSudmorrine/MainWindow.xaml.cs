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
using System.ComponentModel;

namespace yellowSudmorrine
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool is_control_panel = false;

      

        public MainWindow()
        {
            InitializeComponent();
        }
        public Submarine SelectedSubmarine
        {
            get { return (Submarine)GetValue(SelectedSubmarineProperty); }
            set { SetValue(SelectedSubmarineProperty, value); }
        }
        public static readonly DependencyProperty SelectedSubmarineProperty =
    DependencyProperty.Register("SelectedSubmarine", typeof(Submarine), typeof(MainWindow));
        private void OnSubmarineClicked(object sender, RoutedEventArgs e)
        {
            SelectedSubmarine = sender as Submarine;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            Submarine submarine = new Submarine();
            submarine.Width = 80;
            submarine.Height = 45;
            submarine.MouseLeftButtonDown += OnSubmarineClicked;
            Canvas.SetLeft(submarine, 100); 
            Canvas.SetTop(submarine, 100);  
            myCanvas.Children.Add(submarine);
            if (!is_control_panel)
            {
                ControlPanel controlPanel = new ControlPanel(this);
                Binding selectedSubmarineBinding = new Binding("SelectedSubmarine")
                {
                    Source = this,
                    Mode = BindingMode.TwoWay
                };
                controlPanel.SetBinding(ControlPanel.CurrentSubmarineProperty, selectedSubmarineBinding);
                controlPanel.Show();
                is_control_panel = !is_control_panel;
            }
        }
    }
}
