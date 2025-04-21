using UnityEngine;

public class PowerUP : MonoBehaviour
{
    [SerializeField] private Transform barMesh;

    private float amtPower = 0.0f;
    private Vector3 initialScale;
    private Vector3 initialPosition;
    private float chargeDuration = 2f;
    private float decayDuration = 1f;

    void Start()
    {
        if (barMesh != null)
        {
            initialScale = barMesh.localScale;
            initialPosition = barMesh.localPosition;
        }
    }

    void Update()
    {
        float targetPower = Input.GetKey(KeyCode.Space) ? 100f : 0f;
        float speed = (targetPower > amtPower ? 100f / chargeDuration : 100f / decayDuration);
        amtPower = Mathf.MoveTowards(amtPower, targetPower, Time.deltaTime * speed);
        amtPower = Mathf.Clamp(amtPower, 0f, 100f);

        if (barMesh != null)
        {
            float normalized = amtPower / 100f;
            float newYScale = initialScale.y * normalized;
            barMesh.localScale = new Vector3(initialScale.x, newYScale, initialScale.z);

            float offsetY = (newYScale - initialScale.y) / 2f;
            barMesh.localPosition = initialPosition + new Vector3(0f, offsetY, 0f);
        }
    }
}











