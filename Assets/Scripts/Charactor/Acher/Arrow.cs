using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
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
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Monster"))
        {
            if (GameManager.I.skillManager.skillLevels[(int)Skills.BasicSkill_Acher] != 4)
                gameObject.SetActive(false);
        }
    }
}
