using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager I { get; private set; }

    void Awake() {
        I = this;
        DontDestroyOnLoad(gameObject);    
    }
    public CharactorJob job;
}
