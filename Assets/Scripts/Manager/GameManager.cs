using Assets.Scripts.GameLogics.TankControler;
using Assets.Scripts.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerManager PlayerManager = new PlayerManager();
    public SoundManager SoundManager;
    //Quản lý các sự kiện trong battle
    public BattleManager BattleManager;

    public string curSceneName;
    public SceneController SceneController;

    //Thông tin người chơi
    TankSetting mTankInfo;

    private void Awake()
    {
        
        
    }

    private void OnEnable()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    private void OnDisable()
    {
        Instance = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Init();
        SceneController.Init();
        PlayerManager.Init();
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    #region SceneManager
    public void ChangeScene(string sceneName)
    {
        print("SCENE_NAME " + sceneName);
        SceneController.ChangeScene(sceneName);
    }
    #endregion

    #region SoundManager
    #endregion

    #region BattleManager
    public void JoinNewBattle()
    {
        //Đoạn này lấy config tank mà người chơi đã nâng cấp
        TankSetting mTankInfo = new TankSetting()
        {
            BulletDamage = 50,
            Speed = 15
        };
        SceneController.JoinBattle();
        //BattleManager.StartNewBattle(mTankInfo);
    }

    public void FinishBattle()
    {
        BattleManager.FinishBattle();
    }

    #endregion
}
