using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class randomCoin : MonoBehaviour
{
    [Header("Random Coin")]
    [SerializeField] private GameObject coin;

    [Header("Spawn Points")] [SerializeField]
    private Transform[] spawnPoints;


    private void Start()
    {
        List<int> myList = randomSpawnPoints(spawnPoints);

        for (int i = 0; i < spawnPoints.Length/2; i++)
        {
                Instantiate(coin,spawnPoints[myList[i]].position,Quaternion.identity,spawnPoints[i]);
            
        }
        
    }

    public List<int> randomSpawnPoints(Transform[] spawnPoints)
    {
        List<int> randomlist = new List<int>();
        int myNumber = 0;
        for (int i = 0; i < spawnPoints.Length/2; i++)
        {
            myNumber = Random.Range(0, spawnPoints.Length);
            if (randomlist.Contains(myNumber))
            {
                i--;
                break;
            }
            else
            {
                randomlist.Add(myNumber);
            }
        }

        return randomlist;
    }
}
