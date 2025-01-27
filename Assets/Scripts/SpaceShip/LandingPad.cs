using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingPad : MonoBehaviour
{
    
    public float precision;
    public Vector3 center = new Vector3(0, 0, 0);
    public Vector3 landing = new Vector3(0, 0, 0);
    public bool test = false;
    public Collider ship;

  /* //Commenting out the update function as it was only used for debugging
     private void Update()
    {
        if (test)
        {
            Check(ship);
            test = false; //for debugging
        }
    }
  */
   public void Check(Collider other) // move this to private void OnTriggerEnter(Collider other)
    {
        center = transform.position;
        landing = other.transform.position;
        // when called checking the current position of the landingpad and the spaceship

        
        if (Vector3.Distance(center, landing) == 0)
        {
            precision = 500;
        }
        else
        {
            precision = 1 / (Vector3.Distance(center, landing) / 10) * 50;
        }

        if (precision >500)
        {
            precision = 500;
        }
       
        Debug.Log("distance from center = " + (int)precision);
    }
    
}
