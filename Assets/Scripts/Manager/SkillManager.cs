using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("모든 아이템의 레벨은 4레벨이 최대\n1레벨: 그저 그런데...?\n2레벨: 흠...괜찮네\n3레벨: 좀 좋은데?\n4레벨: 각성? 좋은데?")]
    [Space(10)]

    [SerializeField] GameObject brickPrefab;
    public SkillData[] skillDatas;
    public SkillData pillData;
    public byte[] skillLevels;                   // enum의 Skills로 인덱스 가져오기
    public Monster nearMonster;
    public float nearMonDis = 10.0f;


    public void SkillLevelUp(int skill)
    {
        switch (skill)
        {
            case (int)Skills.BasicSkill_Warrior:                    // 플레이어의 스킬들은 따로 직업 스크립트에서 관리 중
            case (int)Skills.BasicSkill_Acher:
                break;
            case (int)Skills.Brick:
                if (GameManager.I.skillManager.skillLevels[(int)Skills.Brick].Equals(1))
                    Instantiate(brickPrefab, GameManager.I.playerSc.playerTransform);
                break;
            case (int)Skills.Ring:
                GameManager.I.playerSc.figureExp += 1;
                break;
            case (int)Skills.Clover:
                GameManager.I.playerSc.evasionProbability++;
                break;
            case (int)Skills.Drink:
                GameManager.I.playerSc.figureSpeed += 0.25f;
                break;
            case (int)Skills.Adrenaline:
                GameManager.I.playerSc.attackDelay -= 0.3f;
            break;
            case (int)Skills.Belt:
                GameManager.I.playerSc.maxHP += 10;
            break;

            case (int)Skills.Pill:
                GameManager.I.playerSc.hp = Mathf.Min(GameManager.I.playerSc.hp + 10, GameManager.I.playerSc.maxHP);
                break;
        }
    }
}