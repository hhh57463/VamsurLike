using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Sprite[] expSprite = new Sprite[2];
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
        for (int i = 0; i < monsterManager[(int)type].Count; i++)
        {
            if (spawnCnt.Equals(cnt))
                return;
            if (CheckMonState(type, i))
            {
                monsterManager[(int)type][i].gameObject.SetActive(true);
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
        for(int i = 0 ; i < expManager.Count; i++)
        {
            if(expManager[i].gameObject.activeSelf)
                continue;
            expManager[i].gameObject.SetActive(true);
            expManager[i].exp = amount;
            expManager[i].transform.position = pos;
            return;
        }
        expManager.Add(Instantiate(ExpPrefab, pos, Quaternion.identity, expParent).GetComponent<Exp>());
    }
}