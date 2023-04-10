using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class YieldInstructionCache
{
    public static readonly WaitForEndOfFrame WaitForEndOfFrame = new();
    public static readonly WaitForFixedUpdate WaitForFixedUpdate = new();
    private static readonly Dictionary<float, WaitForSeconds> waitForSeconds = new();

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
        playTime++;
        uiManager.TimeSetting();
        if ((playTime % 5).Equals(0))
            SpawnTime(playTime);
        StartCoroutine("TimeController");
    }

    void SpawnTime(int time)
    {
        switch (time)
        {
            case int t when t <= 300:
                spawnManager.MonsterSpawn(MonsterType.Monster0, 3);
                break;
            case int t when t <= 600:
                spawnManager.MonsterSpawn(MonsterType.Monster0, 5);
                spawnManager.MonsterSpawn(MonsterType.Monster1, 5);
                spawnManager.MonsterSpawn(MonsterType.Monster2, 5);
                break;
            case int t when t <= 900:
                spawnManager.MonsterSpawn(MonsterType.Monster0, 10);
                spawnManager.MonsterSpawn(MonsterType.Monster1, 10);
                spawnManager.MonsterSpawn(MonsterType.Monster2, 10);
                spawnManager.MonsterSpawn(MonsterType.Monster3, 10);
                spawnManager.MonsterSpawn(MonsterType.Monster4, 10);
                break;
        }
    }
}
