using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameProject
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8, 9, 9, 10, 10 };
        string firstChoice;
        string secondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 60;
        int countDownTime;
        bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            LoadPictures();

            // Specify the path to your background image
            string backgroundImagePath = "pics/bg.png";

            // Check if the file exists
            if (System.IO.File.Exists(backgroundImagePath))
            {
                // Set the background image
                this.BackgroundImage = Image.FromFile(backgroundImagePath);

                // Optional: Stretch the background image to cover the entire form
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Background image not found!");
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = "Time Left: " + countDownTime;
            if (countDownTime < 1)
            {
                GameOver("Times Up, You Lose");
                ShowAllPictures();
            }
        }

        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void LoadPictures()
        {
            int leftPos = 20;
            int topPos = 20;
            int rows = 0;

            for (int i = 0; i < 20; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 50;
                newPic.Width = 50;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);

                if (rows < 4)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 60;
                }

                if (rows == 4)
                {
                    leftPos = 20;
                    topPos += 60;
                    rows = 0;
                }
            }

            RestartGame();
        }

        private async void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                // Don't register a click if the game is over
                return;
            }

            PictureBox clickedPic = sender as PictureBox;

            // Check if the clicked picture box has already been revealed
            if (clickedPic.Image != null)
            {
                // The picture box is already revealed, ignore the click
                return;
            }

            if (firstChoice == null)
            {
                // First click
                picA = clickedPic;
                picA.Image = Image.FromFile("pics/" + (string)picA.Tag + ".png");
                firstChoice = (string)picA.Tag;
            }
            else if (secondChoice == null)
            {
                // Second click
                picB = clickedPic;
                picB.Image = Image.FromFile("pics/" + (string)picB.Tag + ".png");
                secondChoice = (string)picB.Tag;

                // Briefly show the second picture
                await Task.Delay(500); // Adjust the delay time (in milliseconds) as needed

                // Check for matching pairs immediately after the second click
                CheckPictures(picA, picB);
            }
            else
            {
                // Third click, reset choices
                firstChoice = null;
                secondChoice = null;

                // Hide images for all picture boxes
                foreach (PictureBox pics in pictures)
                {
                    if (pics.Tag != null)
                    {
                        pics.Image = null;
                    }
                }
            }
        }

        private void RestartGame()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }
            tries = 0;
            lblStatus.Text = "Mismatched: " + tries + " times.";
            lblTimeLeft.Text = "Time Left: " + totalTime;
            gameOver = false;
            GameTimer.Start();
            countDownTime = totalTime;
        }

        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                lblStatus.Text = "Mismatched " + tries + " times.";

                // Hide images for mismatched pairs immediately after the second click
                A.Image = null;
                B.Image = null;
            }

            firstChoice = null;
            secondChoice = null;

            // Now let's check if all of the items have been solved
            if (pictures.All(o => o.Tag == pictures[0].Tag))
            {
                GameOver("Great Work, You Win!!!!");
            }
        }

        private void GameOver(string msg)
        {
            GameTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Click Restart to Play Again.", "Moo Says: ");
        }

        private void ShowAllPictures()
        {
            foreach (PictureBox x in pictures)
            {
                if (x.Tag != null)
                {
                    x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                }
            }
        }
    }
}























