using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Ship thrusters and input.
/// 
/// Update 27.01.2025 - Robin Adding default values and minimum values for:
/// thrustBuildRate and  thrustDecayRate
/// </summary>

public class Thrusters : MonoBehaviour
{
    public Gravity gravity;
    public FuelTank fuelTank;
    public float fuelEfficiency = 1f;
    public Vector3 upDirection;
    
    public float currentThrust;
    public float maxThrust;
    [Min(1)]public float thrustBuildRate  = 5f; //default value 5, min value 1
    [Min(1)]public float thrustDecayRate = 5f;  //default value 5, min value 1

    public ParticleSystem firePS;
    public ParticleSystem smokePS;
    public ParticleSystem bSmokePS;

    private void Awake()
    {
        gravity = GetComponent<Gravity>();
        fuelTank = GetComponent<FuelTank>();
    }

    private void Update()
    {

        ParticleSystem.MainModule psFireMain = firePS.main;
        ParticleSystem.EmissionModule psFireEmission = firePS.emission;

        ParticleSystem.MainModule psSmokeMain = smokePS.main;
        ParticleSystem.EmissionModule psSmokeEmission = smokePS.emission;

        ParticleSystem.MainModule psBSmokeMain = bSmokePS.main;
        ParticleSystem.EmissionModule psBSmokeEmission = bSmokePS.emission;

        //<JK> disable
        gravity.thrust = transform.up;
        float targetThrust = 0f;

        if (Input.GetKey(KeyCode.Space) && fuelTank.BurnFuel(fuelEfficiency * Time.deltaTime))
        {
            targetThrust = maxThrust;
 
        }

        if (currentThrust < targetThrust)
        {
            //currentThrust = Mathf.MoveTowards(currentThrust, targetThrust, thrustBuildRate * Time.deltaTime);
            currentThrust = Mathf.Lerp(currentThrust, targetThrust, thrustBuildRate * Time.deltaTime);
            firePS.Play();
            smokePS.Play();
            bSmokePS.Play();
            psFireEmission.rateOverTime = currentThrust / maxThrust * 1000;
            psSmokeEmission.rateOverTime = currentThrust / maxThrust * 100;
            psBSmokeEmission.rateOverTime = currentThrust / maxThrust * 100;
        }

        else if (!Input.GetKey(KeyCode.Space))
        {
            currentThrust = Mathf.MoveTowards(currentThrust, targetThrust, thrustDecayRate * Time.deltaTime);
            firePS.Stop();
            smokePS.Stop();
            bSmokePS.Stop();

            #region Unused Thruster Particle Decay
            //Following lines of code used to control thruster particle decay, but decided to go with full-stop as soon as thrust input ends as it looks better. - Paul
            //psFireEmission.rateOverTime = currentThrust / maxThrust * 500;
            //psSmokeEmission.rateOverTime = currentThrust / maxThrust * 50;
            //psBSmokeEmission.rateOverTime = currentThrust / maxThrust * 50;
            #endregion

        }
        //<JK>
        gravity.thrust = transform.up * currentThrust;

    }





    #region Original Thruster
    //private void Update()
    //{
    //    ballGravity.thrust = transform.up;

    //    if (Input.GetKey(KeyCode.Space) && fuelTank.BurnFuel(0.1f * Time.deltaTime))
    //    {
    //        ThrusterOn();
    //    }

    //    else if (Input.GetKeyUp(KeyCode.Space))
    //    {
    //        ThrusterOff();
    //    }
    //}

    //private void ThrusterOn()
    //{
    //    Debug.Log("ThrusterOn");
    //    ballGravity.thrust = transform.up * 20;
    //    thrusterVFX.SetActive(true);
    //}

    //private void ThrusterOff()
    //{
    //    Debug.Log("ThrusterOff");
    //    ballGravity.thrust = transform.up;
    //    thrusterVFX.SetActive(false);
    //}
    #endregion





}
