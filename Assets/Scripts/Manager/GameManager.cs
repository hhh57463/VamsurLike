using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I { get; private set; }

    void Awake()
    {
        I = this;
    }

    public Player playerSc;
}
