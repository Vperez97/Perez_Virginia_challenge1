using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.UIElements;

public class Obstacle : MonoBehaviour

{
   
    void Update()
    {
       transform.position = new Vector3(Mathf.PingPong(Time.time, (float)7.07), transform.position.y, transform.position.z);
    
}
    }
