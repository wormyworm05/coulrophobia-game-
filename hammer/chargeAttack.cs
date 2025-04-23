using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

public class chargeAttackScript : MonoBehaviour
{
    public GameObject chargeAttackEmpty;
    public Slider hammerSlider;
    public TextMeshProUGUI swingPower;
    public TextMeshProUGUI totalPower;
    public GameObject totalPowerObj;
    public GameObject aim;

    public GameObject ding;

    public float chargeTime = 2.5f;
    public float charge;
    public float growth;
    public float maxGrowth;
    public int mult = 1;
    public int total;
    public double scaleChange;
    public bool chargeActive = false;
    public bool hasCharged = false;
    public bool phaseOneEnabled = true;
    public bool growing;
    
    


    public Timer timer;

    void Start()
    {
        chargeAttackEmpty.SetActive(false);

    }


   
    
    void Update()
    {
        //first swing
        if (phaseOneEnabled == true) {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                chargeAttackEmpty.SetActive(true);
                chargeActive = true;
                charge = 0;
                hammerSlider.value = 0;
                hasCharged = false;
            }

            if (chargeActive == true)
            {
                if (charge < chargeTime)
                {
                    charge += Time.deltaTime;
                    hammerSlider.value = charge * 40;
                }
                if (charge >= chargeTime)
                {
                    charge = 0;
                }
                swingPower.text = hammerSlider.value.ToString();

                if (chargeActive == true)
                {
                    if (Input.GetKey(KeyCode.Mouse1))
                    {
                        chargeActive = false;
                        hasCharged = true;
                    }
                }
            }
        }
        //aiming
        if (hasCharged == true)
        {
            scaleChange = 0.3;
            phaseOneEnabled = false;
            aim.SetActive(true);  
            if (Input.GetKey(KeyCode.Mouse0))
            {
                growing = true;
            }
            

            if (growing == true) {
                if (growth < maxGrowth)
                {
                    growth += Time.deltaTime;
                }
                if (growth >= maxGrowth)
                {
                    growth = 0;
                }
                if (scaleChange < 5)
                {
                    scaleChange += Time.deltaTime;
                    scaleChange = scaleChange * growth;
                    aim.transform.localScale = new Vector3((float)scaleChange, (float)scaleChange, (float)scaleChange);
                }
                if (scaleChange >= maxGrowth)
                {
                    scaleChange = 0;
                }
            }
            
            if (Input.GetKey(KeyCode.Mouse1))
            {

                growing = false;    
                if (growth < 0.9 && growth > 0)
                {
                    mult = 2;
                }
                if (growth > 1 && growth < 1.3)
                {
                    mult = 3;
                }
                if (growth < maxGrowth && growth > 1.3)
                {
                    mult = 1;
                }

                total = (int)((mult * charge * 40)/3);

                totalPowerObj.SetActive(true);
                totalPower.text = total.ToString();
                
            }
        }

        


    }

}
  
