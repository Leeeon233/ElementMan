using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float maxDistance;
    private Vector3 startPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        startPos = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if ((transform.position - startPos).sqrMagnitude > maxDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Ground":
                Destroy(gameObject);
                break;

            case "Player":
                //Debug.Log("受到攻击");
                Destroy(gameObject);
                break;
        }
    }
}