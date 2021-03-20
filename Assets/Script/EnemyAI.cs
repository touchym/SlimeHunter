using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAI : MonoBehaviour
{
    [SerializeField] protected int health; 

    public float enemy_speed;
    public float enemy_GroundDistance;
    public bool moveRight = true;

    public float distanceOBJ;
    public float distanceWalk = 15;
    public float distanceBull = 10;

    float scaleX, scaleY;


    public Transform enemy_GroundCheck;
    public GameObject player;

    private PlayerControl PlayerCon;
    public Rigidbody2D rb;
    public SpriteRenderer spr;
    public Animator an;

    protected float firerate ;
    protected float nextFire ;



    public  void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;


        PlayerCon = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponentInChildren<SpriteRenderer>();
        an = GetComponentInChildren<Animator>();

        firerate = 1f;
        nextFire = Time.time;

    }
    public virtual void Update()
    {
        // EnemyMovement();
        EnemyDetactPlayer();
    }

    public virtual void EnemyMovement()
    {
        transform.Translate(Vector2.right * enemy_speed * Time.deltaTime);

        RaycastHit2D rayGround = Physics2D.Raycast(enemy_GroundCheck.position, Vector2.down, enemy_GroundDistance);


        if (rayGround.collider == false)
        {
            if (moveRight == true)
            {
                
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
                


            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }


        }
    }


    public virtual void EnemyDetactPlayer()
    {
        distanceOBJ = Vector2.Distance(player.transform.position, transform.position);
        if (distanceOBJ > distanceWalk)
        {
           // if (moveRight) transform.position += new Vector3(enemy_speed*Time.deltaTime, 0, 0);
          //  else transform.position += new Vector3(-enemy_speed * Time.deltaTime, 0, 0);
        }
        else if (distanceOBJ > distanceBull)
        {
            if (moveRight) transform.position += new Vector3(enemy_speed * Time.deltaTime, 0, 0);
            else transform.position += new Vector3(-enemy_speed * Time.deltaTime, 0, 0);
        }
        else
        {

        }
        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector3(-scaleX, scaleY, 1);
            moveRight = false;
        }
        else
        {
            transform.localScale = new Vector3(scaleX, scaleY, 1);
            moveRight = true;
        }
       
    }

    public virtual void Attack()
    {
        // Debug.Log(gameObject.name + "attack me");
        Debug.Log("base attack");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.x < transform.position.x)
            {
                PlayerCon.knockRight = true;
            }
            else
            {
                PlayerCon.knockRight = false;
            }

          
        }
    }

}