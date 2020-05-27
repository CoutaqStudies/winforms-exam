using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsExam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
     
        }
        String currentFile;
        bool playing = false;
        WaveOutEvent wo = new WaveOutEvent();
        public void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            if (fbd.ShowDialog() == DialogResult.OK && (fbd.FileName.EndsWith("mp3")|| fbd.FileName.EndsWith("wav") || fbd.FileName.EndsWith("aac")))
            {
                currentFile = fbd.FileName;
                label2.Text = fbd.FileName.Substring(fbd.FileName.LastIndexOf("\\")+1);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var mf = new MediaFoundationReader(currentFile);
            if (playing)
            {
                wo.Pause();
                button3.Text = "Play";
                playing = false;
            }
            else
            {
                {
                    try
                    {
                        wo.Init(mf);
                    }
                    catch
                    {

                    }
                    wo.Play();
                    if (wo.PlaybackState == PlaybackState.Playing)
                    {
                        button3.Text = "Pause";
                    }
                    playing = true;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made by Michael Melikov IVT-1 \n2020");
        }
    }
}
