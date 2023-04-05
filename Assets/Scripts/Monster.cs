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
    float moveSpeed;

    void Start()
    {
        monsterRenderer = GetComponent<SpriteRenderer>();
        monsterRig = GetComponent<Rigidbody2D>();
        monsterAnime = GetComponent<Animator>();
        monsterCol = GetComponent<CapsuleCollider2D>();
        moveSpeed = 4.5f;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        monsterRenderer.flipX = GameManager.I.playerSc.transform.position.x < transform.position.x ? true : false;
        movement = (GameManager.I.playerSc.transform.position - transform.position).normalized;
        monsterRig.MovePosition(monsterRig.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
