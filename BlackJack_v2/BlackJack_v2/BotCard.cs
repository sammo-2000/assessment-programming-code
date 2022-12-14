using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack_v2
{
    internal class BotCard : PlayerCard
    {
        List<int> card = new List<int>();
        private int cardValue;
        private int score;
    }
}
