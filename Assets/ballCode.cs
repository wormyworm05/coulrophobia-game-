using UnityEngine;
using TMPro;


public class SkeeBall : MonoBehaviour
{
    public TMP_Text scoreText;
    public float rollForce = 10f; // The force applied to the ball when rolled
    public Transform spawnPoint;  // The spawn point where the ball starts
    public Transform targetArea; // The target area for the ball (used for positioning or checking if the ball hits it)
    public float despawnTime = 0.1f; // Time before the ball despawns after hitting a target

    private Rigidbody rb;
    private bool isRolling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Set the ball at the spawn point
        transform.position = spawnPoint.position;
    }

    void Update()
    {
        // If the ball is moving fast enough, enable rolling
        if (!isRolling && rb.linearVelocity.magnitude > 1f)
        {
            isRolling = true;
            rb.isKinematic = false;
        }
    }

    void RollBall()
    {
        // Disable physics for smoother movement
        isRolling = true;
        rb.isKinematic = false;
        
        // Add force to roll the ball forward
        rb.AddForce(transform.forward * rollForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the ball collides with a target
        if (other.CompareTag("TargetA") || other.CompareTag("TargetB") || other.CompareTag("TargetC") || other.CompareTag("TargetD"))
        {
            //logic for scoring based on which target is hit
            AddScore(other);
            StartCoroutine(DespawnBall(gameObject)); // Start despawn
        }
    }

    void AddScore(Collider Target)
    {
        if (Target.CompareTag("TargetA"))
        {
            GameManager.Instance.AddScore(25);
        }
        else if (Target.CompareTag("TargetB"))
        {
            GameManager.Instance.AddScore(10);
        }
        else if (Target.CompareTag("TargetC"))
        {
            GameManager.Instance.AddScore(5); // Default score for any other target
        }
        else if (Target.CompareTag("TargetD"))
        {
            GameManager.Instance.AddScore(0); //If ball doesnt hit a target
        }

        Debug.Log("Score: " + GameManager.Instance); //check it works
    }

    System.Collections.IEnumerator DespawnBall(GameObject ball)
    {
        // Wait before despawning
        yield return new WaitForSeconds(despawnTime);
        
        // Despawn the ball
        Destroy(ball);
    }
}


