using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
struct SkillUpButton
{
    public Button skillBtn;
    public Image skillImg;
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI skillInfoText;
}

public class UIManager : MonoBehaviour
{
    [Header("HP")]
    [SerializeField] RectTransform hpRect;
    [SerializeField] Image hpImg;

    [Header("EXP")]
    [SerializeField] Image expImg;

    public TextMeshProUGUI timeText;

    [SerializeField] TextMeshProUGUI killText;

    [Header("LevelUp")]
    [SerializeField] GameObject levelupPopup;
    [SerializeField] SkillUpButton[] skillBtn;
    [SerializeField] List<int> exception = new List<int>();          // 레벨업 시 중복되지 않게 적용시키기위한 예외 리스트
    [SerializeField] int fewSkill;                                                    // 레벨업 할 수 있는 남은 스킬 개수

    void Start()
    {
        fewSkill = (int)(Skills.SkillLastIndex);
    }

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

    public void LevelUp()
    {
        levelupPopup.SetActive(true);
        exception.Clear();
        int itemAmount = fewSkill < 3 ? fewSkill : 3;
        if (!itemAmount.Equals(0))
        {
            for (int i = 0; i < itemAmount; i++)
            {
                int skill;
                do
                {
                    skill = Random.Range(0, (int)(Skills.SkillLastIndex));
                } while (exception.Contains(skill) || GameManager.I.skillManager.skillLevels[skill] >= 4);
                skillBtn[i].skillImg.sprite = GameManager.I.skillManager.skillDatas[skill].skillSprite;
                skillBtn[i].skillNameText.text = GameManager.I.skillManager.skillDatas[skill].skillName;
                skillBtn[i].skillInfoText.text = GameManager.I.skillManager.skillLevels[skill] < 3 ? GameManager.I.skillManager.skillDatas[skill].skillInfo[0] : GameManager.I.skillManager.skillDatas[skill].skillInfo[1];
                exception.Add(skill);
                if (i < 3 - fewSkill)
                {
                    skillBtn[i + fewSkill].skillBtn.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            skillBtn[0].skillImg.sprite = GameManager.I.skillManager.pillData.skillSprite;
            skillBtn[0].skillNameText.text = GameManager.I.skillManager.pillData.skillName;
            skillBtn[0].skillInfoText.text = GameManager.I.skillManager.pillData.skillInfo[0];
        }
        Time.timeScale = 0;
    }

    public void SkillUpBtn1()
    {
        if (!fewSkill.Equals(0))
        {
            GameManager.I.skillManager.skillLevels[exception[0]]++;
            CheckSkillAwaken(GameManager.I.skillManager.skillLevels[exception[0]]);
        }
        else
        {
            GameManager.I.skillManager.SkillLevelUp((int)Skills.Pill);
        }
        levelupPopup.SetActive(false);
        Time.timeScale = 1;
    }

    public void SkillUpBtn2()
    {
        GameManager.I.skillManager.skillLevels[exception[1]]++;
        CheckSkillAwaken(GameManager.I.skillManager.skillLevels[exception[1]]);
        levelupPopup.SetActive(false);
        Time.timeScale = 1;
    }

    public void SkillUpBtn3()
    {
        GameManager.I.skillManager.skillLevels[exception[2]]++;
        CheckSkillAwaken(GameManager.I.skillManager.skillLevels[exception[2]]);
        levelupPopup.SetActive(false);
        Time.timeScale = 1;
    }

    void CheckSkillAwaken(int skill)                        // 해당 스킬이 각성레벨까지 도달했는지
    {
        if (skill.Equals(4))
            fewSkill--;
    }
}