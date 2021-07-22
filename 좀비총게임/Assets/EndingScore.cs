using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndingScore : MonoBehaviour
{
    Text scoreLa;
    // Start is called before the first frame update
    void Start()
    {
        scoreLa = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLa.text = "     최종점수 : " + bullet.score.ToString() + "점";
    }
}
