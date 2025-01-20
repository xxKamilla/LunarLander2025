using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Ship thrusters and input.
/// </summary>

public class Thrusters : MonoBehaviour
{
    public BallGravity ballGravity;
    public FuelTank fuelTank;
    public Vector3 upDirection;
    
    public float currentThrust;
    public float maxThrust;
    public float thrustBuildRate;
    public float thrustDecayRate;

    public ParticleSystem firePS;
    public ParticleSystem smokePS;
    public ParticleSystem bSmokePS;

    private void Awake()
    {
        ballGravity = GetComponent<BallGravity>();
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


        ballGravity.thrust = transform.up;
        float targetThrust = 0f;

        if (Input.GetKey(KeyCode.Space) && fuelTank.BurnFuel(0.1f * Time.deltaTime))
        {
            targetThrust = maxThrust;
 
        }

        if (currentThrust < targetThrust)
        {
            currentThrust = Mathf.MoveTowards(currentThrust, targetThrust, thrustBuildRate * Time.deltaTime);
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
            //firePS.Stop();
            //smokePS.Stop();
            //bSmokePS.Stop();
            psFireEmission.rateOverTime = currentThrust / maxThrust * 500;
            psSmokeEmission.rateOverTime = currentThrust / maxThrust * 50;
            psBSmokeEmission.rateOverTime = currentThrust / maxThrust * 50;
        }

        ballGravity.thrust = transform.up * currentThrust;

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
