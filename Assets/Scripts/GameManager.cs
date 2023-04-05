using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public static GameManager I
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
    }

    public Player playerSc;
}
