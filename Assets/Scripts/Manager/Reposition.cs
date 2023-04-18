using UnityEngine;

public class Reposition : MonoBehaviour
{
    const int moveRange = 40;
    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Area"))
            return;

        float dirX = GameManager.I.playerSc.transform.position.x - transform.position.x;
        float dirY = GameManager.I.playerSc.transform.position.y - transform.position.y;

        float distanceX = Mathf.Abs(dirX);
        float distanceY = Mathf.Abs(dirY);

        dirX = dirX > 0 ? 1 : -1;
        dirY = dirY > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if (distanceX > distanceY)
                    transform.Translate(Vector3.right * dirX * moveRange);
                else if (distanceX < distanceY)
                    transform.Translate(Vector3.up * dirY * moveRange);
                else
                    transform.Translate(new Vector3(dirX, dirY, 0) * moveRange);
                break;
            case "Monster":
                transform.Translate(GameManager.I.playerSc.movement * moveRange * 0.5f + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                break;
        }
    }
}