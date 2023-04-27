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
        {
            arrowManager.Add(Instantiate(arrowPrefab).GetComponent<Arrow>());
            arrowManager[i].gameObject.SetActive(false);
        }
    }

    public override IEnumerator Attack()
    {
        yield return YieldInstructionCache.WaitForSeconds(attackDelay);

        if(GameManager.I.skillManager.nearMonster != null)
        {
            Vector3 dir = playerTransform.position - GameManager.I.skillManager.nearMonster.monsterTransfrom.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            ArrowPool(Quaternion.AngleAxis(angle - 180.0f, Vector3.forward));
        }
        StartCoroutine("Attack");
    }

    Monster Target()
    {
        Monster target = null;
        float distance = 10.0f;
        for (int i = 0; i < GameManager.I.spawnManager.monsterManager.Count; i++)
        {
            for (int j = 0; j < GameManager.I.spawnManager.monsterManager[i].Count; j++)
            {
                if (!GameManager.I.spawnManager.monsterManager[i][j].gameObject.activeSelf)
                    continue;
                if (Vector2.Distance(playerTransform.position, GameManager.I.spawnManager.monsterManager[i][j].monsterTransfrom.position) < distance || target == null)
                    target = GameManager.I.spawnManager.monsterManager[i][j];
            }
        }
        return target;
    }

    void ArrowPool(Quaternion angle)
    {
        for (int i = 0; i < arrowManager.Count; i++)
        {
            if(arrowManager[i].gameObject.activeSelf)
                continue;
            arrowManager[i].gameObject.SetActive(true);
            arrowManager[i].transform.position = playerTransform.position;
            arrowManager[i].transform.rotation = angle;
            return;
        }
    }
}