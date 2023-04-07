using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] RectTransform hpRect;
    [SerializeField] Image hpImg;

    [Header("EXP")]
    [SerializeField] Image expImg;

    void Start()
    {
        
    }

    void Update()
    {
        Exp();
    }

    void FixedUpdate()
    {
        HP();
    }

    void Exp()
    {
        expImg.fillAmount = (float)GameManager.I.playerSc.exp / (float)GameManager.I.playerSc.maxExp;
    }

    void HP()
    {
        hpRect.position = Camera.main.WorldToScreenPoint(GameManager.I.playerSc.transform.position);
        hpImg.fillAmount = (float)GameManager.I.playerSc.hp / (float)GameManager.I.playerSc.maxHP;
    }
}
