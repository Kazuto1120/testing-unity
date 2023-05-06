using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class balloonMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] int speed;
    [SerializeField] float maxSize = 2f;
    public float time = 0f;
    [SerializeField] float growtime = 6f;
    [SerializeField] bool maxsize = false;
    
    
    public double height = 5.2;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        if (maxsize ==false) {
            StartCoroutine(Grow());
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        
        rigid.velocity = (Vector2.up * speed* PlayerPrefs.GetInt("level"));
        if (rigid.position.y > height)
        {
            destroy();
        }
        if (maxsize)
            destroy();
        
       
    }
    public void destroy()
    {
        Destroy(gameObject);
    }
    private IEnumerator Grow(){
        Vector2 start = transform.localScale;
        Vector2 maxscale = (new Vector2(maxSize, maxSize))/10;
        do {
            transform.localScale = Vector3.Lerp(start, maxscale, time / growtime);
            time += Time.deltaTime;
            yield return null;
        }
        while(time < growtime);
        maxsize = true;
    }
}
