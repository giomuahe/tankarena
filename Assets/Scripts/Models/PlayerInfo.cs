using Assets.Scripts.GameLogics.TankControler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class PlayerInfo
    {
        public string Nickname { get; set; }
        public float Gold { get; set; }
        public TankSetting MTankInfo { get; set; }
    }
}
