using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;
using System.IO;
using GenerativeAI;
namespace AlterEgo
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer synth = new SpeechSynthesizer();

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"Sprites/Ch1.png");
            synth.SetOutputToDefaultAudioDevice();
            synth.SelectVoiceByHints(VoiceGender.Female);
            Console.ForegroundColor = ConsoleColor.Green;
        }

       

        public void RecogniseSpeech()
        {
            SpeechRecognitionEngine sr = new SpeechRecognitionEngine();
            sr.SetInputToDefaultAudioDevice();
            Grammar word = new DictationGrammar();
            sr.LoadGrammar(word);   

           RecognitionResult result = sr.Recognize();
            richTextBox1.Text = result.Text;
            oshit(result.Text);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecogniseSpeech();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button2 clicked");
          
        }

        public async void oshit(string pr)
        {
            var googleAI = new GoogleAi("YOUR API KEY"); // Your API key here
            var model = googleAI.CreateGenerativeModel("gemini-1.5-flash");
            timer1.Enabled = true;
            Console.WriteLine("oshit method called");
            string prompt = pr;
            Console.WriteLine($"Prompt: {prompt}");
            var response = await model.GenerateContentAsync(prompt);


            Console.WriteLine(response.Text());
            richTextBox2.Text = response.Text();
            synth.Speak(response.Text());
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();
            int num = rand.Next(0, 5);
            if (num == 0)
            {
                pictureBox1.Image = Image.FromFile(@"Sprites/Ch1.png");
            }
            else if (num == 1)
            {
                pictureBox1.Image = Image.FromFile(@"Sprites/Ch2.png");
            }
            else if (num == 2)
            {
                pictureBox1.Image = Image.FromFile(@"Sprites/Ch3.png");
            }
            else if (num == 3)
            {
                pictureBox1.Image = Image.FromFile(@"Sprites/Ch4.png");
            }
            else if (num == 4)
            {
                pictureBox1.Image = Image.FromFile(@"Sprites/Ch5.png");
            }
        }
    }
}
