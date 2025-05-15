using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Misalnya musuh bisa berjalan atau ada logika lain
    public float speed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
