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
    Vector2 movement;
    float moveSpeed;
    public DirectionX xDir;
    public DirectionY yDir;

    void Start()
    {
        playerRig = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
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
        movement = new Vector2(h, v);
        playerRig.MovePosition(playerRig.position + (movement * moveSpeed * Time.fixedDeltaTime));
        playerRender.flipX = h < 0;
        xDir = (DirectionX)h;
        yDir = (DirectionY)v;
    }
}
