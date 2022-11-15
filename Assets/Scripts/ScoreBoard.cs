using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    public static int point=100;
    public Text PointNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointNum.text = "score:"+point.ToString();
        if(PlayerCon.HP<=0)
        {
            point=0;
        }
    }
}
