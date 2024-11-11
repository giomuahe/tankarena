using Assets.Scripts.GameLogics.TankControler;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        GameObject playerObj = GameManager.Instance.BattleManager.GetPlayer();
        playerTransform = playerObj.GetComponent<Transform>();
        agent.SetDestination(playerTransform.position);
    }

    internal void Init(TankAiSetting aiSetting)
    {
        throw new NotImplementedException();
    }
}
