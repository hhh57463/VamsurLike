using System.Collections;
using UnityEngine;
public class Warrior : Player
{
    public override void Init()
    {
        attackDelay = 2.0f;
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);
        Debug.Log("Attack");
        StartCoroutine("Attack");
    }
}
