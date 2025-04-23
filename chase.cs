using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    public GameObject chaser;
    public GameObject chased;
    public float speed = 1f;
    public bool chasing= false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            chasing = true;
        }

        if (chasing == true)
        {
            chaser.transform.position = Vector3.MoveTowards(chaser.transform.position, chased.transform.position, speed);

        }

    }
}
