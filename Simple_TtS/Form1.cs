using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;

namespace WindowsFormsApplication8
{
    public partial class Form1 :MetroFramework.Forms.MetroForm
    {
        SpeechSynthesizer voice;
        public Form1()
        {
            InitializeComponent();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            voice = new SpeechSynthesizer();
            voice.SelectVoiceByHints(VoiceGender.Male);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            
                switch (cb.SelectedIndex) {
                    case 0:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                    case 1:
                        voice.SelectVoiceByHints(VoiceGender.Female);
                        break;
                    case 2:
                        voice.SelectVoiceByHints(VoiceGender.Neutral);
                        break;
                    default:
                        voice.SelectVoiceByHints(VoiceGender.Male);
                        break;
                }
            
            voice.SpeakAsync(txt.Text);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Pause();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            try
            {
                voice.Resume();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog svf = new SaveFileDialog()) {
                    svf.Filter = "Wav files|*.wav";

                    if (svf.ShowDialog() == DialogResult.OK) {
                        FileStream fs = new FileStream(svf.FileName,FileMode.Create, FileAccess.Write);
                        voice.SetOutputToWaveStream(fs);
                        voice.Speak(txt.Text);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb.SelectedIndex) {
                case 0:
                    voice.SelectVoiceByHints(VoiceGender.Male);
                    break;
                case 1:
                    voice.SelectVoiceByHints(VoiceGender.Female);
                    break;
                case 2:
                    voice.SelectVoiceByHints(VoiceGender.Neutral);
                    break;
            }
        }
    }
}
