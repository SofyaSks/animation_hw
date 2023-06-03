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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace animation_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cubic.Opacity = 1;
            

        }

        DoubleAnimation animation = new DoubleAnimation();

        private void ButtonClickFlashing(object sender, RoutedEventArgs e)
        {

            animation.From = 1;
            animation.To = 0.25;           
            animation.Duration = TimeSpan.FromMilliseconds(50);
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(30);
            cubic.BeginAnimation(Image.OpacityProperty, animation);

        }

        private void Button_Click_Pulse(object sender, RoutedEventArgs e)
        {
            animation.From = cubic.ActualWidth;
            animation.To = cubic.ActualWidth + 50;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(3);
            cubic.BeginAnimation(Image.WidthProperty, animation);
        }

        private void Button_Click_Rotate(object sender, RoutedEventArgs e)
        {

            animation.To = 360;
            animation.Duration = TimeSpan.FromSeconds(2);
            animation.RepeatBehavior = new RepeatBehavior(3);

            Storyboard storyboard = new Storyboard();
            cubic.RenderTransform = new RotateTransform();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, cubic);
            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.Angle"));
            storyboard.Begin();
            
        }

        private void Button_Click_Pendulum(object sender, RoutedEventArgs e)
        {
            animation.From = 1;
            animation.To = 90;
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.AutoReverse = true;
            animation.RepeatBehavior = new RepeatBehavior(3);

            Storyboard storyboard = new Storyboard();
            cubic.RenderTransform = new RotateTransform();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, cubic);
            Storyboard.SetTargetProperty(animation, new PropertyPath("RenderTransform.Angle"));
            storyboard.Begin();
        }

        private void Button_Click_Flattening(object sender, RoutedEventArgs e)
        {

            Storyboard storyboard = new Storyboard();
            DoubleAnimationUsingKeyFrames anim = new DoubleAnimationUsingKeyFrames();
            LinearDoubleKeyFrame linearDoubleKeyFrame1 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame linearDoubleKeyFrame2 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame linearDoubleKeyFrame3 = new LinearDoubleKeyFrame();
            LinearDoubleKeyFrame linearDoubleKeyFrame4 = new LinearDoubleKeyFrame();

            anim.Duration = TimeSpan.FromSeconds(8);

            linearDoubleKeyFrame1.Value = cubic.ActualWidth;
            linearDoubleKeyFrame1.KeyTime = TimeSpan.FromSeconds(0);
            linearDoubleKeyFrame2.Value = 200;
            linearDoubleKeyFrame2.KeyTime = TimeSpan.FromSeconds(1);
            linearDoubleKeyFrame3.Value = cubic.ActualWidth;
            linearDoubleKeyFrame3.KeyTime = TimeSpan.FromSeconds(2);
            linearDoubleKeyFrame4.Value = 200;
            linearDoubleKeyFrame4.KeyTime = TimeSpan.FromSeconds(3);


            anim.KeyFrames.Add(linearDoubleKeyFrame1);
            anim.KeyFrames.Add(linearDoubleKeyFrame2);
            anim.KeyFrames.Add(linearDoubleKeyFrame3);
            anim.KeyFrames.Add(linearDoubleKeyFrame4);

            storyboard.Children.Add(anim);
            Storyboard.SetTarget(anim, cubic);
            Storyboard.SetTargetProperty(anim, new PropertyPath(Image.WidthProperty));
            
            storyboard.Begin();

        }
    }
}
