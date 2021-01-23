using UnityEngine;
using System.Collections;
using Cinemachine.Utility;
using UnityEngine.Events;

struct AbsorbedBullet
{
    private Bullet bullet;
    private Vector2 velocity;
    private CircleCollider2D circleCollider;
    public AbsorbedBullet(Bullet bullet, Rigidbody2D shield)
    {
        this.bullet = bullet;
        this.velocity = bullet.rb.velocity;
        bullet.rb.velocity = shield.velocity;
        bullet.transform.position = shield.position;
        circleCollider = bullet.GetComponent<CircleCollider2D>();
        circleCollider.enabled = false; //TODO ?脚本失效无效？
    }
    public void RecoverVelocity()
    {
        if (this.bullet != null)
        {
            this.bullet.rb.velocity = this.velocity;
            circleCollider.enabled = true;
        }
    }

    public void StopMove()
    {
        if (this.bullet != null)
        {
            this.bullet.rb.velocity = Vector2.zero;
        }

    }
}

public class WaterShield : MonoBehaviour
{
    private PlatformEffector2D effector2D;
    private readonly int maxAbsorbBulletNum = 5;
    private int AbsorbedBulletNum = 0;
    private AbsorbedBullet[] bullets;
    private Rigidbody2D rb;

    
    

    // Use this for initialization
    void Start()
    {
        effector2D = GetComponent<PlatformEffector2D>();
        effector2D.rotationalOffset = -transform.rotation.eulerAngles.z;

        rb = GetComponent<Rigidbody2D>();

        bullets = new AbsorbedBullet[maxAbsorbBulletNum];
    }

    public void StopMove()
    {
        for (int i = 0; i < AbsorbedBulletNum; i++)
        {
            bullets[i].StopMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 碰到子弹吸收
        if (other.CompareTag("Bullet"))
        {
            AbsorbBullet(other.GetComponent<Bullet>());
        }
    }
    /// <summary>
    /// 吸收子弹
    /// </summary>
    /// <param name="bullet">进入水盾的子弹</param>
    private void AbsorbBullet(Bullet bullet)
    {
        // Debug.Log("已吸收 "+ (AbsorbedBulletNum+1) + " 个子弹");
        // 超过承受数量
        if (AbsorbedBulletNum+1 == maxAbsorbBulletNum){
            GameObject.Destroy(gameObject);
            return;
        }
        bullets[AbsorbedBulletNum] = new AbsorbedBullet(bullet, rb);
        
        AbsorbedBulletNum += 1;
    }

    private void FreedBullet()
    {
        for (int i = 0; i < AbsorbedBulletNum; i++)
        {
            bullets[i].RecoverVelocity();
        }
        AbsorbedBulletNum = 0;
    }

    private void OnDestroy()
    {
        // 如果有子弹，原始速度释放
        FreedBullet();
    }
}
