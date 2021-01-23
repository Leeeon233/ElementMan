using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Object = UnityEngine.Object;

[Serializable]
public class WaterShieldSkill : Skill
{
    public GameObject WaterShieldPrefab;
    public GameObject waterShield;
    public float moveSpeed = 10f;
    public float durationTime = 5f;
    public float maxDistance = 10f;
    // 技能释放点距离人物中心点半径
    private float startRadius = 2f;
    private bool isRelease = false;
    private Vector2 releaseDir;
    private float curDistance;


    public WaterShieldSkill(Player player)
    {
        this.player = player;
        this.cam = Camera.main;
        WaterShieldPrefab = (GameObject)Resources.Load("Prefabs/WaterShield");
    }
    public override void PressCancel()
    {
        if (isRelease && waterShield!=null)
        {
            isRelease = false;
            player.CanJump = true;
            player.CanMove = true;
            waterShield.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            waterShield.GetComponent<WaterShield>().StopMove();
        }
    }

    public override void PressPerform()
    {
        if (isRelease && waterShield!=null)
        {
            curDistance = (waterShield.transform.position - player.transform.position).sqrMagnitude;
            if (curDistance >= maxDistance)
            {
                PressCancel();
            }
        }
    }

    public override void PressStart()
    {
        //Debug.Log("水盾技能释放");
        //Debug.Log(player.param.IsJumping);
        //Debug.Log(player.param.IsCrouch);
        //Debug.Log(waterShield);
        // 人物不是跳跃和蹲下 才能释放
        if (player.param.IsJumping || player.param.IsCrouch || waterShield!=null) {
            return;
        }
        // 按下水盾技能，人物不可移动和跳跃
        CanRelease = false;
        isRelease = true;
        player.CanJump = false;
        player.CanMove = false;
        // 计算释放角度
        mousePos = GetMousePos();
        // 隐式转换为Vector2
        releaseDir = (mousePos - player.transform.position).normalized;
        waterShield = Object.Instantiate(WaterShieldPrefab, GETSkillReleasePosition(), Quaternion.Euler(releaseDir));
        // 调整预制体方向
        waterShield.transform.Rotate(0,0, Mathf.Atan2(releaseDir.y, releaseDir.x) * Mathf.Rad2Deg); 
        waterShield.GetComponent<Rigidbody2D>().velocity = releaseDir * moveSpeed;
        DestroyPrefab(durationTime);
    }

    private Vector3 GETSkillReleasePosition()
    {
        return (Vector2)player.transform.position + releaseDir * startRadius;
    }

    private void DestroyPrefab(float time)
    {
        if (null != waterShield)
        {
            Object.Destroy(waterShield, time);
        }
    }

}