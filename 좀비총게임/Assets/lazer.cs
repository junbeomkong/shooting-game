using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer : MonoBehaviour
{
    public GameObject[] target;
    public GameObject[] target1;
    public GameObject bomb;
    private float bomb_power = 600.0f;
    private int times = 4;
    private float ftimes = 0.0f;
    private float ftimes1 = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        ftimes += Time.deltaTime;
        ftimes1 += Time.deltaTime;

        bomb1();
        bomb2();
        level1();
    }
    void level1()
    {
        if ((int)timer.time == 15 && (int)timer.time < 30)
        {
            times = 3;
        
        }
        if ((int)timer.time == 30)
        {
            times = 2;
   
        }
        
    }
    void bomb1()
    {
        if((int)timer.time >= 0)
        {
            if(times == (int)ftimes )
            {
                int numberr;
                numberr = (int)Random.Range(0.0f, 7.0f);
                GameObject prefab_bomb = Instantiate(bomb,
                    target[numberr].transform.position,
                    target[numberr].transform.rotation);
                prefab_bomb.GetComponent<Rigidbody>().AddForce(target[numberr].transform.forward * bomb_power);
                Destroy(prefab_bomb, 5.0f);
                ftimes = 0.0f;
                
            }     
        }
    }
  

    void bomb2()
    {
        if ((int)timer.time >= 0)
        {
            if(times == (int)ftimes1)
            {
                int numberr1;
                numberr1 = (int)Random.Range(0.0f, 3.0f);
                GameObject prefab_bomb1 = Instantiate(bomb,
                    target1[numberr1].transform.position,
                    target1[numberr1].transform.rotation);
                prefab_bomb1.GetComponent<Rigidbody>().AddForce(target1[numberr1].transform.right * bomb_power);
                Destroy(prefab_bomb1, 8.0f);
                ftimes1 = 0.0f;
            }
            
        }
    }
}
