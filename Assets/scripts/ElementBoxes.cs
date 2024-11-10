using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbsorbUI : MonoBehaviour
{
    public Absorb absorbScript;             // Reference to the Absorb script to track stored elements
    public List<Image> elementSlots;        // List of Image components to represent each element slot
    public Sprite fireSprite;               // Sprite for Fire element
    public Sprite waterSprite;              // Sprite for Water element
    public Sprite windSprite;               // Sprite for Wind element
    public Sprite defaultSprite;            // Default sprite to show when no element is in the slot
    private Dictionary<string, Sprite> elementSprites;  // Dictionary to store element name and corresponding sprite

    void Start()
    {
        // Initialize the dictionary to link element names with sprites
        elementSprites = new Dictionary<string, Sprite>
        {
            { "Fire", fireSprite },
            { "Water", waterSprite },
            { "Wind", windSprite }
        };

        // Initialize all slots with the default sprite
        SetDefaultSprites();
    }

    void Update()
    {
        // Check if all element slots are filled, then clear if full
        if (absorbScript.storedElements.Count >= elementSlots.Count)
        {
            absorbScript.ClearStoredElements();
            SetDefaultSprites();
        }
        else
        {
            // Update the display of elements in the slots based on the current state in Absorb script
            DisplayStoredElements();
        }
    }

    private void DisplayStoredElements()
    {
        // Set default images for all slots initially
        SetDefaultSprites();

        // Iterate over the stored elements in Absorb and update each slot with the corresponding sprite
        int i = 0;
        foreach (string element in absorbScript.storedElements)
        {
            if (i < elementSlots.Count)
            {
                elementSlots[i].sprite = elementSprites[element];
                elementSlots[i].color = Color.white;  // Ensure the slot is visible
                i++;
            }
        }
    }

    private void SetDefaultSprites()
    {
        // Set each slot to the default sprite
        foreach (var slot in elementSlots)
        {
            slot.sprite = defaultSprite;
            slot.color = Color.white;  // Make sure the default sprite is visible
        }
    }
}
