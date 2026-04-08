using UnityEngine;

public class RotateAndFloat : MonoBehaviour
{
    [Header("Movement Settings")]
    public float rotationSpeed = 50f;
    public float floatAmplitude = 0.5f; // How high it bobs
    public float floatFrequency = 1f;  // How fast it bobs

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // 1. Rotation: Spin around the Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // 2. Floating: Use a Sine wave to move up and down smoothly
        float newY = startPos.y + Mathf.Abs(Mathf.Sin(Time.time * floatFrequency)) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}