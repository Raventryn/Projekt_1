using UnityEngine;

public class RotateAroundY : MonoBehaviour
{
    public float rotationSpeed = 50f; // Adjust speed in the Inspector

    void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}