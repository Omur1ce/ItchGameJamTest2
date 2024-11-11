using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour
{
    // Public references to the UI boxes
    public Image box1;
    public Image box2;
    public Image box3;

    // Public references to the sprites for each element
    public Sprite fireSprite;
    public Sprite waterSprite;
    public Sprite windSprite;

    // Reference to the Absorb script (which is on the player object)
    private Absorb absorbScript;

    void Start()
    {
        // Find the player GameObject using its tag
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // Get the Absorb script from the player GameObject
            absorbScript = player.GetComponent<Absorb>();
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }

        // Initial update of the HUD
        UpdateHUD();
    }

    void Update()
    {
        // Update HUD every frame or whenever appropriate
        if (absorbScript != null)
        {
            UpdateHUD();
        }
    }

    void UpdateHUD()
    {
        // Get the stored elements queue from the Absorb script
        Queue<string> storedElements = absorbScript.storedElements;

        // Convert queue to array for easier indexing
        string[] elementsArray = storedElements.ToArray();

        // Update box 1
        if (elementsArray.Length > 0)
        {
            box1.sprite = GetElementSprite(elementsArray[0]);
            box1.color = Color.white; // Set color to white when element is present
        }
        else
        {
            box1.sprite = null;
            box1.color = Color.gray; // Set color to gray when no element
        }

        // Update box 2
        if (elementsArray.Length > 1)
        {
            box2.sprite = GetElementSprite(elementsArray[1]);
            box2.color = Color.white; // Set color to white when element is present
        }
        else
        {
            box2.sprite = null;
            box2.color = Color.gray; // Set color to gray when no element
        }

        // Update box 3
        if (elementsArray.Length > 2)
        {
            box3.sprite = GetElementSprite(elementsArray[2]);
            box3.color = Color.white; // Set color to white when element is present
        }
        else
        {
            box3.sprite = null;
            box3.color = Color.gray; // Set color to gray when no element
        }
    }

    // Helper function to convert element string to corresponding sprite
    Sprite GetElementSprite(string element)
    {
        switch (element)
        {
            case "Fire":
                return fireSprite;
            case "Water":
                return waterSprite;
            case "Wind":
                return windSprite;
            default:
                return null; // No matching element
        }
    }
}
