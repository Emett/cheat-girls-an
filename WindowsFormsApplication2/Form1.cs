using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Permissions;

using System.Runtime.InteropServices;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ExtendedWebBrowser.CheatGirlsInit();
            Stop = true;
            StopToggle();
            DisableClickSounds();
        }

        delegate void SetTextCallback(List<int> l);

        public void SetList(List<int> l)
        {
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetList);
                this.Invoke(d, new object[] { l });
            }
            else {
                textBox1.Text = l[0].ToString();
                textBox2.Text = l[1].ToString();
                textBox3.Text = l[2].ToString();
                textBox4.Text = l[3].ToString();
                allBox.Text = l.Last().ToString();
            }
        }

        const int FEATURE_DISABLE_NAVIGATION_SOUNDS = 21;
        const int SET_FEATURE_ON_PROCESS = 0x00000002;

        [DllImport("urlmon.dll")]
        [PreserveSig]
        [return: MarshalAs(UnmanagedType.Error)]
        static extern int CoInternetSetFeatureEnabled(
            int FeatureEntry,
            [MarshalAs(UnmanagedType.U4)] int dwFlags,
            bool fEnable);

        static void DisableClickSounds()
        {
            CoInternetSetFeatureEnabled(
                FEATURE_DISABLE_NAVIGATION_SOUNDS,
                SET_FEATURE_ON_PROCESS,
                true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Stop";
            webBrowser1.UserAgent = //@"Mozilla/5.0 (Windows NT 6.1; WOW64; rv:15.0) Gecko/20120427 Firefox/15.0a1";
                @"Mozilla/5.0 (Windows NT 6.2; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/32.0.16670 Safari/537.36";
            //@"Mozilla/5.0 (iPhone; U; CPU iPhone OS 4_3_2 like Mac OS X; en-us) AppleWebKit/533.17.9 (KHTML, like Gecko) Version/5.0.2 Mobile/8H7 Safari/6533.18.5";
            //@"Mozilla/5.0 (iPad; U; CPU OS 3_2 like Mac OS X; en-us) AppleWebKit/531.21.10 (KHTML, like Gecko) Version/4.0.4 Mobile/7B334b Safari/531.21.10";
            var thr = new Thread(new ThreadStart(() => {
                
                while (true)
                {
                    if (Stop) continue;
                
                    if (ExtendedWebBrowser.doingPageLoaded == 0 && ExtendedWebBrowser.logged == 1)
                    {
                        webBrowser1.Navigate(ExtendedWebBrowser.needUrl);
                    }
                   Thread.Sleep(300);


                   SetList(ExtendedWebBrowser.CurAllGirls.Zip(ExtendedWebBrowser.ModuloGirls, (x, y) => (x+y-1)/ y)
                       .ToList().Concat(new List<int>(new int[] { ExtendedWebBrowser.All })).ToList());
                    /*textBox1.Text = ExtendedWebBrowser.All.ToString();
                    textBox2.Text = ExtendedWebBrowser.Che.ToString();*/
                }
                
            }));
            thr.Start();
            

            
            
        }
        const string DefaultTimerBoxString = "20:00";
        const int DefaultLeftToStop = 300;

        public bool Stop = false;
        int LeftToStop = DefaultLeftToStop;

        void StopToggle()
        {
            Stop = !Stop;
            if (Stop)
            {
                button1.Text = "Go!";
                timer1.Enabled = true;
                timer2.Enabled = false;
            }
            else
            {
                button1.Text = "Stop";
                timerBox.Text = DefaultTimerBoxString;
                timer1.Enabled = false;
                timer2.Enabled = true;
                LeftToStop = DefaultLeftToStop;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            StopToggle();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Stop)
            {
                var tm = new TimeSpan(0,
                    Convert.ToInt32(timerBox.Text.Split(':').First().ToString()),
                    Convert.ToInt32(timerBox.Text.Split(':').Last().ToString()));
                var sec = new TimeSpan(0,0,1);
                var zero = new TimeSpan(0,0,0);
                tm = tm.Subtract(sec);
                if (tm == zero) StopToggle();
                else timerBox.Text = String.Format("{0:00}:{1:00}",tm.Minutes,tm.Seconds);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LeftToStop--;
            if (LeftToStop == 0) StopToggle();
        }

    }
}
