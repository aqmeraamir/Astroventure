using UnityEngine;

public class ZeroGravityRotator : MonoBehaviour
{
    private Rigidbody rb;
    private Quaternion initialRotation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialRotation = transform.rotation;
    }

    public void ActivateZeroGravity()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = initialRotation * Quaternion.Euler(0f, 0f, 180f);
    }

    public void DeactivateZeroGravity()
    {
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.rotation = initialRotation;
    }
}