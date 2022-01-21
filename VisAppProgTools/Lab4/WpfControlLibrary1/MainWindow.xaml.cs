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

namespace Project1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Canvas[] canvases = new Canvas[3];
        Hippodrome.UserControl_Horse[] horses = new Hippodrome.UserControl_Horse[3];
        DispatcherTimer timer, timerUpdateSpeed;

        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            for(int i = 0; i < 3; i++)
            {
                canvases[i] = new Canvas();
                Grid.SetRow(canvases[i], i);
                grid.Children.Add(canvases[i]);
                horses[i] = new Hippodrome.UserControl_Horse(random.Next(20. 50));
                canvases[i].Children.Add(horses[i]);
            }
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(1000);
           

            timerUpdateSpeed = new DispatherTimer();
            timerUpdateSpeed.Tick += new EventHandler(timerUpdateSpeed_Tick);
            timerUpdateSpeed.Intterval = new TimeSpan(0, 0, 2);

            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                horses[i].XHorse += (float)horses[i].GetSpeed() / 50.0f;
            }
            private void timerUpdateSpeed_Tick(object sender, EventHandler e)
            { 
                for (int i = 0; i < 3; i++) 
            }
        }
        
    }
}
