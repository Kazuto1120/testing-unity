using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballonspawner : MonoBehaviour
{
    [SerializeField] GameObject ballon;
    [SerializeField] GameObject bunny;
    public int maxbunny = 6;
    public int currentbunny = 0;
    [SerializeField] double timer = 0;
    [SerializeField] double spawnrate = 1;
    [SerializeField] int max = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < 2)
        {
            timer = timer + (Time.deltaTime*spawnrate);
        }
        else
        {
            timer = 0;
            spawn();
        }
    }
    void spawn()
    {
        Instantiate(ballon, new Vector3(Random.Range(-max,max), -6,0), Quaternion.identity);
        if (Random.Range(1,3)==1) {
            if (currentbunny < maxbunny)
            {
                Instantiate(bunny, new Vector3(Random.Range(-max, max), -6, -3), Quaternion.identity);
                currentbunny += 1;
            } }

    }
}
