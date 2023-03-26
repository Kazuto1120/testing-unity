using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gem : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float speed = 10;
    public score1 score;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<score1>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigid.position.x>9.5 || rigid.position.x < -9.5)
        {
            Destroy(gameObject);
        }
    }
    void flyright() {
        rigid.velocity = Vector2.right*speed;
    }
    void flyleft()
    {
        rigid.velocity = Vector2.left*speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player") {
            
            if (collision.GetComponent<movement>().right){
                flyright();
            }
        else
            {
                flyleft();
            } }
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
    }
}
