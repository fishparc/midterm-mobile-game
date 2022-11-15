using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnhitFunction : MonoBehaviour
{
    private float hp;
    // Start is called before the first frame update
    void Start()
    {
        hp=500f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
private void OnTriggerEnter(Collider other)
    {
        // 如果碰撞到的是子彈
        if (other.tag == "Bullet")
        {
          Debug.Log("HITTed");
            hp -= 50f;
            
            // 如果沒血了，就刪除自己
            if (hp <= 0)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }

        }
    }
}
