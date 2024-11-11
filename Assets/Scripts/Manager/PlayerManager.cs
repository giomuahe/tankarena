using Assets.Scripts.GameLogics.TankControler;
using Assets.Scripts.Models;
using ChobiAssets.PTM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class PlayerManager
    {
        public PlayerInfo MyInfo;

        private const string PLAYER_INFO = "playerInfo";
        public void Init()
        {
            //Load thông tin từ playerpref
            string playerInfoJson = PlayerPrefs.GetString(PLAYER_INFO);
            if (!string.IsNullOrEmpty(playerInfoJson))
            {
                MyInfo = JsonConvert.DeserializeObject<PlayerInfo>(playerInfoJson);
            }
            else
            {
                MyInfo = CreateDefault();
            }
            
        }

        public void UpdateNickname(string newNickname)
        {
            MyInfo.Nickname = newNickname;
            SaveInfo();
        }

        public PlayerInfo GetPlayerInfo()
        {
            if(MyInfo == null)
                Init();
            return MyInfo;
        }

        public void UpdateGoldBalance(float balanceChanel)
        {
            MyInfo.Gold += balanceChanel;
            SaveInfo();
        }

        public void UpdateTankInfo(TankSetting tankSetting)
        {
            MyInfo.MTankInfo = tankSetting;
            SaveInfo();
        }

        private void SaveInfo()
        {
            string JsonSave = JsonConvert.SerializeObject(MyInfo);
            PlayerPrefs.SetString(PLAYER_INFO, JsonSave);
        }

        private PlayerInfo CreateDefault()
        {
            return new PlayerInfo()
            {
                Nickname = "TestUser01",
                Gold = 1000,
                MTankInfo = new TankSetting()
                {
                    BodyHitPoint = 1001,
                    BulletDamage = 500,
                    Speed = 10,
                    TurletHitPoint = 800
                }
            }; 
        }
    }

    
}
