using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionX
{
    LEFT = -1,
    NONE,
    RIGHT
}
public enum DirectionY
{
    DOWN = -1,
    NONE,
    UP,
}

public class Player : MonoBehaviour
{
    Rigidbody2D playerRig;
    SpriteRenderer playerRender;
    Animator playerAnime;
    Vector2 movement;
    float moveSpeed;
    public DirectionX xDir;
    public DirectionY yDir;

    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        playerAnime = GetComponent<Animator>();
        moveSpeed = 5.0f;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    float h => Input.GetAxis("Horizontal");
    float v => Input.GetAxis("Vertical");
    void Move()
    {
        if (h != 0)
            playerRender.flipX = h < 0;
        movement = new Vector2(h, v).normalized;
        playerRig.MovePosition(playerRig.position + (movement * moveSpeed * Time.fixedDeltaTime));
        xDir = (DirectionX)h;
        yDir = (DirectionY)v;
        playerAnime.SetFloat("Speed", movement.magnitude);
    }
}
