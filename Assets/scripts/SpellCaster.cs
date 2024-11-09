using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpellCaster : MonoBehaviour
{
    public float spellRange = 10f;
    public float spellDuration = 0.5f;
    public float spellWidth = 0.1f;

    private SpriteRenderer spriteRenderer;
    private LineRenderer lineRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = spellWidth;
        lineRenderer.endWidth = spellWidth;
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CastSpell();
        }
    }

    void CastSpell()
    {
        // Get the color of the current sprite
        Color spellColor = spriteRenderer.color;

        // Set the color of the LineRenderer
        lineRenderer.startColor = spellColor;
        lineRenderer.endColor = spellColor;


        Vector3 spellStart = transform.position;
        Vector3 spellEnd = transform.position + transform.right * spellRange;

        lineRenderer.SetPosition(0, spellStart);
        lineRenderer.SetPosition(1, spellEnd);


        lineRenderer.enabled = true;

        // Start coroutine to disable the line after a duration
        StartCoroutine(DisableLineAfterDuration());
    }

    System.Collections.IEnumerator DisableLineAfterDuration()
    {
        yield return new WaitForSeconds(spellDuration);
        lineRenderer.enabled = false; // Hide the line after spell duration
    }
}
