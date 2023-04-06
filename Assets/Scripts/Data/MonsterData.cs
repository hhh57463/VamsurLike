using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObject/MonsterData", order = 0)]
public class MonsterData : ScriptableObject
{
    public MonsterType type;
    public float hp;
    public float speed;
    public float range;
    public bool attackType;
    public int exp;
}