namespace BlackJack_v2
{
    public partial class Form1 : Form
    {
        private PlayerCard player;
        private BotCard bot;
        string lastWinner;
        string path = "saveGame.txt";

        public Form1()
        {
            InitializeComponent();
            player = new PlayerCard();
            bot = new BotCard();
            Reset();
            UpdateScore();
        }

        private void btnHit_Click(object sender, EventArgs e)
        {
            player.AddCard();
            UpdateDisplay();
            if (player.GetCardValue() > 21)
            {
                Stand();
            }
        }

        private void btnStand_Click(object sender, EventArgs e)
        {
            Stand();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveScore();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadScore();
        }

        private void btnResetScore_Click(object sender, EventArgs e)
        {
            player.SetScore(0);
            bot.SetScore(0);
            UpdateScore();
        }
        private void Stand()
        {
            BtnOff();
            BotPlay();
            Winner();
        }
        private void Reset()
        {
            BtnOn();
            NewGame();
            StartCard();
            UpdateDisplay();
        }
        private void Winner()
        {
            if (player.GetCardValue() > bot.GetCardValue() && player.GetCardValue() < 21 || player.GetCardValue() == 21) //Player win
            {
                player.AddScore(); lastWinner = "Player";
                UpdateScore();
            }
            else if (player.GetCardValue() < 21 && bot.GetCardValue() > 21) //Player win
            {
                player.AddScore(); lastWinner = "Player";
                UpdateScore();
            }
            else if (player.GetCardValue() > 21 && bot.GetCardValue() < 21) //Bot win
            {
                bot.AddScore(); lastWinner = "Bot";
                UpdateScore();
            }
            else if (bot.GetCardValue() > player.GetCardValue() && bot.GetCardValue() < 21 || bot.GetCardValue() == 21) //Bot win
            {
                bot.AddScore(); lastWinner = "Bot";
                UpdateScore();
            }
            else if (player.GetCardValue() < 21 && bot.GetCardValue() < 21 && player.GetCardValue() == bot.GetCardValue()) //Draw
            {
                lastWinner = "Draw";
                UpdateScore();
            }
            else //Draw
            {
                lastWinner = "Draw";
                UpdateScore();
            }
        }
        private void UpdateDisplay()
        {
            lblPlayer.Text = player.GetCards();
            lblBot.Text = bot.GetCards();
            lblPlayerTotal.Text = player.GetCardValue().ToString();
            lblBotTotal.Text = bot.GetCardValue().ToString();
        }
        private void UpdateScore()
        {
            lblScoreAndWinner.Text = "Player : " + player.GetScore() + " | Bot : " + bot.GetScore() + " | Last Winner : " + lastWinner;
        }
        private void StartCard()
        {
            player.AddCard(); player.AddCard(); bot.AddCard();
        }
        private void NewGame()
        {
            player.Clear(); bot.Clear(); //Clear the cards
            lblPlayer.Text = ""; lblBot.Text = "";
        }
        private void BotPlay()
        {
            while (bot.GetCardValue() < 15 && bot.GetCardValue() < player.GetCardValue())
            {
                bot.AddCard();
                UpdateDisplay();
            }
        }
        private void BtnOn()
        {
            btnHit.Enabled = true;
            btnStand.Enabled = true;
        }
        private void BtnOff()
        {
            btnHit.Enabled = false;
            btnStand.Enabled = false;
        }
        private void SaveScore()
        {
            string saveData = player.GetScore() + "," + bot.GetScore();
            File.WriteAllText(path, saveData);
        }
        private void LoadScore()
        {
            if (File.Exists(path))
            {
                string loadData = File.ReadAllText(path);
                List<string> parts = loadData.Split(",").ToList();
                player.SetScore(Convert.ToInt32(parts[0]));
                bot.SetScore(Convert.ToInt32(parts[1]));
                UpdateScore();
            }
        }
    }
}