using UnityEngine;

public class PlayerBullet : MonoBehaviour
{

    public int bulletDamage = 5;

    public float bulletLifetime = 2f;



    void OnTriggerStay2D(Collider2D other)
        {
            MonsterHealth monsterHealth = other.GetComponent<MonsterHealth>();

            if (monsterHealth != null)
            {
                Debug.Log(bulletDamage);
                Destroy(gameObject);
                monsterHealth.TakeDamage(bulletDamage);


            }
        }
}
