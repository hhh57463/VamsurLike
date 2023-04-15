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
        switch (GameManager.I.skillManager.basicWeaponLevel)
        {
            case 1:
                if (xDir.Equals(DirectionX.RIGHT))
                    slashObj[0].SetActive(true);
                else if (xDir.Equals(DirectionX.LEFT))
                    slashObj[1].SetActive(true);
                else
                {
                    if (xDirBefore.Equals(DirectionX.RIGHT) || xDirBefore.Equals(DirectionX.NONE))
                        slashObj[0].SetActive(true);
                    else if (xDirBefore.Equals(DirectionX.LEFT))
                        slashObj[1].SetActive(true);
                }
                break;
            case 2:
                slashObj[0].SetActive(true);
                slashObj[1].SetActive(true);
                break;
        }
        yield return YieldInstructionCache.WaitForSeconds(0.3f);
        switch (GameManager.I.skillManager.basicWeaponLevel)
        {
            case 1:
            case 2:
                slashObj[0].SetActive(false);
                slashObj[1].SetActive(false);
                break;
        }
    }
}
