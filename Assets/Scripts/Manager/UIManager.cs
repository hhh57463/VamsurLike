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
        expImg.fillAmount = GameManager.I.playerSc.exp / GameManager.I.playerSc.maxExp;
    }

    void HP()
    {
        hpRect.position = Camera.main.WorldToScreenPoint(GameManager.I.playerSc.transform.position);
        hpImg.fillAmount = GameManager.I.playerSc.hp / GameManager.I.playerSc.maxHP;
    }
}
