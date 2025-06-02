using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    public Transform pointA;
    public Transform pointB;

    private Vector3 target;

    void Start()
    {
        target = pointB.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
        {
            target = pointB.position;
            Flip();
        }
        else if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            target = pointA.position;
            Flip();
        }
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Membalik arah
        transform.localScale = localScale;
    }
}
