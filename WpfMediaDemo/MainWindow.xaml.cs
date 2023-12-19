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
using System.Windows.Forms;
namespace WpfMediaPlayer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void b1_Click(object sender, RoutedEventArgs e)
        {
            MediaState ms = MediaState.Play;
            me.LoadedBehavior = ms;
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            MediaState uc = MediaState.Pause;
            me.LoadedBehavior = uc;
        }
        private void b3_Click(object sender, RoutedEventArgs e)
        {
            me.LoadedBehavior = MediaState.Stop;
        }
        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void b5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "MP3 Files (*.mp3)|*.mp3|MP4 File (*.mp4)|*.mp4|3GP File (*.3gp)|*.3gp|Audio File (*.wma)|*.wma|MOV File (*.mov)|*.mov|AVI File (*.avi)|*.avi|Flash Video(*.flv)|*.flv|Video File (*.wmv)|*.wmv|MPEG-2 File (*.mpeg)|*.mpeg|WebM Video (*.webm)|*.webm|All files (*.*)|*.*";
                fd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                fd.ShowDialog();
                string filename = fd.FileName;
                if(filename!="")
                {
                    tb.Text = filename;
                    Uri u = new Uri(filename);
                    me.Source = u;
                    me.Volume = 100.5;
                    MediaState opt = MediaState.Play;
                    me.LoadedBehavior = opt;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("No Selection","Empty");
                }
            }   
            catch(Exception e1)
            {
                System.Console.WriteLine("Error Text: "+e1.Message);
            }
        }
        string videoURL = @"";
        private void window_loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri obj = new Uri(videoURL);
                me.Source = obj;
                MediaState opt = MediaState.Play;
                me.LoadedBehavior = opt;
            }
            catch(Exception ex)
            {
                System.Console.WriteLine("Error Message: "+ex.Message);
            }
        }
    }
}
