using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMng : MonoBehaviour
{
    private static GameMng instance;

    public static GameMng I
    {
        get
        {
            if (instance.Equals(null))
            {
                Debug.Log("instance is null");
                return null;
            }
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public Player playerSc;
}
