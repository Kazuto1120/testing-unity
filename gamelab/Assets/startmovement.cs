using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startmovement : MonoBehaviour
{
    
    
    
    public float speed = 4;
    
    
    public bool right = true;
    public bool ismoving;
    private Animator animator;
    public Vector2 randomP;

    public const int x = 8;
    public const int y = 4;

    private float timer = 0f;
    private float interval = 4f;
    

    
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > interval)
        {
            randomP = new Vector2(Random.Range(-x, x), Random.Range(-y, y));
            Debug.Log(randomP);
            timer = 0f;
            interval = Random.Range(1, 5);
        }
        
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


    
    void flip()
    {
        transform.Rotate(0, 180, 0);
        right = !right;
    }
}
