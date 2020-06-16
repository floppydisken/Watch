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
    public partial class Form1 : Form
    {
        //Variabler for Stopuret
        int timeH, timeM, timeS, timeMi;
        //Variabler for Counteren/Nedtælleren
        int counterH, counterM, counterS, counterMS;
        //Bool for stopur
        bool isActive;
        //Bool for Counter/Nedtælleren
        bool counterActive;

        //Funktion til at restarte timerne på stopuret
        private void ResetTime()
        {
            timeH = 0;
            timeM = 0;
            timeS = 0;
            timeMi = 0;
        }
        //Funktion til at restarte timerne på Counteren/Nedtælleren
        private void CounterReset()
        {
            counterH = 0;
            counterM = 0;
            counterS = 0;
            counterMS = 0;
        }
        //Stopurets funktion
        private void TimerStopwatch_Tick(object sender, EventArgs e)
        {
            //Checker om den er aktiv, hvis den er, gå ind i If...
            if (isActive)
            {
                //Læg oven i timeMi
                timeMi++;

                //Hvis timeMI er 100 gå ind i if....
                if(timeMi >= 100)
                {
                    //Læg oven i timeS og reset timeMI
                    timeS++;
                    timeMi = 0;

                    //hvis timeS er 60 gå ind i if....
                    if(timeS >= 60)
                    {
                        //Læg oven i timeM og reset timeS
                        timeM++;
                        timeS = 0;

                        //hvis timeM er 60 gå ind i if...
                        if(timeM >= 60)
                        {
                            //Læg oven i timeH og reset timeM
                            timeH++;
                            timeM = 0;
                        }
                    }
                }
            }
            //Funktion til at vælge format af uret
            DrawTime();
        }
        //Stopurets startknap
        private void StartBtn_Click(object sender, EventArgs e)
        {
            isActive = true;
        }
        //Stopurets stopknap
        private void StopBtn_Click(object sender, EventArgs e)
        {
            isActive = false;
        }
        //Stopurets resetknap
        private void ResetBtn_Click(object sender, EventArgs e)
        {
            isActive = false;
            //Funktion til at restarte timerne på stopuret
            ResetTime();
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
        //Counteren/Nedtællerens funktion
        private void CounterTimer_Tick(object sender, EventArgs e)
        {
            //Checker om den er aktiv, hvis den er, gå ind i if...
            if (counterActive)
            {
                //Trækker fra counterMS og tæller ned
                counterMS--;
                //Hvis counterMS er 0, gå ind i if....
                if (counterMS <= 0)
                {
                    //Trækker fra counterS og resetter counterMS til 100
                    counterS--;
                    counterMS = 100;

                    //Hvis counterS rammer 0 gå ind i if....
                    if (counterS <= 0)
                    {
                        //Trækker fra counterM og resetter counterS til 60
                        counterM--;
                        counterS = 60;

                        //Hvis counterM er 0 gå ind i if....
                        if (counterM <= 0)
                        {
                            //Trækker fra counterH og resetter counterM til 59
                            counterH--;
                            counterM = 59;

                            //Hvis counterH er 0 gå ind i if....
                            if (counterH <= 0)
                            {
                                //Sætter counterH til 1 by default
                                counterH = 1;
                            }
                        }
                    }
                }
            }
            //Funktion til at resette Counteren/Nedtælleren
            CountTimer();
        }

        //Counteren/Nedtællerens startknap
        private void TimerStart_Click(object sender, EventArgs e)
        {
            counterActive = true;
        }

        //Lægger 1 til counterH
        private void AddH_Click(object sender, EventArgs e)
        {
            counterH++;
        }

        //Trækker 1 fra counterH
        private void MinusH_Click(object sender, EventArgs e)
        {
            counterH--;
        }

        //Lægger 1 til counterM
        private void AddM_Click(object sender, EventArgs e)
        {
            counterM++;
        }

        //Trækker 1 fra counterM
        private void MinusM_Click(object sender, EventArgs e)
        {
            counterM--;
        }

        //Lægger 1 til counterS
        private void AddS_Click(object sender, EventArgs e)
        {
            counterS++;
        }

        //Trækker 1 fra counterS
        private void MinusS_Click(object sender, EventArgs e)
        {
            counterS--;
        }

        //Counteren/Nedtællerens stopknap
        private void TimerStop_Click(object sender, EventArgs e)
        {
            counterActive = false;
        }

        //Counteren/Nedtællerens resetknap
        private void TimerReset_Click(object sender, EventArgs e)
        {
            counterActive = false;
            CounterReset();
        }

        //Sætter stopurets decimaler og format
        private void DrawTime()
        {
            TimerMi.Text = String.Format("{0:00}", timeMi);
            TimerS.Text = String.Format("{0:00}", timeS);
            TimerM.Text = String.Format("{0:00}", timeM);
            TimerH.Text = String.Format("{0:00}", timeH);
        }

        //Sætter counteren/nedtællerens decimaler og format
        private void CountTimer()
        {
            CounterMS.Text = String.Format("{0:00}", counterMS);
            CounterS.Text = String.Format("{0:00}", counterS);
            CounterM.Text = String.Format("{0:00}", counterM);
            CounterH.Text = String.Format("{0:00}", counterH);
        }

        //Selve Formen
        private void Form1_Load(object sender, EventArgs e)
        {
            //ResetTime();
            
            //isActive = false;
        }

        public Form1()

        {
            InitializeComponent();
        }
    }
}
