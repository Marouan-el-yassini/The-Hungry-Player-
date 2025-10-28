namespace HungryMan
{
    public partial class Form1 : Form
    {
        int gravity = 7;
        int ballSpeed = 5;
        int pipleSpeed = 5;
        int score = 0;
        bool endGame = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimeEvent(object sender, EventArgs e)
        {

            restartButton.Enabled = false;
            restartButton.Visible = false;
            ExitButton.Enabled = false;
            ExitButton.Visible = false;
            SCoreFinal.Enabled= false;
            SCoreFinal.Visible= false;
            label1.Enabled= false;
            label1.Visible= false;
            endGame = false;
            List<PictureBox> balls = new List<PictureBox>() { ball1, ball2, ball3, ball4, ball5, ball6 };
            List<PictureBox> pipleUp = new List<PictureBox>() { pipleup1, pipleup2 };
            List<PictureBox> pipleDown = new List<PictureBox>() { pilpledown1, pipledown2 };
            player.Top += gravity;
            foreach (var pup in pipleUp)
            {
                pup.Left -= pipleSpeed;
                if (pup.Left < -150)
                {
                    pup.Left = this.ClientSize.Width + new Random().Next(100, 300);
                }

            }
            foreach (var pdn in pipleDown)
            {
                pdn.Left -= pipleSpeed;
                if (pdn.Left < -150)
                {
                    pdn.Left = this.ClientSize.Width + new Random().Next(100, 300);
                }
            }
            foreach (var ball in balls)
            {
                ball.Left -= ballSpeed;
            }

            for (int i = 0; i < balls.Count; i++)
            {
                if (player.Bounds.IntersectsWith(balls[i].Bounds))
                {
                    score++;
                    Score.Text = "Score : " + score;
                    Random random = new Random();
                    balls[i].Left = random.Next(500, 800);
                }
            }
            if (player.Top < -25 || player.Top > 500 || player.Bounds.IntersectsWith(pilpledown1.Bounds) || player.Bounds.IntersectsWith(pipledown2.Bounds) || player.Bounds.IntersectsWith(pipleup1.Bounds) || player.Bounds.IntersectsWith(pipleup2.Bounds))
            {
                EndGame();
            }

        }

        private void EndGame()
        {
            gameTime.Stop();
            endGame = true;
            SCoreFinal.Text = Convert.ToString(score);
            restartButton.Enabled = true;
            restartButton.Visible = true;
            ExitButton.Enabled = true;
            ExitButton.Visible = true;
            SCoreFinal.Enabled = true;
            SCoreFinal.Visible = true;
            label1.Enabled = true;
            label1.Visible = true;

        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -7;
            }

        }

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 7;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pipleup2_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for playing!");
            System.Environment.Exit(0);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            restartButton.Enabled = false;
            restartButton.Visible = false;
            ExitButton.Enabled = false;
            ExitButton.Visible = false;
            SCoreFinal.Enabled = false;
            SCoreFinal.Visible = false;
            label1.Enabled = false;
            label1.Visible = false;

            player.Location = new Point(12, 197);
            pilpledown1.Location = new Point(159, 235);
            pipleup2.Location = new Point(617, -128);
            pipleup1.Location = new Point(327, -188);
            pipledown2.Location = new Point(422, 295);
            gameTime.Start();
            ballSpeed = 5;
            pipleSpeed = 5;
            score = 0;
            Score.Text = "Score : " + score;

        }
    }
}
