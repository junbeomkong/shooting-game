using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject target2;
    static public int score = 0;
    public GameObject hitEffect;
    public GameObject itembox;
    public GameObject itembox1;
    private AudioSource audio3;
    public AudioClip ZomDead;
    private int number = 0;
    private bool[,] isFilled;
    private int numGridRow = 10;
    private int numGridCol = 10;
    // Start is called before the first frame update
    void Start()
    {

        isFilled = new bool[numGridRow, numGridCol];
        for (int i = 0; i < numGridRow; i++)
        {
            for (int j = 0; j < numGridCol; j++)
                isFilled[i, j] = false;
        }

        for (int x = 3; x < 8; x++)
        {
            for (int y = 3; y < 8; y++)
                isFilled[x, y] = true;
        }
        this.audio3 = this.gameObject.AddComponent<AudioSource>();
        this.audio3.clip = this.ZomDead;
        this.audio3.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        zombielength();
        
    }
    void zombielength()
    {
        if (itembox.transform.position.y <= -1)
        {
            Destroy(itembox);
        }
        if (itembox1.transform.position.y <= -1)
        {
            Destroy(itembox1);
        }
    }
    void itemcall()
    {
            int row1, col1;
            Vector3 targetPosition1;

            row1 = (int)Random.Range(1.0f, 9.0f);
            col1 = (int)Random.Range(1.0f, 9.0f);

            if (!isFilled[row1, col1])
            {
                targetPosition1.x = -49.5f + 9.0f * col1 + 4.5f;
                targetPosition1.z = -27.5f + 5.0f * row1 + 2.5f;
                targetPosition1.y = 5.0f;

                Instantiate(itembox, targetPosition1, Quaternion.identity);

                isFilled[row1, col1] = true;
                number++;
            }  
           
        
    }
    void itemcall1()
    {
        int row2, col2;
        Vector3 targetPosition2;

        row2 = (int)Random.Range(1.0f, 9.0f);
        col2 = (int)Random.Range(1.0f, 9.0f);

        if (!isFilled[row2, col2])
        {
            targetPosition2.x = -49.5f + 9.0f * col2 + 4.5f;
            targetPosition2.z = -27.5f + 5.0f * row2 + 2.5f;
            targetPosition2.y = 5.0f;


            Instantiate(itembox1, targetPosition2,
                Quaternion.identity);

            isFilled[row2, col2] = true;
            number++;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        int ran;
        if(collision.gameObject.CompareTag("zombie"))
        {
            Destroy(collision.gameObject);
            GameObject hitObject = Instantiate(hitEffect, collision.transform.position, collision.transform.rotation);
            Destroy(hitObject, 1.0f);
            score += 10;
            ran = (int)Random.Range(1.0f, 8.0f);
            if(ran == 7 && PlayerCtrl.num == 0)
            {
                itemcall();
                PlayerCtrl.num++;
            }
            if(ran == 4 && PlayerCtrl.num1 == 0)
            {
                itemcall1();
                PlayerCtrl.num1++;
            }
            Destroy(gameObject);
            this.audio3.Play();
            GenerateTarget1();
        }
    }
    void GenerateTarget1()
    {
        int row, col;
        Vector3 targetPosition;

            row = (int)Random.Range(0.0f, 10.0f);
            col = (int)Random.Range(0.0f, 10.0f);

                targetPosition.x = -27.5f + 5.0f * col + 2.5f;
                targetPosition.z = -27.5f + 5.0f * row + 2.5f;
                targetPosition.y = 10.0f;

        Instantiate(target2, targetPosition, Quaternion.identity);
        
    }
}
