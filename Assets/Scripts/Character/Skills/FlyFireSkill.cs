using UnityEngine;
using System.Collections;
using System;


[Serializable]
public class FlyFireSkill : Skill
{
    [SerializeField] private float confirmTime = 5f;
    private float flyForce = 15f;
    private Vector2 releaseDir;
    private Rigidbody2D rb;
    public FlyFireSkill(Player player)
    {
        this.player = player;
        this.cam = Camera.main;
        this.rb = player.GetComponentInParent<Rigidbody2D>();
    }

    public override void PressStart()
    {
        //Debug.Log("飞火释放");
        // 跳跃时
        // 按下时间变慢
        if (CanRelease && player.param.IsJumping)
        {
            player.param.IsReleaseSkill = true;
            Time.timeScale = 0.1f;
            CanRelease = false;
            player.StartCoroutine(PressPerform2());
            player.StartCoroutine(CancelRelease());
            // 创建技能指示器
        }
        
        
    }

    IEnumerator CancelRelease()
    {
        yield return new WaitForSecondsRealtime(confirmTime);
        if (Math.Abs(Time.timeScale - 0.1f) < 1e-5f)
        {
            PressCancel();
        }
    }

    public override void PressCancel()
    {
        //Debug.Log("将施放");
        if (Math.Abs(Time.timeScale - 0.1f) < 1e-5f)
        {
            //Debug.Log("施放");
            
            // 蓄力完成，时间恢复正常
            Time.timeScale = 1f;
            CanRelease = true;
            //rb.AddForce(releaseDir * flyForce);
            player.SetCc2dGravity(false);
            rb.velocity = releaseDir * flyForce;
            rb.gravityScale = 0.2f;
            player.StartCoroutine(ResetGravity());
            
        }
        
        
    }

    IEnumerator ResetGravity()
    {
        yield return new WaitForSeconds(0.3f);
        rb.gravityScale = 1f;
        player.SetCc2dGravity(true);
        player.param.IsReleaseSkill = false;
    }

    public override void PressPerform()
    {
        
    }

    // 释放中
    IEnumerator PressPerform2()
    {
        while (Math.Abs(Time.timeScale - 0.1f) < 1e-5f)
        {
            mousePos = GetMousePos();
            releaseDir = (mousePos - player.transform.position).normalized;
            //Debug.Log(mousePos);
            yield return new WaitForEndOfFrame();
        }
    }

}
