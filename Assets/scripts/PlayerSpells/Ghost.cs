using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float boostedSpeed = 10f;        // Temporary boosted speed
    public float originalSpeed = 5f;        // Original speed to revert to
    public float boostDuration = 5f;        // Duration of the speed boost

    private Movemont playerMovement;        // Reference to the player's Movemont script

    void Start()
    {
        // Find the player object by tag (make sure the player has the "Player" tag)
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Check if the player was found and has the Movemont script
        if (player != null)
        {
            playerMovement = player.GetComponent<Movemont>();

            if (playerMovement != null)
            {
                // Start the speed boost
                StartCoroutine(TemporarySpeedBoost());
            }
            else
            {
                Debug.LogError("Movemont script not found on player!");
            }
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        Destroy(gameObject, 1f);
    }

    private IEnumerator TemporarySpeedBoost()
    {
        // Set the player's speed to the boosted speed
        playerMovement.moveSpeed = boostedSpeed;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        // Revert the player's speed to the original speed
        playerMovement.moveSpeed = originalSpeed;
        Destroy(gameObject);
    }
}
