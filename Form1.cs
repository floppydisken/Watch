using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Watch1._2
{
    abstract class Timer
    {
        protected const int MillisInSecond = 100;
        protected const int SecondsInMinute = 60;
        protected const int MinutesInHour = 60;

        // Setters should be encapsulated more as to prevent f. ex. seconds to be set to 123412341234
        // Doesnt matter for now. Just keep it in mind.
        public int Hours { get; set; } = 0;
        public int Minutes { get; set; } = 0;
        public int Seconds { get; set; } = 0;
        public int Millis { get; set; } = 0;

        /// This method assumes a tick every millis.
        /// Also this method needs to be implemented by inhereting classes.
        /// This concept is called Polymorphism https://en.wikipedia.org/wiki/Polymorphism_(computer_science)
        public abstract void Tick();

        public void Reset()
        {
            Millis = 0;
            Seconds = 0;
            Minutes = 0;
            Hours = 0;
        }
    }

    class CountUpTimer : Timer
    {

        public override void Tick()
        {
            Millis++;

            if (Millis >= MillisInSecond)
            {
                Seconds++;
                Millis = 0;
            }
            if (Seconds >= SecondsInMinute)
            {
                Minutes++;
                Seconds = 0;
            }
            if (Minutes >= MinutesInHour)
            {
                Hours++;
                Minutes = 0;
            }
        }
    }

    class CountDownTimer : Timer
    {
        public override void Tick()
        {
            Millis--;

            if (Millis >= 0)
            {
                Seconds--;
                Millis = MillisInSecond;
            }
            if (Seconds <= 0)
            {
                Minutes--;
                Seconds = SecondsInMinute;
            }
            if (Minutes <= 0)
            {
                Hours--;
                Minutes = MinutesInHour;
            }
        }
    }

    public partial class Form1 : Form
    {
        Timer countUpTimer = new CountUpTimer();
        Timer countDownTimer = new CountDownTimer();

        bool countUpTimerIsActive;
        bool countDownTimerIsActive;

        public Form1()
        {
            InitializeComponent();
        }

        private void ResetCountUpTimer()
        {
            countUpTimer.Reset();
        }

        private void ResetCountDownTimer()
        {
            countDownTimer.Reset();
        }

        private void TimerStopwatch_Tick(object sender, EventArgs e)
        {
            if (countUpTimerIsActive)
                countUpTimer.Tick();

            DrawTime();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            countUpTimerIsActive = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            countUpTimerIsActive = false;
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            countUpTimerIsActive = false;
            //Funktion til at restarte timerne på stopuret
            ResetCountUpTimer();
        }
        //Sætter det "Reel" ur til nuværene tid og dato.
        private void TimerWatch_Tick(object sender, EventArgs e)
        {
            WatchH.Text = DateTime.Now.ToString("HH");
            WatchM.Text = DateTime.Now.ToString("mm");
            WatchS.Text = DateTime.Now.ToString("ss");
            LblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            LblDay.Text = DateTime.Now.ToString("dddd");
        }

        private void CounterTimer_Tick(object sender, EventArgs e)
        {
            //Checker om den er aktiv, hvis den er, gå ind i if...
            if (countDownTimerIsActive)
            {
                countDownTimer.Tick();
            }
            DrawCountTimer();
        }

        //Counteren/Nedtællerens startknap
        private void TimerStart_Click(object sender, EventArgs e)
        {
            countDownTimerIsActive = true;
        }

        //Lægger 1 til counterH
        private void AddH_Click(object sender, EventArgs e)
        {
            countDownTimer.Hours++;
        }

        //Trækker 1 fra counterH
        private void MinusH_Click(object sender, EventArgs e)
        {
            countDownTimer.Minutes--;
        }

        //Lægger 1 til counterM
        private void AddM_Click(object sender, EventArgs e)
        {
            countDownTimer.Minutes++;
        }

        //Trækker 1 fra counterM
        private void MinusM_Click(object sender, EventArgs e)
        {
            countDownTimer.Minutes--;
        }

        //Lægger 1 til counterS
        private void AddS_Click(object sender, EventArgs e)
        {
            countDownTimer.Seconds++;
        }

        //Trækker 1 fra counterS
        private void MinusS_Click(object sender, EventArgs e)
        {
            countDownTimer.Seconds--;
        }

        //Counteren/Nedtællerens stopknap
        private void TimerStop_Click(object sender, EventArgs e)
        {
            countDownTimerIsActive = false;
        }

        //Counteren/Nedtællerens resetknap
        private void TimerReset_Click(object sender, EventArgs e)
        {
            countDownTimerIsActive = false;
            ResetCountDownTimer();
        }

        //Sætter stopurets decimaler og format
        private void DrawTime()
        {
            TimerMi.Text = String.Format("{0:00}", countUpTimer.Millis);
            TimerS.Text = String.Format("{0:00}", countUpTimer.Seconds);
            TimerM.Text = String.Format("{0:00}", countUpTimer.Minutes);
            TimerH.Text = String.Format("{0:00}", countUpTimer.Hours);
        }

        //Sætter counteren/nedtællerens decimaler og format
        private void DrawCountTimer()
        {
            CounterMS.Text = String.Format("{0:00}", countDownTimer.Millis);
            CounterS.Text = String.Format("{0:00}", countDownTimer.Seconds);
            CounterM.Text = String.Format("{0:00}", countDownTimer.Minutes);
            CounterH.Text = String.Format("{0:00}", countDownTimer.Hours);
        }

        //Selve Formen
        private void Form1_Load(object sender, EventArgs e)
        {
            //ResetTime();

            //isActive = false;
        }

    }
}
