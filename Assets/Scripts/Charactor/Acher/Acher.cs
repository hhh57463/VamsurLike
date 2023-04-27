using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acher : Player
{
    [SerializeField] GameObject arrowPrefab;
    List<Arrow> arrowManager = new List<Arrow>();
    
    public override void Init()
    {
        damage = 10;
        attackDelay = 2.0f;
        attackDuration = 0.3f;
        for (int i = 0; i < 10; i++)
            CreateArrow();
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);

        if (GameManager.I.skillManager.nearMonster != null)
        {
            switch (GameManager.I.skillManager.skillLevels[(int)Skills.BasicSkill_Acher])
            {
                case 1:
                    ArrowDir(1);
                    break;
                case 2:
                    ArrowDir(2);
                    break;
                case 3:
                    ArrowDir(3);
                    break;
                case 4:
                    ArrowDir(4);
                    break;
            }
        }
        StartCoroutine("Attack");
    }

    void CreateArrow()
    {
        Arrow temp = Instantiate(arrowPrefab).GetComponent<Arrow>();
        arrowManager.Add(temp);
        temp.gameObject.SetActive(false);
    }

    void ArrowDir(int cnt)
    {
        Vector3 dir = playerTransform.position - GameManager.I.skillManager.nearMonster.monsterTransfrom.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        ArrowPool(Quaternion.AngleAxis(angle - 180.0f, Vector3.forward), cnt);
    }

    void ArrowPool(Quaternion angle, int cnt)
    {
        int num = 0;
        for (int i = 0; i < arrowManager.Count; i++)
        {
            if (num == cnt)
                return;
            if (arrowManager[i].gameObject.activeSelf)
                continue;
            ArrowDirSetting(arrowManager[i], angle);
            num++;
        }
        if (num < cnt)
        {
            for (int i = 0; i < cnt - num; i++)
            {
                CreateArrow();
                ArrowDirSetting(arrowManager[arrowManager.Count - 1], angle);
            }
        }
    }

    void ArrowDirSetting(Arrow arrow, Quaternion angle)
    {
        arrow.gameObject.SetActive(true);
        arrow.transform.position = playerTransform.position;
        arrow.transform.rotation = angle;
    }
}