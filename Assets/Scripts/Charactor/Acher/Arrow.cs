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
        yield return YieldInstructionCache.WaitForSeconds(5.0f);
        gameObject.SetActive(false);
    }
}
