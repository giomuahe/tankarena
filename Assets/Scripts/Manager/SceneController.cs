using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Manager
{
    public class SceneController : MonoBehaviour
    {
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public void Init()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            // Code sẽ được thực thi khi scene được tải xong
            print("Scene " + scene.name + " loaded!");
            GameManager.Instance.curSceneName = scene.name;
            if (scene.name.StartsWith("Battle"))
            {
                //Đọc ra BattleManager
                GameObject battleManager = GameObject.Find("BattleManager");
                GameManager.Instance.BattleManager = battleManager.GetComponent<BattleManager>();
                GameManager.Instance.BattleManager.Init();
            }
            else
            {
                GameManager.Instance.BattleManager = null;
            }

            if (scene.name == "LobbyScene")
            {
                GameObject lobbyManager = GameObject.Find("LobbyManager");
                LobbyManager lobbyInstance = lobbyManager.GetComponent<LobbyManager>();
                lobbyInstance.ReloadData();
            }
        }

        // Start is called before the first frame update
        void Start()
        {

        }



        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void JoinBattle()
        {
            SceneManager.LoadScene("Battle0");
        }
    }
}
