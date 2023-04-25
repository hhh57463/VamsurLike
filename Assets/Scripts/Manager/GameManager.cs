using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class YieldInstructionCache
{
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new WaitForEndOfFrame();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new WaitForFixedUpdate();
    private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new Dictionary<float, WaitForSeconds>();

    public static WaitForSeconds WaitForSeconds(float seconds)
    {
        if (!waitForSeconds.TryGetValue(seconds, out var wfs))
            waitForSeconds.Add(seconds, wfs = new WaitForSeconds(seconds));
        return wfs;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    void Awake()
    {
        I = this;
    }

    public SpawnManager spawnManager;
    public UIManager uiManager;
    public SkillManager skillManager;
    public Player playerSc;
    public int playTime;
    public int killCount;

    void Start()
    {
        playTime = 0;
        killCount = 0;
        StartCoroutine("TimeController");
    }

    IEnumerator TimeController()
    {
        yield return YieldInstructionCache.WaitForSeconds(1.0f);
        if (!playerSc.isDie)
        {
            playTime++;
            uiManager.TimeSetting();
            if ((playTime % 5).Equals(0))
                SpawnTime(playTime);
            StartCoroutine("TimeController");
        }
    }

    void SpawnTime(int time)
    {
        switch (time)
        {
            case int t when t <= 300:
                spawnManager.MonsterSpawn(MonsterType.Enemy1, 3);
                break;
            case int t when t <= 600:
                spawnManager.MonsterSpawn(MonsterType.Enemy1, 5);
                spawnManager.MonsterSpawn(MonsterType.Enemy2, 5);
                spawnManager.MonsterSpawn(MonsterType.Enemy3, 5);
                break;
            case int t when t <= 900:
                spawnManager.MonsterSpawn(MonsterType.Enemy1, 10);
                spawnManager.MonsterSpawn(MonsterType.Enemy2, 10);
                spawnManager.MonsterSpawn(MonsterType.Enemy3, 10);
                spawnManager.MonsterSpawn(MonsterType.Enemy4, 10);
                break;
        }
    }
}