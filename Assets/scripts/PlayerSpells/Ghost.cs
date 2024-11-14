using System.Collections;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float boostedSpeed = 10f;
    public float originalSpeed = 5f;
    public float boostDuration = 5f;

    private Movemont playerMovement;

    void Start()
    {

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            playerMovement = player.GetComponent<Movemont>();

            if (playerMovement != null)
            {
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
        playerMovement.moveSpeed = boostedSpeed;

        // Wait for the specified boost duration
        yield return new WaitForSeconds(boostDuration);

        playerMovement.moveSpeed = originalSpeed;
        Destroy(gameObject);
    }
}
