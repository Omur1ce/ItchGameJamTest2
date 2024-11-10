using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public Movemont script;  // Reference to the player's movement script

    private float originalSpeed = 5f;  // Original speed to revert to
    private float boostedSpeed = 10f;  // Temporary boosted speed
    private float boostDuration = 5f;  // Duration of the speed boost

    void Start()
    {
        // Start the speed boost when the script is activated
        StartCoroutine(TemporarySpeedBoost());
    }

    private IEnumerator TemporarySpeedBoost()
    {
        // Set the player's speed to the boosted speed
        script.moveSpeed = boostedSpeed;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        // Revert the player's speed to the original speed
        script.moveSpeed = originalSpeed;
    }
}
