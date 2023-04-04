using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionTile : MonoBehaviour
{
    const int moveRange = 40;
    void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag("Area"))
            return;
        transform.position += new Vector3((int)GameMng.I.playerSc.xDir * moveRange, (int)GameMng.I.playerSc.yDir * moveRange, 0);
    }
}
