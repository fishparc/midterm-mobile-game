using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    
   public GameObject target;
   public float speed =5f;
    // Start is called before the first frame update
    void Start()
    {
      
      StartCoroutine(ShootStone());
    }

    // Update is called once per frame
    void Update()
    {
         GameObject target=GameObject.FindWithTag("Player");
     var tr = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(tr, transform.rotation, speed * Time.deltaTime);
     
     //猥瑣靠近
      if(Vector3.Distance(target.transform.position,transform.position)>4)
    {  Vector3 gap =(target.transform.position-transform.position).normalized;
       gap *=4;
      transform.position=Vector3.Lerp(transform.position, gap+ target.transform.position,0.0001f);
    }
    }








public GameObject stone;
IEnumerator ShootStone()
{
  while (true)
    {
      int stag = Random.Range(2,6);
      yield return new WaitForSeconds(stag);
      Instantiate(stone,transform.position, transform.rotation);
    }
}
}