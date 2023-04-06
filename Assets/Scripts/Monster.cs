using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    SpriteRenderer monsterRenderer;
    Rigidbody2D monsterRig;
    Animator monsterAnime;
    CapsuleCollider2D monsterCol;
    Vector2 movement;
    public Transform target;           // 나중에 뭐 도발? 시스템 만들때를 대비해서

    [Header("Monster Info")]
    public MonsterData monsterData;
    public MonsterType type;
    public float hp;
    public float moveSpeed;
    public int dropExp;

    void Start()
    {
        monsterRenderer = GetComponent<SpriteRenderer>();
        monsterRig = GetComponent<Rigidbody2D>();
        monsterAnime = GetComponent<Animator>();
        monsterCol = GetComponent<CapsuleCollider2D>();

        InitMonster();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void InitMonster()
    {
        type = monsterData.type;
        hp = monsterData.hp;
        moveSpeed = monsterData.speed;
        dropExp = monsterData.exp;
        target = GameManager.I.playerSc.transform;
    }

    void Move()
    {
        monsterRenderer.flipX = target.position.x < transform.position.x ? true : false;
        movement = (target.position - transform.position).normalized;
        monsterRig.MovePosition(monsterRig.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
