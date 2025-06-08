using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemie : MonoBehaviour
{
    List<GameObject> _enemyList = new List<GameObject>();
    [SerializeField] GameObject _enemy;
    int check = 0;
    bool _spawn = true;
    void Update()
    {
        IfSpawn();


    }
    void IfSpawn()
    {
        check = 0;
        for (int i = 1; i < _enemyList.Count; i++)
        {
            if (_enemyList[i].activeSelf)
                check++;
        }
        if (check < 2 && _spawn)
        {
            SpawnE();
            _spawn = false;
            StartCoroutine(WaitNextSpawn());

        }
    }
    GameObject SpawnE()
    {
        foreach (GameObject enemy in _enemyList)
        {
            if (!enemy.activeSelf)
            {
                enemy.transform.position = this.transform.position;
                enemy.SetActive(true);
                return enemy;
            }
            else continue;
        }
            GameObject enemies = Instantiate(_enemy, this.transform.position, Quaternion.identity,this.transform);
            _enemyList.Add(enemies);
        enemies.SetActive(true);
            return enemies;  
    }
    IEnumerator WaitNextSpawn()
    {
        yield return new WaitForSeconds(20);
        _spawn = true;
    }
    
}
