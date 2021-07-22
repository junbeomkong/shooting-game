using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieCtrl : MonoBehaviour
{
    public GameObject target;
    public GameObject target1 = null;
    public GameObject itembox;
    public GameObject itembox1;
  
    private int numGridRow = 10;
    private int numGridCol = 10;
    private bool[,] isFilled;
    private int numTarget = 0;
    private int number = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        isFilled = new bool[numGridRow, numGridCol];
        for(int i = 0;i < numGridRow;i++)
        {
            for (int j = 0; j < numGridCol; j++)
                isFilled[i, j] = false;
        }
      
        for(int x=3;x<8;x++)
        {
            for (int y = 3; y < 8; y++)
                isFilled[x, y] = true;
        }
        GenerateTarget();
    }

    // Update is called once per frame
    void Update()
    {
   
    }
    
    void GenerateTarget()
    {
        int row, col;
        Vector3 targetPosition;
        
        while(numTarget<10)
        {
        row = (int)Random.Range(0.0f, 10.0f);
        col = (int)Random.Range(0.0f, 10.0f);

            if (!isFilled[row, col])
            {
                targetPosition.x = -49.5f + 9.0f * col + 4.5f;
                targetPosition.z = -27.5f + 5.0f * row + 2.5f;
                targetPosition.y = 10.0f;

                target1=Instantiate(target, targetPosition, Quaternion.identity);

                isFilled[row, col] = true;
                numTarget++;
            }
        }
    }
}
