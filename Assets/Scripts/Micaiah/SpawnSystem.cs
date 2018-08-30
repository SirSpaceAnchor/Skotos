using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public Transform[] targets;
    public GameObject[] enemies;
    public GameObject enemyPrefab;
    int iRank = 0;
    // Use this for initialization
    void Start()
    {
        targets = GetComponentsInChildren<Transform>();
        enemies = new GameObject[targets.Length];
        int ramp = 0;
        int rampChange = 3;
        for (int i = 0; i < targets.Length; i++)
        {
            enemies[i] = GameObject.Instantiate(enemyPrefab);
            enemies[i].transform.position = targets[i].position;
            RankType rank = (RankType)iRank;
            if (ramp == rampChange)
            {
                iRank += 1;
                ramp = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}