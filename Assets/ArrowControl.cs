using UnityEngine;

public class ArrowControl : MonoBehaviour
{
  public float rotationSpeed = 30f; 
  // will mess around with it to find a good speed, just how fast the arrow moves side to side

  void Update() {
    float horizontal = Input.GetAxis("Horizontal"); 
    //left and right arrow or A and D to move

    transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);
  }  
}
