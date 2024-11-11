using Assets.Scripts.GameLogics.TankControler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> ListEnemy;
    public GameObject player;
    public TankSetting playerTankInfo;
    void Start()
    {
        player = GameManager.Instance.BattleManager.GetPlayer();
        //Gán dữ liệu vào cho player
        //PlayerController 

        //Gán thông số Enemy
        foreach (GameObject enemy in ListEnemy) { 
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
