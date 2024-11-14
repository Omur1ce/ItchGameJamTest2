using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShootStoredSpell : MonoBehaviour
{
    public float spellSpeed = 10f;
    public Absorb script;

    // Assign spell prefabs in the Inspector
    public GameObject fireballPrefab;
    public GameObject summonMageInternsPrefab;
    public GameObject fireWhirlwindPrefab;
    public GameObject waterWallPrefab;
    public GameObject geyserPrefab;
    public GameObject selfHealPrefab;
    public GameObject ghostPrefab;
    public GameObject whirlwindPrefab;
    public GameObject tornadoPrefab;
    public GameObject shockwavePrefab;

    private Dictionary<SpellType, GameObject> spellPrefabs;
    public GameObject memorisedSpell;

    void Awake()
    {
        // Initialize the dictionary with spell prefabs
        spellPrefabs = new Dictionary<SpellType, GameObject>
        {
            { SpellType.Fireball, fireballPrefab },
            { SpellType.SummonMageInterns, summonMageInternsPrefab },
            { SpellType.FireWhirlwind, fireWhirlwindPrefab },
            { SpellType.WaterWall, waterWallPrefab },
            { SpellType.Geyser, geyserPrefab },
            { SpellType.SelfHeal, selfHealPrefab },
            { SpellType.Ghost, ghostPrefab },
            { SpellType.Whirwind, whirlwindPrefab },
            { SpellType.Tornado, tornadoPrefab },
            { SpellType.Shockwave, shockwavePrefab }
        };
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShootSpell();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MemoriseSpell();
        }
    }

    public enum SpellType
    {
        Fireball,
        SummonMageInterns,
        FireWhirlwind,
        WaterWall,
        Geyser,
        SelfHeal,
        Ghost,
        Whirwind,
        Tornado,
        Shockwave
    }

    public GameObject SelectSpell(Queue<string> storedElements)
    {
        if (storedElements.Count != 3)
        {
            Debug.LogError("Select Spell requires exactly 3 elements.");
            return null;
        }

        // Count each element's occurrences
        var elementCounts = storedElements.GroupBy(element => element)
                                          .ToDictionary(group => group.Key, group => group.Count());

        SpellType? spellType = null;

        if (elementCounts.TryGetValue("Fire", out int fireCount) && fireCount == 3)
            spellType = SpellType.Fireball;
        else if (fireCount == 2 && elementCounts.GetValueOrDefault("Water") == 1)
            spellType = SpellType.SummonMageInterns;
        else if (fireCount == 2 && elementCounts.GetValueOrDefault("Wind") == 1)
            spellType = SpellType.FireWhirlwind;
        else if (elementCounts.GetValueOrDefault("Water") == 2 && fireCount == 1)
            spellType = SpellType.WaterWall;
        else if (elementCounts.GetValueOrDefault("Water") == 3)
            spellType = SpellType.Geyser;
        else if (elementCounts.GetValueOrDefault("Water") == 2 && elementCounts.GetValueOrDefault("Wind") == 1)
            spellType = SpellType.SelfHeal;
        else if (elementCounts.GetValueOrDefault("Wind") == 2 && fireCount == 1)
            spellType = SpellType.Ghost;
        else if (elementCounts.GetValueOrDefault("Wind") == 2 && elementCounts.GetValueOrDefault("Water") == 1)
            spellType = SpellType.Whirwind;
        else if (elementCounts.GetValueOrDefault("Wind") == 3)
            spellType = SpellType.Tornado;
        else if (fireCount == 1 && elementCounts.GetValueOrDefault("Water") == 1 && elementCounts.GetValueOrDefault("Wind") == 1)
            spellType = SpellType.Shockwave;

        // Return the spell prefab if the spell type is found
        if (spellType.HasValue && spellPrefabs.ContainsKey(spellType.Value))
        {
            return spellPrefabs[spellType.Value];
        }

        return null;
    }

    void ShootSpell()
    {
        GameObject selectedSpell = SelectSpell(script.storedElements);

        if (selectedSpell != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Instantiate the spell and rotate it to point towards the mouse
            GameObject spellProjectile = Instantiate(selectedSpell, transform.position, Quaternion.Euler(0, 0, angle));

            Rigidbody2D rb = spellProjectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * spellSpeed;
            }

            script.ClearStoredElements();
        }
        else
        {
            Debug.Log("No spell stored to shoot!");
        }
    }

    void MemoriseSpell()
    {
        if (memorisedSpell == null)
        {
            // Memorise the spell and clear stored elements
            memorisedSpell = SelectSpell(script.storedElements);
            if (memorisedSpell != null)
            {
                script.ClearStoredElements();
                Debug.Log("Spell memorised!");
            }
            else
            {
                Debug.Log("No spell available to memorise!");
            }
        }
        else
        {
            // Fire the memorised spell
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

            // Calculate the angle in degrees
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Instantiate the spell and rotate it to point towards the mouse
            GameObject spellProjectile = Instantiate(memorisedSpell, transform.position, Quaternion.Euler(0, 0, angle));

            Rigidbody2D rb = spellProjectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = direction * spellSpeed;
            }

            // Clear memorised spell after shooting
            memorisedSpell = null;
            Debug.Log("Spell fired!");
        }
    }

}

