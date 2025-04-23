using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class specialTeleport : MonoBehaviour
{
 

    public Transform player, destination;
    public GameObject playerg;
    public GameObject chaser;
    public GameObject chased;
    public float speed = 1f;
    public bool chasing = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerg.SetActive(false);
            player.position = destination.position;
            playerg.SetActive(true);
            chasing = true;
        }
    }
    void Update()
    {
        if (chasing == true)
        {
            chaser.transform.position = Vector3.MoveTowards(chaser.transform.position, chased.transform.position, speed);

        }
    }
}
   

