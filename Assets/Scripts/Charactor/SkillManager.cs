using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("모든 아이템의 레벨은 4레벨이 최대\n1레벨: 그저 그런데...?\n2레벨: 흠...괜찮네\n3레벨: 좀 좋은데?\n4레벨: 각성? 좋은데?")]
    [Space(10)]

    public SkillData[] skillDatas;
    public SkillData pillData;
    public byte[] skillLevels;                   // enum의 Skills로 인덱스 가져오기

    public void SkillLevelUp(int skill)                             // 각 스킬의 함수를 구현할 것
    {
        switch (skill)
        {
            case (int)Skills.BasicSkill_Warrior:                    // 플레이어의 스킬들은 따로 직업 스크립트에서 관리 중
            case (int)Skills.BasicSkill_Acher:
                break;
            case (int)Skills.Brick:
                Debug.Log("벽돌 레벨 체크");
                Brick();
                break;
            case (int)Skills.Ring:
                Debug.Log("반지 레벨 체크");
                Ring();
                break;
            case (int)Skills.Clover:
                Debug.Log("클로버 레벨 체크");
                Clover();
                break;
            case (int)Skills.Drink:
                Debug.Log("음료수 레벨 체크");
                Drink();
                break;
            case (int)Skills.Pill:
                GameManager.I.playerSc.hp = Mathf.Min(GameManager.I.playerSc.hp + 10, GameManager.I.playerSc.maxHP);
                break;
        }
    }

    void Brick()
    {
        switch(GameManager.I.skillManager.skillLevels[2])
        {
            case 1:

            break;
            case 2:

            break;
            case 3:

            break;
        }
    }

    void Ring()
    {
        switch(GameManager.I.skillManager.skillLevels[3])
        {
            case 1:

            break;
            case 2:

            break;
            case 3:

            break;
        }
    }

    void Clover()
    {
        switch(GameManager.I.skillManager.skillLevels[4])
        {
            case 1:

            break;
            case 2:

            break;
            case 3:

            break;
        }
    }

    void Drink()
    {
        switch(GameManager.I.skillManager.skillLevels[5])
        {
            case 1:

            break;
            case 2:

            break;
            case 3:

            break;
        }
    }
}