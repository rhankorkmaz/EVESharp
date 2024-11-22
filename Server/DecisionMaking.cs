
using System;

namespace EVE.AI
{
    public class DecisionMaking
    {
        public string MakeDecision(int allyStrength, int enemyStrength)
        {
            if (allyStrength > enemyStrength)
                return "Attack";
            else if (allyStrength < enemyStrength)
                return "Defend";
            else
                return "Hold Position";
        }
    }
}
