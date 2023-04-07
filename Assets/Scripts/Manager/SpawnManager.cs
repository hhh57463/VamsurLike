using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform monsterParent;
    [SerializeField] GameObject[] MonsterPrefab = new GameObject[5];
    public List<List<Monster>> monsterManager = new List<List<Monster>>();
    int[] monsterIdx = new int[5] { 0, 0, 0, 0, 0 };

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            monsterManager.Add(new List<Monster>());
            for (int j = 0; j < 100; j++)
            {
                monsterManager[i].Add(Instantiate(MonsterPrefab[i], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity, monsterParent).GetComponent<Monster>());
                monsterManager[i][j].gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        
    }

    void MonsterSpawn(MonsterType type, int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            monsterManager[(int)type][monsterIdx[(int)type]++].gameObject.SetActive(true);
            if (monsterIdx[(int)type] >= 100)
                monsterIdx[(int)type] = 0;
        }
    }
}
