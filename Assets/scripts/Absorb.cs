using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour
{
    public Color state1Color = Color.red;
    public Color state2Color = Color.green;
    public Color state3Color = Color.blue;

    private SpriteRenderer spriteRenderer;
    private int currentState = 1;
    public string element = "Fire";  // Current element of the player

    private GameObject storedSpellPrefab;

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
                element = "Wind";
                break;
            case 3:
                spriteRenderer.color = state3Color;
                element = "Water";
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

    // Store spell if elements match
    private void OnTriggerEnter2D(Collider2D other)
    {
        SpellDamage spell = other.GetComponent<SpellDamage>();
        if (spell != null)
        {
            Debug.Log("Collision detected with spell: " + spell.element);
            Debug.Log("Player element: " + element);

            if (spell.element == element)
            {
                storedSpellPrefab = other.gameObject;
                Debug.Log("Spell stored: " + spell.element);

                Destroy(other.gameObject);
            }
            else
            {
                Debug.Log("Spell not stored, element mismatch: " + spell.element);
            }
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
