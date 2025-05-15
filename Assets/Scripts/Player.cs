using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    void Die()
    {
        // Bisa menambahkan animasi kematian di sini
        Debug.Log("Player mati!");
        Destroy(gameObject); // Hapus player
    }
}
