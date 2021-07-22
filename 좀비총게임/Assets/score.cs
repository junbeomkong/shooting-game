using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    Text scoreLabel;
  
    // Start is called before the first frame update
    void Awake()
    {
        scoreLabel = GetComponent<Text>();
       
    }
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
        scoreLabel.text = "점수 : "+bullet.score.ToString();
       
    }
}
