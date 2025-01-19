using UnityEngine;
/// <summary>
/// Read fuel and Burn fuel.
/// </summary>
public class FuelTank : MonoBehaviour
{

    
    public float maxFuel;
    public float currentFuel;
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        maxFuel = 100;
        currentFuel = maxFuel;
        

    }

    // Update is called once per frame
   
    public bool BurnFuel(float burnRate)
    { 
    
        if (currentFuel > 0)
        {
            currentFuel -= burnRate;
            return true;   
        }
        else
        {
            return false;
        }
    }
    //public float FuelUpgrade(float upgradeAmount)
    //{
    //    if (shipUpgrade)
    //    {
    //        currentFuel = (currentFuel + upgradeAmount);
    //    }
        
    
    
    //}
        


    

}
