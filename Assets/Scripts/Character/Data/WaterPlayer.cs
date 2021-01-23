using System.Collections.Generic;
using QFramework;
using UnityEngine;

public class WaterPlayer : Player
{
    public override void Init()
    {
        this.param = new PlayerParam(false, JumpMaxNum, false, 36.5f);
        CanJump = true;
        CanMove = true;
        JumpMaxNum = 1;
        IsUnconquerable = false;
        CannotStand = false;
        moveSpeedScale = 1f;
        cc2d.OnCrouchEvent.AddListener(OnCrouch);
        cc2d.m_CeilingCheck = CeilingCheck;
        cc2d.m_GroundCheck = GroundCheck;

        InitSkill();
    }



    private void OnCrouch(bool v)
    {
        //TODO 额外更宽一些的碰撞检测 判断是否真的下蹲通过或离开
        //("头顶 "+v).LogInfo();
        if (v)
        {
            //"不能站".LogInfo();
            CannotStand = true;
        }
        else if (CannotStand)
        {
            //"站立".LogInfo();
            CannotStand = false;
            ToIdle();
        }
        
    }

    public override void Crouch(bool crouchPressed)
    {
        // 按键
        if (crouchPressed && !param.IsJumping && !param.IsFalling)
        {
            ToCrouch();
        }
        else if (!CannotStand)
        {
            ToIdle();
            
        }
    }

    private void ToCrouch()
    {
        moveSpeedScale = 0.8f;
        CanJump = false;
        // 动画
        
        AnimationManager.Instance.Crouch();
        param.IsCrouch = true;
    }

    private void ToIdle()
    {
        
        moveSpeedScale = 1f;
        CanJump = true;
        // 动画
        AnimationManager.Instance.Idle();


        param.IsCrouch = false;
    }

    

    public override void Move(Vector2 moveVector)
    {
        AnimationManager.Instance.Move(Mathf.Abs(moveVector.x));
        if (moveVector.sqrMagnitude < 0.01)
            return;
        cc2d.Move(moveVector.x * moveSpeedScale, false);
    }

    public override void InitSkill()
    {
        skills.Add(SkillManager.SkillKeymap.MouseLeft, new WaterShieldSkill(this));
        skills.Add(SkillManager.SkillKeymap.MouseRight, new CancelWaterShield(this));
    }

    public override void OnPause()
    {
        // 变身时需要处理自身相关操作
        skills[SkillManager.SkillKeymap.MouseLeft].PressCancel();
    }

    public override void OnResume()
    {
        throw new System.NotImplementedException();
    }
}