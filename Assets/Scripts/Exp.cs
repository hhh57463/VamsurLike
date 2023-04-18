using UnityEngine;

public class Exp : MonoBehaviour
{
    public SpriteRenderer expRenderer;
    public int exp;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameManager.I.playerSc.exp += exp;
            gameObject.SetActive(false);
        }
    }
}
