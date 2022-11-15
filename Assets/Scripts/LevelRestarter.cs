using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelRestarter : MonoBehaviour
{
    //private GameObject Playerref;
    // Start is called before the first frame update
    void Start()
    {
        //GameObject Playerref = GameObject.FindWithTag("Player");
        gameObject.SetActive(false);
        //gameObject.Find("Button(restart)").GetComponentInChildren<Text>().text = "Restart?";
    }

    // Update is called once per frame
    void Update()
    {
        //if(PlayerCon.HP<=0)
        {
           // Debug.Log("showup");
        //gameObject.SetActive(true);
    }
    }
}