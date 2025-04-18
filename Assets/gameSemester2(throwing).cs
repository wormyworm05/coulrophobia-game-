
using UnityEngine;
public class ThrowingMechanics : MonoBehaviour
{
    [Header("References")]//this is creating the camera oobject being thrown and then also creates the game objective.
    public Transform cam;               
    public Transform attackPoint;        
    public GameObject objectToThrow; 

    public Transform AimPoiint;

    public Transform FireDirection;    

    [Header("Settings")]

    //This block is for creating everything needed for the total throws.I made it 5 total throws for now but we can change it if needed. Also the spacebar is for power.
    //the cooldown is 2 seconds but can also be changed
    public int totalThrows = 5;          
    public float throwCooldown = 2f;     
    public KeyCode throwKey = KeyCode.Space; 

//This section is for the throw force im not really sure on the values so they will have to be tested. Throw force up is for an upward arc btw idk how we are going to have the game work so we might have to change it.
    public float throwForceMin = 5f;     
    public float throwForceMax = 15f;    
    public float throwForceUp = 5f;      
//This is part of actually throwing the ball like the current power and throws left and if you have enough throws to throw it. I will label some these
    private float throwPower = 0f;       // The current power accumulated by holding spacebar
    private float throwForce;            // The final throw force to apply
    private bool readyToThrow = true;    // Is the player ready to throw
    private int throwsLeft;              // No of throws remaining

    void Start()
    {
        //Makes throws left the total throws.
        throwsLeft = totalThrows;        
    }

    void Update()
    {
        if (readyToThrow && throwsLeft > 0)
        {
            // Tracks how long the player is holding the spacebar for power
            if (Input.GetKey(throwKey))
            {
                //this makes it that holding the spacebar adds power
                throwPower += Time.deltaTime;

                // this makes it that it slowly adds power the longer you hold it at a speed of 2f
                throwForce = Mathf.Lerp(throwForceMin, throwForceMax, Mathf.Clamp01(throwPower / 2f)); 
            }

            // for reseting the power the first time you shoot when spacebar is presssed after a shot
            if (Input.GetKeyDown(throwKey) && throwsLeft > 0)
            {
                throwPower = 0f; //this is the line actually reseting it
            }

            // This makes it once the spacebar is released the ball throws
            if (Input.GetKeyUp(throwKey) && throwsLeft > 0)
            {
                ThrowObject();
            }
        }
    }

    void ThrowObject()
    {
        
        //this is for creating an object to throw at so will probably need to be changed to fit the skee ball machine also should line up the camera
        GameObject thrownObject = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // thus gets the Rigidbody of the thrown object
        Rigidbody rb = thrownObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            //Added a empty object to fire in the direction because i had to rotate the arrow to fit, also got rid of upward arc so it
            //rolls on ramp
            Vector3 throwDirection = FireDirection.forward; 
            rb.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
        }

        // This is for reducing throws so theyre not unlimited
        throwsLeft--;

        // starts the cooldown after throwing to stop spamming
        readyToThrow = false;
        Invoke(nameof(ResetThrow), throwCooldown); // resets the ability to throw after a cooldown for it to actually work
    }

    void ResetThrow()
    {
        readyToThrow = true; // once cooldown ends you can throw again as long as you have throws left
    }

    public int GetRemainingThrows()
    {
        return throwsLeft; //this returns how many throws are left
    }




}
