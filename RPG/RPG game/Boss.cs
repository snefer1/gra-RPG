using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_game
{
    //boss w grze którego musimy pokonać
    public class Boss : Enemy
    {
        public Boss() : base(" Duży Joe ")
        {
            Health = 150;
        }
    }
}
