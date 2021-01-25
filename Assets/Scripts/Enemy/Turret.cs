using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float shootInterval = 1f;
    [SerializeField] private float maxDistance = 300f;
    public bool CanMove;
    public Transform End;
    public float moveSpeed = 2f;
    private Vector3 end;
    private Vector3 start;
    private Vector3 tmp;
    private Vector3 muzzleDir;
    private Bullet _bullet;

    // Start is called before the first frame update
    private void Start()
    {
        muzzleDir = new Vector3(0, 0, Mathf.Atan2(transform.up.y, transform.up.x) * Mathf.Rad2Deg);
        InvokeRepeating("GenBullet", 0, shootInterval);

        if (CanMove)
        {
            start = transform.position;
            end = End.position;
            Destroy(End.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (CanMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, end, 0.01f * moveSpeed);
            if ((transform.position - end).sqrMagnitude < 0.1f)
            {
                tmp = start;
                start = end;
                end = tmp;
            }
        }
    }

    // Update is called once per frame
    private void GenBullet()
    {
        _bullet = Instantiate(bullet, muzzle.position, Quaternion.Euler(muzzleDir));
        _bullet.maxDistance = maxDistance;
    }
}