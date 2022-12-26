using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
namespace bomberman
{
    
    public partial class MainWindow : Window
    {

        DispatcherTimer bomb_timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(Window), UIElement.KeyDownEvent, new KeyEventHandler(LittleHuman_KeyDown));      //capture key down events
            EventManager.RegisterClassHandler(typeof(Window), UIElement.KeyDownEvent, new KeyEventHandler(bomb_KeyDown));

            bomb_timer.Interval = TimeSpan.FromSeconds(3);
            bomb_timer.Tick += bomb_KeyDown;   // set the event of the timer

            TextBox.Text = HasShutdownStarted.ToString();
            

        }
        private static IList<DispatcherTimer> place_timer = new List<DispatcherTimer>();
        public event EventHandler ShutdownFinished;
        
        public bool HasShutdownStarted { get; }
        private void bomb_KeyDown(object sender, EventArgs e)
        {
            bomb_timer.Start();
            bomb.Visibility = Visibility.Hidden;
            double x = Canvas.GetLeft(LittleHuman);
            double y = Canvas.GetTop(LittleHuman);

            //while ()
            {
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    Canvas.SetLeft(bomb, x);
                    Canvas.SetTop(bomb, y);
                    bomb.Visibility = Visibility.Visible;

                }
                lblSeconds.Content = DateTime.Now.Second;
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private void LittleHuman_KeyDown(object sender, KeyEventArgs e)
        {
                double x = Canvas.GetLeft(LittleHuman);
                double y = Canvas.GetTop(LittleHuman);

                switch (e.Key)
                {
                    case Key.Left: Canvas.SetLeft(LittleHuman, x - 5);; break;
                    case Key.Right: Canvas.SetLeft(LittleHuman, x + 5); break;
                    case Key.Up: Canvas.SetTop(LittleHuman, y - 5); break;
                    case Key.Down: Canvas.SetTop(LittleHuman, y + 5); break;
                }
        }


        /*        public void bomb_KeyDown(object sender, KeyEventArgs e)
                {
                    bomb.Visibility = Visibility.Hidden;
                    double x = Canvas.GetLeft(LittleHuman);
                    double y = Canvas.GetTop(LittleHuman);

                    if (e.Key == Key.Space)   //Keyboard.IsKeyDown(Key.Space)
                    {
                        Canvas.SetLeft(bomb, x);
                        Canvas.SetTop(bomb, y);
                        bomb.Visibility= Visibility.Visible;
                    }
                }*/

    }
}
