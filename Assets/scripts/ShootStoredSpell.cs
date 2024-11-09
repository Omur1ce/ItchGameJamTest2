using System.Collections.Generic;
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
        if (Input.GetMouseButtonDown(0))
        {
            ShootSpell();
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
            Debug.LogError("SelectSpell requires exactly 3 elements.");
            return null;
        }

        List<string> elements = new List<string>(storedElements);

        HashSet<string> elementsSet = new HashSet<string>(storedElements);
        SpellType? spellType = null;

        if (elementsSet.SetEquals(new HashSet<string> { "Fire", "Fire", "Fire" }))
            spellType = SpellType.Fireball;
        else if (elementsSet.SetEquals(new HashSet<string> { "Fire", "Fire", "Water" }))
            spellType = SpellType.SummonMageInterns;
        else if (elementsSet.SetEquals(new HashSet<string> { "Fire", "Fire", "Wind" }))
            spellType = SpellType.FireWhirlwind;
        else if (elementsSet.SetEquals(new HashSet<string> { "Water", "Water", "Fire" }))
            spellType = SpellType.WaterWall;
        else if (elementsSet.SetEquals(new HashSet<string> { "Water", "Water", "Water" }))
            spellType = SpellType.Geyser;
        else if (elementsSet.SetEquals(new HashSet<string> { "Water", "Water", "Wind" }))
            spellType = SpellType.SelfHeal;
        else if (elementsSet.SetEquals(new HashSet<string> { "Wind", "Wind", "Fire" }))
            spellType = SpellType.Ghost;
        else if (elementsSet.SetEquals(new HashSet<string> { "Wind", "Wind", "Water" }))
            spellType = SpellType.Whirwind;
        else if (elementsSet.SetEquals(new HashSet<string> { "Wind", "Wind", "Wind" }))
            spellType = SpellType.Tornado;
        else if (elementsSet.SetEquals(new HashSet<string> { "Water", "Fire", "Wind" }))
            spellType = SpellType.Shockwave;

        if (spellType.HasValue && spellPrefabs.ContainsKey(spellType.Value))
        {
            return spellPrefabs[spellType.Value];
        }

        Debug.LogError("No matching spell found for the given elements.");
        return null;
    }

    void ShootSpell()
    {
        GameObject selectedSpell = SelectSpell(script.storedElements);

        if (selectedSpell != null)
        {
            GameObject spellProjectile = Instantiate(selectedSpell, transform.position, Quaternion.identity);

            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = (mousePosition - transform.position).normalized;

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
}
