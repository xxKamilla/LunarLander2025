using Unity.VisualScripting;
using UnityEngine;



public class Hull : MonoBehaviour
{

    /// <summary>
    /// Script handeling health and damage taken
    /// 
    /// Update 17.01.2025 - Robin
    /// main outline
    /// Update 18.01.2025 - Robin
    /// changing some of the methods
    /// adding public to certain methods in order to access them from different scripts
    /// FallDamage and ShipRepair
    /// </summary>


    

    public int maxHealth;
    public int remainingHealth;
    public int lives;

    public BallGravity gravity;
   


    private void Awake()
    {
        gravity = GetComponent<BallGravity>();
    }



    private void Start()
    {
        //Get the current stats fo the spaceship
        // TODO : assign different values to different spaceships
        // upgrades 1-5 ? and increase by 20 or 50 per upgrade
        
        maxHealth = 100; 
        remainingHealth = maxHealth;
        lives = 5; // should we add lives ?
    }

  

  

    void HealthLost(int damageTaken)     
    {
        // handeling damage taken by checking if the player has more heatlth left
        // requires int input for the damage taken

        if (remainingHealth <= 0)
        { 
            Death();
        }

        remainingHealth -= damageTaken;

    }

    void HealthGained(int healthGained)
    {
        // handeling damage taken by checking if the player has more heatlth left
        // requires int input for the damage taken

        if (remainingHealth >= maxHealth)
        {
            remainingHealth = maxHealth;
        }

        remainingHealth += healthGained;

    }

    public void FallDamage()
    {
        //TODO: calculate the damage taken based on velocity or impact
        //then send the damage to the *HealthLost* method 
        

        // update 18.01.2025

        Vector3 speed = gravity.velocity;

        float dmg = speed.x + speed.z + speed.y;
        int damageScale;
        //tested fall damage, seems to work but you need to invoke the function through somewhere else, like the gravity script
        //placeholder which works

        /*
        if (dmg <= -20f | dmg >= 20f)
        {
            damageScale = 50;
        }
        else if (dmg <= -10f | dmg >= 10f)
        {
            damageScale = 20;
        }
        else
        {
            damageScale = 0;
        }
        */
        damageScale = (int)dmg;

        
            if (damageScale < 0)
        {
            damageScale *= -1; 
        }


        HealthLost(damageScale);

    }

    public void ShipRepair()
    {
        //TODO:  repair the ship 
        //landing pad ? or powerup in the air ?
        //placeholder
        HealthGained(maxHealth/2); // having maxhealth/2 ensures that a powerup would scale regardless of the total value, hardcoding it to 20 or 50 would fall off if the total excedes a certain ammount

    }

    void Death()
    {
        //TODO : Play death animation / explosion
        Debug.Log("You died!");
        if (lives > 0)
        {
            lives -= 1;
            remainingHealth = maxHealth; // resetting health after losing a life
        }


    }

    


}
