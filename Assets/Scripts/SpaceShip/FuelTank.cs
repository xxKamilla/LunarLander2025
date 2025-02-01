using UnityEngine;
/// <summary>
/// Read fuel and Burn fuel.
/// 
/// Update 01.02.2025 - Paul adding a reference to FuelBar Script (UI) script + Calling method to update UI fuel level to the actual fuel level.
/// </summary>
public class FuelTank : MonoBehaviour
{

    
    public float maxFuel;
    public float currentFuel;
    public FuelBarScript fuelBarUI;
    
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
            fuelBarUI.Updatefuel(currentFuel);
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
