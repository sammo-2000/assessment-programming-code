using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_v2
{
    internal class PlayerCard
    {
        List<int> card = new List<int>();
        private int cardValue;
        private int score;

        //Get
        public string GetCards()
        {
            string cards = "";
            foreach (var item in card)
            {
                cards = cards + "       " + item;
            }
            return cards;
        }
        public int GetCardValue()
        {
            return cardValue;
        }
        public int GetScore()
        {
            return score;
        }

        //Add
        public void AddCard()
        {
            card.Add(RNG());
            AddCardValue();
        }
        public void AddCardValue()
        {
            int totalCard = 0;
            foreach (var item in card)
            {
                totalCard = totalCard + item;
            }
            cardValue = totalCard;
        }
        public void AddScore()
        {
            score++;
        }

        //Set
        public void SetScore(int newScore)
        {
            score = newScore;
        }

        //Clear
        public void Clear()
        {
            card.Clear();
        }

        //Function
        private int RNG()
        {
            Thread.Sleep(500); //Create little delay
            Random rng = new Random();
            return rng.Next(1, 11);
        }
    }
}
