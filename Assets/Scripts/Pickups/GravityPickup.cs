using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPickup : MonoBehaviour
{
    private PlayerController playerController;
    public static bool isPickedUp = false; // Track if the pickup has been picked up

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player != null && !isPickedUp)
        {
            playerController = player;
            InvertGravity();
            isPickedUp = true;
            StartCoroutine(RespawnPickup());
        }
    }

    void InvertGravity()
    {
        if (playerController != null)
        {
            Rigidbody2D rb = playerController.GetComponent<Rigidbody2D>();
            rb.gravityScale *= -1f;
            playerController.transform.Rotate(Vector3.forward, 180f);
        }
    }

    public void ResetGravity()
    {
        if (playerController != null)
        {
            Rigidbody2D rb = playerController.GetComponent<Rigidbody2D>();
            rb.gravityScale *= -1f; // Reset gravity back to normal
        }
    }

    IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds

        // Reset pickup state
        isPickedUp = false;
        gameObject.SetActive(true); // Make the pickup visible again
    }
}
