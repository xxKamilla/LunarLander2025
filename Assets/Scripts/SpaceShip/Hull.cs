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


        HealthLost(damageScale);

    }

    void ShipRepair(int repair)
    {
        //TODO:  repair the ship 
        //landing pad ? or powerup in the air ?
        //placeholder
        HealthGained(repair);

    }

    void Death()
    {
        //TODO : Play death animation / explosion
        Debug.Log("You died!");
        lives -= 1;


    }
    

}
