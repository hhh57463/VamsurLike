using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acher : Player
{
    public override void Init()
    {
        damage = 10;
        attackDelay = 2.0f;
        attackDuration = 0.3f;
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);
        
    }
}