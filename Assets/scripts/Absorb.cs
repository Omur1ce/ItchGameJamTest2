using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    public Color state1Color = Color.red;
    public Color state2Color = Color.green;
    public Color state3Color = Color.blue;

    public Queue<string> storedElements = new Queue<string>();
    private SpriteRenderer spriteRenderer;
    private int currentState = 0;
    public string element = "Fire";

    public GameObject storedSpellPrefab;
    private AudioSource audioSource;
    public AudioClip absorbSFX;

    private string[] elements = { "Fire", "Wind", "Water" };
    private Color[] elementColors;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        elementColors = new Color[] { state1Color, state2Color, state3Color };
        ChangeColorAndElement(currentState);
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Switch to the previous element (Q key)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentState = (currentState - 1 + elements.Length) % elements.Length;  // Loop back if going below 0
            ChangeColorAndElement(currentState);
        }
        // Switch to the next element (E key)
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = (currentState + 1) % elements.Length;  // Loop back if exceeding max index
            ChangeColorAndElement(currentState);
        }
    }

    void ChangeColorAndElement(int state)
    {
        // Update the element and color based on the current state
        element = elements[state];
        spriteRenderer.color = elementColors[state];
    }

    // player is immune to the incoming attack element
    public bool IsImmune(string incomingElement)
    {
        return element == incomingElement;
    }

    public void addToStoredElements(string incomingElement)
    {
        if (storedElements.Count < 3)
        {

            // Add the element if there's room
            storedElements.Enqueue(incomingElement);
        }
        else if (storedElements.Count == 3)
        {
            // Remove the oldest element
            storedElements.Dequeue();

            // Add the new element to the queue
            storedElements.Enqueue(incomingElement);
        }
    }


    public void ClearStoredElements()
    {
        storedElements.Clear();
    }
}
