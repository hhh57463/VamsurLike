using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D playerRig;
    SpriteRenderer playerRender;
    Animator playerAnime;

    public Transform playerTransform;

    [Header("Player Direction")]
    public Vector2 movement;
    public DirectionX xDir;
    public DirectionX xDirBefore;
    public DirectionY yDir;

    [Header("Player Stat")]
    public float moveSpeed;
    public int hp;
    public int maxHP;
    public int exp;
    public int maxExp;
    public int damage;
    public float attackDelay;
    public float attackDuration;

    [Header("Player Figure")]
    public int figureDmg;
    public int figureExp;
    public int dmgDecrease;
    public float figureSpeed;

    public virtual void Start()
    {
        playerTransform = transform;
        playerRig = GetComponent<Rigidbody2D>();
        playerRender = GetComponent<SpriteRenderer>();
        playerAnime = GetComponent<Animator>();
        moveSpeed = 5.0f;
        hp = maxHP = 100;
        exp = 0;
        maxExp = 100;
        figureDmg = 0;
        figureExp = 0;
        dmgDecrease = 0;
        figureSpeed = 0.0f;
        Init();
        StartCoroutine("Attack");
    }

    void Update()
    {
        if(exp >= maxExp)
            LevelUp();
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
        playerRig.MovePosition(playerRig.position + (movement * (moveSpeed + figureSpeed) * Time.fixedDeltaTime));
        xDir = (DirectionX)h;
        yDir = (DirectionY)v;
        playerAnime.SetFloat("Speed", movement.magnitude);
        if(!xDir.Equals(DirectionX.NONE))
            xDirBefore = xDir;
    }

    void LevelUp()
    {
        exp = exp - maxExp;
        GameManager.I.uiManager.LevelUp();
    }

    public virtual void Init() { }
    public virtual IEnumerator Attack() { yield return YieldInstructionCache.WaitForSeconds(attackDelay); }
}