using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LavaChanger : MonoBehaviour
{
     public Material lava;
     public Material grass;
     bool PlayerisDead=false;
     public GameObject Player;
     private float deadDelayTimer = 0;
     Collider m_ObjectCollider;
     
    // Start is called before the first frame update
    void Start()
    {
        GameObject Player  = GameObject.FindWithTag("Player");
        StartCoroutine(exchangelava());
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerisDead)
        {
           
            deadDelayTimer += Time.deltaTime;
            if (deadDelayTimer >= 1.5f)
            {
        Destroy(Player);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
       
    }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.name=="Player")
        {
            PlayerisDead=true;
        }
        }
IEnumerator exchangelava()
{          
     while (true)
    {
     yield return new WaitForSeconds(2);
            MeshRenderer mr = GetComponent<MeshRenderer>();
            mr.material = lava; 
            m_ObjectCollider = GetComponent<Collider>();
            m_ObjectCollider.isTrigger = true;
            yield return new WaitForSeconds(2);
            mr.material = grass;
            m_ObjectCollider.isTrigger = false; 
}
}
}