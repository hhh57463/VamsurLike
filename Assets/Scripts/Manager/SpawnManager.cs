using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform monsterParent;
    [SerializeField] Transform expParent;
    [SerializeField] GameObject[] MonsterPrefab = new GameObject[4];
    [SerializeField] GameObject ExpPrefab;
    public List<List<Monster>> monsterManager = new List<List<Monster>>();
    public List<Exp> expManager = new List<Exp>();
    const int spawnCnt = 100;

    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            monsterManager.Add(new List<Monster>());
            for (int j = 0; j < spawnCnt; j++)
            {
                monsterManager[i].Add(Instantiate(MonsterPrefab[i], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity, monsterParent).GetComponent<Monster>());
                monsterManager[i][j].gameObject.SetActive(false);
                expManager.Add(Instantiate(ExpPrefab, new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity, expParent).GetComponent<Exp>());
                expManager[expManager.Count - 1].gameObject.SetActive(false);
            }
        }
    }

    public void MonsterSpawn(MonsterType type, int cnt)
    {
        int spawnCnt = 0;
        foreach (var monster in monsterManager[(int)type])
        {
            if (spawnCnt.Equals(cnt))
                return;
            if (CheckMonState(type, monsterManager[(int)type].IndexOf(monster)))
            {
                monster.gameObject.SetActive(true);
                spawnCnt++;
            }
        }
        AddMonster(type, cnt - spawnCnt);
    }

    bool CheckMonState(MonsterType type, int idx)
    {
        if (monsterManager[(int)type][idx].gameObject.activeSelf)
            return false;
        else
            return true;
    }

    void AddMonster(MonsterType type, int cnt)
    {
        for (int i = 0; i < cnt; i++)
        {
            monsterManager[(int)type].Add(Instantiate(MonsterPrefab[(int)type], new Vector3(1000.0f, 1000.0f, 0.0f), Quaternion.identity, monsterParent).GetComponent<Monster>());
        }
    }

    public void ExpSpawn(Vector3 pos, int amount)
    {
        foreach (var exp in expManager)
        {
            if (exp.gameObject.activeSelf)
                continue;
            exp.gameObject.SetActive(true);
            exp.exp = amount;
            exp.transform.position = pos;
            return;
        }
        expManager.Add(Instantiate(ExpPrefab, pos, Quaternion.identity, expParent).GetComponent<Exp>());
    }
}