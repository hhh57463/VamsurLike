using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [Header("모든 아이템의 레벨은 4레벨이 최대\n1레벨: 그저 그런데...?\n2레벨: 흠...괜찮네\n3레벨: 좀 좋은데?\n4레벨: 각성? 좋은데?")]
    [Space(10)]

    public SkillData[] skillDatas;
    public byte[] skillLevels;                   // enum의 Skills로 인덱스 가져오기
}