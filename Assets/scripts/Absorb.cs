using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    public Color fireColor = Color.red;
    public Color waterColor = Color.blue;
    public Color windColor = Color.green;

    public Queue<string> storedElements = new Queue<string>();  // Queue to store absorbed elements
    private SpriteRenderer spriteRenderer;
    private int currentState = 0;  // 0: Fire, 1: Water, 2: Wind
    public string element = "Fire";  // Current element of the player

    // Elements array to define the order: Fire -> Water -> Wind -> Fire
    private string[] elements = { "Fire", "Water", "Wind" };
    private Dictionary<string, Color> elementColors;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Define colors for each element
        elementColors = new Dictionary<string, Color>
        {
            { "Fire", fireColor },
            { "Water", waterColor },
            { "Wind", windColor }
        };

        // Initialize the element and color
        ChangeColorAndElement(currentState);
    }

    void Update()
    {
        // Switch to the previous element (Q key)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentState = (currentState - 1 + elements.Length) % elements.Length;
            ChangeColorAndElement(currentState);
        }
        // Switch to the next element (E key)
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentState = (currentState + 1) % elements.Length;
            ChangeColorAndElement(currentState);
        }
    }

    void ChangeColorAndElement(int state)
    {
        // Update the element and color based on the current state
        element = elements[state];
        spriteRenderer.color = elementColors[element];
    }

    // Check if player is immune to the incoming attack element
    public bool IsImmune(string incomingElement)
    {
        return element == incomingElement;
    }

    public void AbsorbElement(string incomingElement)
    {
        if (storedElements.Count < 3)
        {
            storedElements.Enqueue(incomingElement);
        }
        else
        {
            storedElements.Dequeue();
            storedElements.Enqueue(incomingElement);
        }
    }

    public void ClearStoredElements()
    {
        storedElements.Clear();
    }
}
