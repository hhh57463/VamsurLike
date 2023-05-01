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
        for (int i = 0; i < 20; i++)
            CreateArrow();
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);

        if (GameManager.I.skillManager.nearMonster != null)
        {
            StartCoroutine(ArrowDir(GameManager.I.skillManager.skillLevels[(int)Skills.BasicSkill_Acher]));
        }
        StartCoroutine("Attack");
    }

    void CreateArrow()
    {
        Arrow temp = Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity, GameManager.I.spawnParent).GetComponent<Arrow>();
        arrowManager.Add(temp);
        temp.gameObject.SetActive(false);
    }

    IEnumerator ArrowDir(int cnt)
    {
        Vector3 dir = playerTransform.position - GameManager.I.skillManager.nearMonster.monsterTransfrom.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        ArrowPool(Quaternion.AngleAxis(angle - 180.0f, Vector3.forward));
        yield return YieldInstructionCache.WaitForSeconds(0.15f);
        if (cnt > 1)
            StartCoroutine(ArrowDir(cnt - 1));
    }

    void ArrowPool(Quaternion angle)
    {
        for (int i = 0; i < arrowManager.Count; i++)
        {
            if (arrowManager[i].gameObject.activeSelf)
                continue;
            ArrowDirSetting(arrowManager[i], angle);
            return;
        }
        CreateArrow();
        ArrowDirSetting(arrowManager[arrowManager.Count - 1], angle);
    }

    void ArrowDirSetting(Arrow arrow, Quaternion angle)
    {
        arrow.gameObject.SetActive(true);
        arrow.transform.position = playerTransform.position;
        arrow.transform.rotation = angle;
    }
}