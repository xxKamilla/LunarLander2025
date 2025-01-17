using UnityEngine;


public class Hull : MonoBehaviour
{

    /// <summary>
    /// Script handeling health and damage taken
    /// 
    /// Update 17.01.2025 - Robin
    /// 
    /// </summary>



    public int maxHealth;
    public int remainingHealth;
    public int lives;
    


    private void Start()
    {
        //Get the current stats fo the spaceship
        // TODO : assign different values to different spaceships

        maxHealth = 100; 
        remainingHealth = maxHealth;
        lives = 5; // should we add lives ?
    }


  

    void HealthLost(int damageTaken)
        // handeling damage taken by checking if the player has more heatlth left
        // requires int input for the damage taken
    {
       
        if (remainingHealth <= 0)
        { 
            Death();
        }

        remainingHealth -= damageTaken;

    }

    void HealthGained(int healthGained)
    // handeling damage taken by checking if the player has more heatlth left
    // requires int input for the damage taken
    {

      if (remainingHealth >= maxHealth)
        {
            remainingHealth = maxHealth;
        }

        remainingHealth += healthGained;

    }

    void DamageTaken(float dmg)
    {
        //TODO: calculate the damage taken based on velocity or asteroide inpact
        //then send the damage to the *HealthLost* method 
        //placeholder
        HealthLost(6);

    }

    void shipRepair(int repair)
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


    }

}
