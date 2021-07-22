using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    Text TimeLabel;
    static public float time = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        time = 0.0f;
        TimeLabel = GetComponent<Text>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        TimeLabel.text = "시간 : " + ((int)time).ToString();
        close();
    }
    void close()
    {
        if((int)time == 60)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Endin");
          
        }
    }
}
