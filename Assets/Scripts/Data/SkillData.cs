using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "ScriptableObject/SkillData", order = 0)]
public class SkillData : ScriptableObject
{
    public string skillName;
    public Skills skillCode;
    public Sprite skillSprite;
    [TextArea()]
    public string[] skillInfo;
}