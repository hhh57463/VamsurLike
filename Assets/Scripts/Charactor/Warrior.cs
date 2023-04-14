using System.Collections;
using UnityEngine;
public class Warrior : Player
{
    [SerializeField] GameObject[] slashObj;
    public override void Init()
    {
        attackDelay = 2.0f;
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);
        Debug.Log("Attack");
        StartCoroutine("Slash");
        StartCoroutine("Attack");
    }

    IEnumerator Slash()
    {
        slashObj[0].SetActive(true);
        slashObj[1].SetActive(true);
        yield return YieldInstructionCache.WaitForSeconds(0.3f);
        slashObj[0].SetActive(false);
        slashObj[1].SetActive(false);
    }
}
