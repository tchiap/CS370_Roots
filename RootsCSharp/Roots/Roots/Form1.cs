using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Roots
{
    public partial class Form1 : Form
    {
        private string laughString;
        private int NR_THREADS = 2;
        private String[] laugh_text = { "0", "1", "2" };
        Semaphore s = new Semaphore(1, 1);
        int j = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread current = Thread.CurrentThread;
            current.Name = laugh_text[NR_THREADS];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            laughString = "";

            Thread[] threads = new Thread[NR_THREADS];
            for (int i=0; i<NR_THREADS; i++)
            {
                threads[i] = new Thread(this.laugh);
                threads[i].Name = laugh_text[i];
            }
            foreach (Thread t in threads)
               t.Start();

            for (int i = 0; i < 4; i++)
            {
                laugh();
            }

            Console.WriteLine(laughString);
            //this.listBox.Items.Add(laughString);
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.listBox.Items.Add("Hello There!");
        }

        //  Can change NR_THREADS > 2 and can change 20 below to 200
        public void laugh()
        {
            String newline = "\r\n";
            //laughString += Thread.CurrentThread.GetHashCode() + ":"; 
            // Print 3 lines of 20 laughs each
            //for (int i = 0; i<4; i++) {
                s.WaitOne();
                //Console.Write(Thread.CurrentThread.GetHashCode() + ":");
                // Increment to 100 or more and press Enter in quick succession
                for (; j<2000; j++) 
                {
                  //Console.Write(Thread.CurrentThread.Name + " ");
                  laughString += "T"+Thread.CurrentThread.Name+":";
                  laughString += "V"+j+"="+Math.Sqrt((double)j)+newline;
                }

                
                //Console.WriteLine();
                s.Release();
                laughString += newline;
            //}
        }
    }
}