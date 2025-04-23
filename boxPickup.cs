using UnityEngine;

public class boxPickup : MonoBehaviour
{

    public GameObject PickUpText;
    public GameObject cubeOnPlayer;

   void Start()
    {
        cubeOnPlayer.SetActive(false);
        PickUpText.SetActive(false);
    }

    private void OnTriggerStay(Collider item)
    {
        PickUpText.SetActive(true);

        if (item.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.Mouse1)) 
            { 
            this.gameObject.SetActive(false);

                cubeOnPlayer.SetActive(true);

                PickUpText.SetActive(false);

            }
        }
    }

    private void OnTriggerExit(Collider item)
    {
        PickUpText.SetActive(false);
    }
}
