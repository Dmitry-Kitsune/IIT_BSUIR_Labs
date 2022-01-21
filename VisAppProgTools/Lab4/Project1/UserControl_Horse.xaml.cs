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

namespace Hippodrome
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl_Horse : UserControl
    {
        Horse horse;
        public UserControl_Horse()
        {
            InitializeComponent();

            horse = new Horse(speed);

            tetxBlockSpeed.DataCentext = horse;
            Dinding bindingSpeed = new Binding("Speed");
            bindingSpeed.Converter = new SpeedToString();
            textBlockSpeed.SetBinding(TextBlock.TextProperty, bindingSpeed);


            tetxBlockSpeed.DataCentext = horse;
            Dinding bindingSpeed = new Binding("Speed");
            bindingSpeed.Converter = new SpeedToString();
            textBlockSpeed.SetBinding(TextBlock.TextProperty, bindingSpeed);

             this.DataContext = UserControl_Horse;
             this.SetBinding(Canvas.LeftProperty, new Binding("X"));
         }
        public void UpdateSpeed(int speed)
        {
            horse.Speed = speed;
        }
        public int GetSpeed()
        {
            return horse.Speed;
        }
        public void UpdatePosition(int position)
        {
            horse.Position = position;
        }
        public float X
        {

        }
            public bool IsFinish
    }
}
