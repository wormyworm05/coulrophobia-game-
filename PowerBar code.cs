using UnityEngine;
using UnityEngine.UI;


public class PowerUP : MonoBehaviour{

[SerializeField]
private image imagePowerUP;
[SerializeField]
private TMP_Text textPowerAmt;


private bool isPowerUp=false;
private bool isDirrectionUp=true;
private float amtPower=0.0f;
private float powerSpeed=100.0f;

void update()
{
    if(isPowerUp()
    {PowerActive();
    }

}
void PowerActive()

{
    if(isDirectionUp)
    {amtPower+= Time.deltaTime * powerSpeed;
    if(amtPower>100){
        isDirectionUp=false;
        amtPower=100.0f;
    }
    
    
    }
    else{
        amtPower+= Time.deltaTime * powerSpeed;
    if(amtPower<0){
        isDirectionUp=True;
        amtPower=0.0f;
    }
    imagePowerUp.fillAmount=(0.483f-0.25f)*amtPower/100.0f+.25f;
}
public void StartPowerUp(){
    isPowerUp=true;
    amtPower=0.0f
    isDirectionUp=true;
    textPowerAmt.text="";
    
    }

    public void EndPowerUp()
    {
        isPowerUp=false;
        textPowerAmt.text=amtPower.ToString("f0");
    }
}