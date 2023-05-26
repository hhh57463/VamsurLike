using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] TrailRenderer arrowTrail;
    void OnEnable()
    {
        StartCoroutine("Pool");
    }

    void Update()
    {
        transform.Translate(Vector3.right * 10.0f * Time.deltaTime);
    }

    IEnumerator Pool()
    {
        yield return YieldInstructionCache.WaitForSeconds(3.0f);
        ArrowClear();
    }

    void ArrowClear()
    {
        arrowTrail.Clear();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Monster"))
        {
            if (GameManager.I.skillManager.skillLevels[(int)Skills.BasicSkill] != 4)
                ArrowClear();
        }
    }
}
