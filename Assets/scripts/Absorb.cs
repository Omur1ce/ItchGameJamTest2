using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    public Color state1Color = Color.red;
    public Color state2Color = Color.green;
    public Color state3Color = Color.blue;


    private Queue<string> storedElements = new Queue<string>();
    private SpriteRenderer spriteRenderer;
    private int currentState = 1;
    public string element = "Fire";  // Current element of the player

    public GameObject storedSpellPrefab;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColorAndElement(currentState);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentState = 1;
            ChangeColorAndElement(currentState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentState = 2;
            ChangeColorAndElement(currentState);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentState = 3;
            ChangeColorAndElement(currentState);
        }
    }

    void ChangeColorAndElement(int state)
    {
        switch (state)
        {
            case 1:
                spriteRenderer.color = state1Color;
                element = "Fire";
                break;
            case 2:
                spriteRenderer.color = state2Color;
                element = "Water";
                break;
            case 3:
                spriteRenderer.color = state3Color;
                element = "Wind";
                break;
            default:
                break;
        }
    }

    
    //player is immune to the incoming attack element
    public bool IsImmune(string incomingElement)
    {
        return element == incomingElement;
    }

    public void addToStoredElements(string incomingElement)
    {
        if (storedElements.Count < 3){
            storedElements.Enqueue(incomingElement);
            Debug.Log("Storing element");
        }
        else if (storedElements.Count == 3){
            string dequed = storedElements.Dequeue();
            Debug.Log("dequed");
        }
    }

    public GameObject GetStoredSpell()
    {
        return storedSpellPrefab;
    }
    public void ClearStoredSpell()
    {
        storedSpellPrefab = null;
    }



}
