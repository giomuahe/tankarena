using Assets.Scripts.GameLogics.TankControler;
using Assets.Scripts.Models;
using ChobiAssets.PTM;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    //Vị trí người chơi
    public GameObject player;
    public List<string> EnemynameLs;
    
    #region Canvas UI
    public GameObject CanvasResult;
    public Text ResultTxt;
    public Text NumtankkillTxt;
    public Text NumGoldBonusTxt;
    #endregion

    private bool IsSuccess = false;
    private int numTankKill = 0;
    private int goldBonusPerTank = 100;

    //Test
    private bool IsOnPause = false;
    /// <summary>
    /// Khởi tạo
    /// </summary>
    public void Init()
    {
        CanvasResult.SetActive(false);
        InitPlayer();
    }

    void InitPlayer()
    {
        print("Init Player");
        //Thêm thông số máu / damage cho player
        player = GameObject.Find("Player");
        var playerInfo = player.transform.GetChild(0).GetComponent<Damage_Control_Center_CS>();
        if(playerInfo == null)
        {
            print("not foundUser");
        }
        PlayerInfo mPlayer = GameManager.Instance.PlayerManager.GetPlayerInfo();
        TankSetting mTankInfo = mPlayer.MTankInfo;
        playerInfo.SetupTankInfo(mTankInfo);
    }

    // Update is called once per frame
    void Update()
    {
        //Bản build không cho pause
        if (Application.isEditor) {
            if (Input.GetKeyUp(KeyCode.P))
            {
                IsOnPause = !IsOnPause;
                CheckPause();
            }
        }
    }

    private void CheckPause()
    {
        if (!IsOnPause)
        {
            //bỏ
            //Time.timeScale = 0;
        }
    }

    public void StartNewBattle(TankSetting tankInfo)
    {
        // chuyển qua scene battle
        GameManager.Instance.SceneController.ChangeScene("Battle0");
        //Lấy thông tin map
        GameObject mapObj = GameObject.FindWithTag("Map");
    }

    public void FinishBattle()
    {
        GameManager.Instance.SceneController.ChangeScene("LobbyScene");
    }

    public GameObject GetPlayer()
    {
        //Lấy người chơi
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        return player;
    }
    
    public void OnTankDamaged(Collision bulletCollistion, string tankName)
    {
        //Tính damage
    }

    public void OnTankDestroy(string tankname)
    {
        print("TANK DIE " + tankname);
        if (tankname == "Player")
        {
            OnPlayerDie();
        }
        else
        {
            OnEnemyDie(tankname);
        }
    }

    public void OnPlayerDie()
    {
        //Show Result
        IsSuccess = false;
        ShowResult();
    }

    public void OnEnemyDie(string enemyName)
    {
        EnemynameLs.Remove(enemyName);
        numTankKill++;
        print("NumEnemy " + EnemynameLs.Count);
        if (EnemynameLs.Count == 0)
        {
            IsSuccess=true;
            ShowResult();
        }
    }

    public void ShowResult()
    {
        float numGoldBonus = 0;
        if (IsSuccess)
        {
            ResultTxt.text = "CHIẾN THẮNG";
            NumtankkillTxt.text = numTankKill.ToString();
            numGoldBonus = numTankKill * goldBonusPerTank;
            NumGoldBonusTxt.text = numGoldBonus.ToString();
        }
        else
        {
            ResultTxt.text = "THẤT BẠI";
            NumtankkillTxt.text = numTankKill.ToString();
            numGoldBonus = numTankKill * goldBonusPerTank;
            NumGoldBonusTxt.text = numGoldBonus.ToString();
        }
        GameManager.Instance.PlayerManager.UpdateGoldBalance(numGoldBonus);
        ShowPanelResult();
        StartCoroutine(ReturnLobby());
    }

    public void ShowPanelResult()
    {
        CanvasResult.SetActive(true);
    }

    

    IEnumerator ReturnLobby()
    {
        yield return new WaitForSeconds(3f);
        OnEndGame();
    }

    public void OnEndGame()
    {
        GameManager.Instance.SceneController.ChangeScene("LobbyScene");
    }
}