/*
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryGameProject
{
    public partial class Form1 : Form
    {
        List<int> numbers = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6 };
        string firstChoice;
        string secondChoice;
        int tries;
        List<PictureBox> pictures = new List<PictureBox>();
        PictureBox picA;
        PictureBox picB;
        int totalTime = 30;
        int countDownTime;
        bool gameOver = false;

        public Form1()
        {
            InitializeComponent();
            LoadPictures();

            // Specify the path to your background image
            string backgroundImagePath = "pics/bg.png";

            // Check if the file exists
            if (System.IO.File.Exists(backgroundImagePath))
            {
                // Set the background image
                this.BackgroundImage = Image.FromFile(backgroundImagePath);

                // Optional: Stretch the background image to cover the entire form
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else
            {
                MessageBox.Show("Background image not found!");
            }
        }

        private void TimerEvent(object sender, EventArgs e)
        {
            countDownTime--;
            lblTimeLeft.Text = "Time Left: " + countDownTime;
            if (countDownTime < 1)
            {
                GameOver("Times Up, You Lose");
                foreach (PictureBox x in pictures)
                {
                    if (x.Tag != null)
                    {
                        x.Image = Image.FromFile("pics/" + (string)x.Tag + ".png");
                    }
                }
            }
        }

        private void RestartGameEvent(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void LoadPictures()
        {
            int leftPos = 20;
            int topPos = 20;
            int rows = 0;
            for (int i = 0; i < 12; i++)
            {
                PictureBox newPic = new PictureBox();
                newPic.Height = 50;
                newPic.Width = 50;
                newPic.BackColor = Color.LightGray;
                newPic.SizeMode = PictureBoxSizeMode.StretchImage;
                newPic.Click += NewPic_Click;
                pictures.Add(newPic);
                if (rows < 3)
                {
                    rows++;
                    newPic.Left = leftPos;
                    newPic.Top = topPos;
                    this.Controls.Add(newPic);
                    leftPos = leftPos + 60;
                }
                if (rows == 3)
                {
                    leftPos = 20;
                    topPos += 60;
                    rows = 0;
                }
            }
            RestartGame();
        }

        private async void NewPic_Click(object sender, EventArgs e)
        {
            if (gameOver)
            {
                // Don't register a click if the game is over
                return;
            }

            PictureBox clickedPic = sender as PictureBox;

            // Check if the clicked picture box has already been revealed
            if (clickedPic.Image != null)
            {
                // The picture box is already revealed, ignore the click
                return;
            }

            if (firstChoice == null)
            {
                // First click
                picA = clickedPic;
                picA.Image = Image.FromFile("pics/" + (string)picA.Tag + ".png");
                firstChoice = (string)picA.Tag;
            }
            else if (secondChoice == null)
            {
                // Second click
                picB = clickedPic;
                picB.Image = Image.FromFile("pics/" + (string)picB.Tag + ".png");
                secondChoice = (string)picB.Tag;

                // Briefly show the second picture
                await Task.Delay(500); // Adjust the delay time (in milliseconds) as needed

                // Check for matching pairs immediately after the second click
                CheckPictures(picA, picB);
            }
            else
            {
                // Third click, reset choices
                firstChoice = null;
                secondChoice = null;

                // Hide images for all picture boxes
                foreach (PictureBox pics in pictures)
                {
                    if (pics.Tag != null)
                    {
                        pics.Image = null;
                    }
                }
            }
        }

        private void RestartGame()
        {
            var randomList = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            numbers = randomList;
            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Image = null;
                pictures[i].Tag = numbers[i].ToString();
            }
            tries = 0;
            lblStatus.Text = "Mismatched: " + tries + " times.";
            lblTimeLeft.Text = "Time Left: " + totalTime;
            gameOver = false;
            GameTimer.Start();
            countDownTime = totalTime;
        }

        private void CheckPictures(PictureBox A, PictureBox B)
        {
            if (firstChoice == secondChoice)
            {
                A.Tag = null;
                B.Tag = null;
            }
            else
            {
                tries++;
                lblStatus.Text = "Mismatched " + tries + " times.";

                // Hide images for mismatched pairs immediately after the second click
                A.Image = null;
                B.Image = null;
            }

            firstChoice = null;
            secondChoice = null;

            // Now let's check if all of the items have been solved
            if (pictures.All(o => o.Tag == pictures[0].Tag))
            {
                GameOver("Great Work, You Win!!!!");
            }
        }

        private void GameOver(string msg)
        {
            GameTimer.Stop();
            gameOver = true;
            MessageBox.Show(msg + " Click Restart to Play Again.", "Moo Says: ");
        }
    }
}
*/