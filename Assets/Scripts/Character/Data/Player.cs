using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;

/// <summary>
/// 基础人物类
/// 包括各类人物的通用状态数据
/// 通用技能
/// </summary>
public abstract class Player : MonoBehaviour
{
    public enum CharacterForm : byte { Water, Fire, Thunder };

    public PlayerParam param;
    public Dictionary<SkillManager.SkillKeymap, Skill> skills = new Dictionary<SkillManager.SkillKeymap, Skill>();
    protected float moveSpeedScale;
    public bool CanJump;
    public bool CanMove;
    public bool CannotStand;
    protected byte JumpMaxNum;
    protected bool IsUnconquerable;

    protected bool CanChangeGravity = true;
    
    protected CharacterController2D cc2d;
    [SerializeField] protected Transform CeilingCheck;
    [SerializeField] protected Transform GroundCheck;

    private void Start()
    {
        cc2d = GetComponentInParent<CharacterController2D>();
        cc2d.OnLandEvent.AddListener(OnLand);
        cc2d.m_CeilingCheck = CeilingCheck;
        cc2d.m_GroundCheck = GroundCheck;
        Init();
    }

    public void SetCc2dGravity(bool b)
    {
        cc2d.m_canChangeGravity = b;
    }
    

    public void setPararm(PlayerParam param)
    {
        this.param = param;
    }

    public abstract void Init();
    public abstract void InitSkill();
    public abstract void OnPause();
    public abstract void OnResume();

    public virtual void Move(Vector2 moveVector)
    {
        if(cc2d) cc2d.Move(moveVector.x * moveSpeedScale, false);
    }

    public virtual void Jump(bool jumpPressed)
    {
        if (!CanJump || !jumpPressed || param.JumpNumLeft <= 0) return;
        cc2d.Move(0, true);
        param.IsJumping = true;
        param.JumpNumLeft--;
        //"跳跃数--".LogInfo();
    }

    public virtual void Crouch(bool v)
    {
    }

    public virtual void OnLand(bool v)
    {
        if (v)
        {
            "落地".LogInfo();
            param.IsJumping = false;
            param.IsFalling = false;
            param.JumpNumLeft = JumpMaxNum;
        }
        // else
        // {
        //     param.IsJumping = true;
        //     param.IsFalling = true;
        // }
    }
}