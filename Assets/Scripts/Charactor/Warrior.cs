using System.Collections;
using UnityEngine;
public class Warrior : Player
{
    [SerializeField] GameObject[] slashObj;
    public override void Init()
    {
        damage = 10;
        attackDelay = 2.0f;
        attackDuration = 0.3f;                      // 기본 공격 4레벨 되면 1.0으로 변경
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
                CheckSlashDir(0, 1);
                break;
            case 2:
                slashObj[0].SetActive(true);
                slashObj[1].SetActive(true);
                break;
            case 3:
                CheckSlashDir(2, 3);
                break;
            case 4:
                CheckSlashDir(4, 5);
                break;
        }
        yield return YieldInstructionCache.WaitForSeconds(attackDuration);
        for (int i = 0; i < slashObj.Length; i++)
            slashObj[i].SetActive(false);
    }

    void CheckSlashDir(int right, int left)
    {
        if (xDir.Equals(DirectionX.RIGHT))
            slashObj[right].SetActive(true);
        else if (xDir.Equals(DirectionX.LEFT))
            slashObj[left].SetActive(true);
        else
        {
            if (xDirBefore.Equals(DirectionX.RIGHT) || xDirBefore.Equals(DirectionX.NONE))
                slashObj[right].SetActive(true);
            else if (xDirBefore.Equals(DirectionX.LEFT))
                slashObj[left].SetActive(true);
        }
    }
}
