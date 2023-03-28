using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 30f;
    public score1 score;
    private Vector2 mousePosition;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<score1>();
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - rigid.position).normalized;
        rigid.AddForce(direction * speed, ForceMode2D.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.position.x>9.5 || rigid.position.x < -9.5)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        if (collision.tag == "balloon") {
            collision.GetComponent<balloonMove>().destroy();
            if (collision.GetComponent<balloonMove>().time <= 3f)
            {
                score.add(2);
            }
            else
            {
                score.add(1);
            }
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            Destroy(gameObject);

        }
        if(collision.tag == "enemy")
        {
            Vector3 temp = collision.gameObject.transform.position;
            collision.GetComponent<enemymovement>().Knockback(temp);
            collision.GetComponent<enemymovement>().health -= 1;
            Destroy(gameObject);
        }
    }
}
