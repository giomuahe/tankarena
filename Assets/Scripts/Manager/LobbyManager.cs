using Assets.Scripts.Manager;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LobbyManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI name;
    public TextMeshProUGUI gold;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReloadData()
    {
        PlayerInfo playerInfo = GameManager.Instance.PlayerManager.GetPlayerInfo();
        name.text = playerInfo.Nickname;
        gold.text = playerInfo.Gold.ToString();
    }

    public void StartBattle()
    {
        GameManager.Instance.JoinNewBattle();
    }
}
