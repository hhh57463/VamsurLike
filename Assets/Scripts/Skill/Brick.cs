using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] GameObject[] brickObj;
    [SerializeField] Rigidbody2D[] brickRigid;
    Vector2[] brickDir = new Vector2[4];
    float spawnDelay;

    void Start()
    {
        for (int i = 0; i < brickDir.Length; i++)
            brickDir[i] = new Vector2(0.0f, 1.0f);
        spawnDelay = 5.0f;
        StartCoroutine("SpawnBrick");
    }

    IEnumerator SpawnBrick()
    {
        for (int i = 0; i < GameManager.I.skillManager.skillLevels[(int)Skills.Brick]; i++)
        {
            brickDir[i].x = Random.Range(-0.5f, 0.5f);
            brickObj[i].SetActive(true);
            brickRigid[i].AddForce(brickDir[i] * 10.0f, ForceMode2D.Impulse);
        }
        yield return YieldInstructionCache.WaitForSeconds(spawnDelay);
        for(int i = 0; i < GameManager.I.skillManager.skillLevels[(int)Skills.Brick]; i++)
        {
            brickObj[i].transform.localPosition = Vector3.zero;
            brickObj[i].SetActive(false);
        }
        StartCoroutine("SpawnBrick");
    }
}
