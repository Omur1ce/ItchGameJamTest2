using UnityEngine;
using UnityEngine.UI;

public class MemoriseHUD : MonoBehaviour
{
    // Public reference to the single UI box
    public Image spellBox;

    // Public references to the sprites for each spell
    public Sprite fireballSprite;
    public Sprite summonMageInternsSprite;
    public Sprite fireWhirlwindSprite;
    public Sprite waterWallSprite;
    public Sprite geyserSprite;
    public Sprite selfHealSprite;
    public Sprite ghostSprite;
    public Sprite whirlwindSprite;
    public Sprite tornadoSprite;
    public Sprite shockwaveSprite;

    // Reference to the ShootStoredSpell script (which is on the player object)
    private ShootStoredSpell shootStoredSpellScript;

    void Start()
    {
        // Find the player GameObject using its tag
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null)
        {
            // Get the ShootStoredSpell script from the player GameObject
            shootStoredSpellScript = player.GetComponent<ShootStoredSpell>();
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
        if (shootStoredSpellScript != null)
        {
            UpdateHUD();
        }
    }

    void UpdateHUD()
    {
        // Get the memorised spell from the ShootStoredSpell script
        GameObject memorisedSpell = shootStoredSpellScript.memorisedSpell;
        Debug.Log("Memorised Spell: " + memorisedSpell);

        if (memorisedSpell != null)
        {
            spellBox.sprite = GetSpellSprite(memorisedSpell.name);
            spellBox.color = Color.white; // Set color to white when a spell is present
        }
        else
        {
            spellBox.sprite = null;
            spellBox.color = Color.gray; // Set color to gray when no spell
        }
    }

    // Helper function to convert memorised spell name to the corresponding sprite
    Sprite GetSpellSprite(string spellName)
    {
        switch (spellName)
        {
            case "FireBullet":
                return fireballSprite;
            case "SteamCloud":
                return summonMageInternsSprite;
            case "InfernoProj":
                return fireWhirlwindSprite;
            case "WaterWall":
                return waterWallSprite;
            case "GeyserBullet":
                return geyserSprite;
            case "Heal":
                return selfHealSprite;
            case "Ghost":
                return ghostSprite;
            case "Whirlwind":
                return whirlwindSprite;
            case "TornadoBullet":
                return tornadoSprite;
            case "Shockwave":
                return shockwaveSprite;
            default:
                return null; // No matching spell
        }
    }
}
