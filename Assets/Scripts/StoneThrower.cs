using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneThrower : MonoBehaviour
{
    public Vector3 newCurrentPosition;
    public float Duration = 0.5f;
    private float _duration;
    public GameObject target;
    public Vector3 destination;
    private float UpdateTime;
    private Vector3 sling;
    // Start is called before the first frame update
    void Start()
    {
      
       sling=transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateTime+= Time.deltaTime;
        if(UpdateTime>=4f)
        {
        GameObject target = GameObject.FindWithTag("Player");  
        destination = target.transform.position;
        UpdateTime=0;
        }

    
        
        
        var t = _duration / Duration;
        Vector3 height=new Vector3(0,5,0);
        
        
        Vector3 peak = sling*0.5f+destination*0.5f+height;
       
        
        transform.position=Mathf.Pow(1 - t, 2) * sling +
            2 * t * (1 - t) * peak +
            Mathf.Pow(t, 2) * destination;
             _duration += Time.deltaTime;
             Destroy(this.gameObject,5.5f);
    
    
    
    }
private void OnTriggerEnter(Collider other) 
{
    if(other.tag=="Player")
    {
        PlayerCon.HP-=10;
        ScoreBoard.point-=20;
        //Debug.Log("ONHIT");
    }
    if(other.tag=="Ground")
    {
        Destroy(this.gameObject);
    }
}
}