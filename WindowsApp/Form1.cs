using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsApp
{
    public partial class Form1 : Form
    {
        private Stopwatch stopwatch = new Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            stopwatch.Start();
            Task.Run(() => sleep());
            //getnextDay();
            textBox1.Text = stopwatch.ElapsedMilliseconds.ToString();
            MessageBox.Show("Test");

        }

        private  void sleep()
        {
            Thread.Sleep(5000);
        }

        private DateTime getnextDay()
        {
            try
            {
                Thread.Sleep(millisecondsTimeout: 1000 * 5);
                return DateTime.Now;
            }
            catch (Exception)
            {
                //记录操作日志。。。
                return getnextDay();
            }
        }
    }
}
