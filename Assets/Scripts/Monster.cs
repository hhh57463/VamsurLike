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
    public Transform monsterTransfrom;
    public MonsterData monsterData;
    public MonsterType type;
    public int hp;
    public float moveSpeed;
    public int dropExp;
    public float dmg;

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
        if (hp <= 0)
            Die();
        CheckDistance();
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnEnable()
    {
        InitMonster();
    }

    void InitMonster()
    {
        type = monsterData.type;
        hp = monsterData.hp;
        moveSpeed = monsterData.speed;
        dropExp = monsterData.exp;
        dmg = monsterData.dmg;
        target = GameManager.I.playerSc.playerTransform;
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

    void Die()
    {
        GameManager.I.spawnManager.ExpSpawn(transform.position, dropExp);
        gameObject.SetActive(false);
    }
    
    void CheckDistance()
    {
        float distance = Vector2.Distance(monsterTransfrom.position, GameManager.I.playerSc.playerTransform.position);
        if(distance < GameManager.I.skillManager.nearMonDis)
            GameManager.I.skillManager.nearMonster = this;
        if(GameManager.I.skillManager.nearMonster == this)                          // 바꿀 방법 찾아보기
            GameManager.I.skillManager.nearMonDis = distance;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Weapon") || col.CompareTag("Skill"))
        {
            hp -= GameManager.I.playerSc.damage + GameManager.I.playerSc.figureDmg;
            GameManager.I.killCount++;
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
        {
            if (!GameManager.I.playerSc.isDie)
            {
                GameManager.I.playerSc.hp -= dmg * Time.deltaTime;
            }
        }
    }
}