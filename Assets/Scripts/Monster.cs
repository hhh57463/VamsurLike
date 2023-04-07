using UnityEngine;

public class Monster : MonoBehaviour
{
    SpriteRenderer monsterRenderer;
    Rigidbody2D monsterRig;
    Animator monsterAnime;
    CapsuleCollider2D monsterCol;
    Vector2 movement;
    public Transform target;           // 나중에 뭐 도발? 시스템 만들때를 대비해서

    const float spawnRange = 20.0f;

    [Header("Monster Info")]
    public MonsterData monsterData;
    public MonsterType type;
    public int hp;
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
        if (GameManager.I.playerSc.xDir.Equals(DirectionX.NONE) && GameManager.I.playerSc.yDir.Equals(DirectionY.NONE))
        {
            int x = Random.Range(1, 3);
            int y = Random.Range(1, 3);
            x = x == 1 ? 1 : -1;
            y = y == 1 ? 1 : -1;
            transform.position = new Vector2(spawnRange * x, spawnRange * y) + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }
        else
            transform.position = (GameManager.I.playerSc.movement * spawnRange) + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }

    void Move()
    {
        monsterRenderer.flipX = target.position.x < transform.position.x;
        movement = (target.position - transform.position).normalized;
        monsterRig.MovePosition(monsterRig.position + (movement * moveSpeed * Time.fixedDeltaTime));
    }
}
