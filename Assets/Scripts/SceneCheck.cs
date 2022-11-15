using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
        int enemycount=enemys.Length;
        if(enemycount<=0)
        {
            SceneManager.LoadScene("Level2");
        }
    }
public void LvrestartOnClk()
{
//Debug.Log("restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerCon.HP=50;
        ScoreBoard.point=100;
        Time.timeScale=1f;
}
}