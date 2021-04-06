using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using DevExpress.Xpf.Core;

namespace QLTX
{
    /// <summary>
    /// Interaction logic for goodbyeScreen.xaml
    /// </summary>
    public partial class goodbyeScreen : SplashScreenWindow
    {
        DispatcherTimer dt = new DispatcherTimer();
        frmMain mh = new frmMain();
        public goodbyeScreen()
        {
            InitializeComponent();
            dt.Tick += new EventHandler(dt_tick);
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Start();
        } // Tự động đếm khi form mở
        private void dt_tick(object sender, EventArgs e)
        {
            dt.Start();
            Close();
            dt.Stop();
            Close();
        } // Thời gian tắt


    }
}
