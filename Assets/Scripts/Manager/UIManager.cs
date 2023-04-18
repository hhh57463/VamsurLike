using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] RectTransform hpRect;
    [SerializeField] Image hpImg;

    [Header("EXP")]
    [SerializeField] Image expImg;

    public TextMeshProUGUI timeText;

    [SerializeField] TextMeshProUGUI killText;

    void Update()
    {
        Exp();
        KillCount();
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

    public void TimeSetting()
    {
        timeText.text = (GameManager.I.playTime / 60).ToString() + ":" + (GameManager.I.playTime % 60).ToString();
    }

    void KillCount()
    {
        killText.text = "X " + GameManager.I.killCount.ToString();
    }
}