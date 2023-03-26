using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] float movementH;
    [SerializeField] float movementV;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed;
    [SerializeField] GameObject gem;
    [SerializeField] double timer = 1;
    public bool ismoving = false;
    public bool right = true;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        speed = 10;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        movementH = Input.GetAxis("Horizontal");
        movementV = Input.GetAxis("Vertical");
        if (movementH != 0 || movementV != 0)
        {
            ismoving = true;
            animator.SetBool("ismoving", ismoving);
            rigid.velocity = new Vector2(movementH * speed, movementV * speed);

        }
        else
        {
            ismoving = false;
            animator.SetBool("ismoving", ismoving);
        }
        if (Input.GetButton("Fire1")&& timer>=2&&ismoving==false)
        {
            animator.SetBool("shoot", true);
            fire();
            timer = 0;
           
        }
        if (timer > 2)
        {
            animator.SetBool("shoot", false);
        }
        if (timer < 11)
        {
            timer = timer + (Time.deltaTime * 4);
        }

    }
    private void FixedUpdate()
    {
        

        rigid.velocity = new Vector2(movementH * speed, movementV * speed);
        if (movementH < 0 && right == true || movementH > 0 && right == false)
        {
            flip();
        }
       
    }
    void flip()
    {
        transform.Rotate(0, 180, 0);
        right = !right;
    }
    void fire(){
        Instantiate(gem, transform.position, Quaternion.identity);
    }
}
