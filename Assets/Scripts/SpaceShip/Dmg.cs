using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Dmg : MonoBehaviour
{
    private Hull hull;
    public int damage = -1;
    public int healing = 1;
    private float drag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
      if (other.TryGetComponent(out IPhysicsObject physicsObject))
      {
            physicsObject.Drag = drag;

            if (damage < 0)
            {
                hull.HealthHandler(damage);
                
            }
            else if (healing < 0)
            {
                hull.HealthHandler(healing);
            }
            
      }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPhysicsObject physicsObject))
        {
            physicsObject.Drag = 0f;
        }    
    }
        
    




}
