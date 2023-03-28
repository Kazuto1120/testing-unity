using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymovement : MonoBehaviour
{
    
    public GameObject player;
    public bool knocked = false;
    public int health = 3;
    public float speed;
    private float distance;
    public float chasezone;
    public bool right = true;
    public bool ismoving;
    private Animator animator;
    public Vector2 randomP;
    public bool dead = false;
    [SerializeField] bool chasing = false;
    public const int x = 8;
    public const int y = 4;

    private float timer = 0f;
    private float interval = 4f;
    public float knockbackForce = 2f;
    public float knockbackDuration = .1f; // the duration of the knockback force
    public GameObject spawner;

    private float knockbackTimer = 0f; // the current timer for the knockback force
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GameObject.FindGameObjectWithTag("spawner");
    }

    // Update is called once per frame
    void Update()
    {
        

        timer += Time.deltaTime;
        if (timer > interval)
        {
            randomP = new Vector2(Random.Range(-x, x), Random.Range(-y, y));
            timer = 0f;
            interval = Random.Range(1, 5);
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        if (health <= 0)
        {


            
            spawner.GetComponent<ballonspawner>().currentbunny -= 1;
            dead = true;
            GetComponent<Collider2D>().isTrigger = true;
            StartCoroutine(DestroyTimer());

        }
        if (distance < chasezone&&!knocked&&!dead)
        {
            if (!chasing)
            {
                chasing = true;
                speed = speed + 1;
            }
            
            if (player.transform.position.x < transform.position.x && right)
            {
                flip();
            }
            if (player.transform.position.x > transform.position.x && !right)
            {
                flip();
            }
            ismoving = true;
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("ismoving", ismoving);
        }
        else if(!knocked&& !dead)
        {
            chasezone = 3;
            speed = 2;
            if (randomP.x < transform.position.x && right)
            {
                flip();
            }
            if (randomP.x > transform.position.x && !right)
            {
                flip();
            }
           
            if (transform.position == (Vector3)randomP)
            {
                ismoving = false;
                animator.SetBool("ismoving", ismoving);
            }
            else
            {
                ismoving = true;
                transform.position = Vector2.MoveTowards(this.transform.position, randomP, speed * Time.deltaTime);
                animator.SetBool("ismoving", ismoving);
            }
            }
        if (knockbackTimer > 0f)
        {
            // Decrement the knockback timer every frame
            knockbackTimer -= Time.deltaTime;

            if (knockbackTimer <= 0f)
            {
                // Stop the knockback force when the timer runs out
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                knocked = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balloon")&&!dead)
        {
            collision.gameObject.GetComponent<balloonMove>().destroy();
        }
        if (collision.gameObject.CompareTag("Player")&& !dead)
        {
            Vector3 temp = collision.gameObject.transform.position;
            Knockback(temp);
        }
        
    }
    public void Knockback(Vector3 temp) {
        // Calculate the direction from the player to the enemy
        Vector3 direction = transform.position - temp;
        // Apply the knockback force in the direction away from the player
        GetComponent<Rigidbody2D>().AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse);
        knockbackTimer = knockbackDuration;
        knocked = true;
        chasezone = chasezone * 3;

        
    }
    IEnumerator DestroyTimer()
    {
        animator.Play("defeat");
        yield return new WaitForSeconds(1.2f);
        Destroy(gameObject);
    }
    void flip()
        {
            transform.Rotate(0, 180, 0);
            right = !right;
        }
    }

