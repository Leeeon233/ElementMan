using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlayer : Player
{
    public override void Init()
    {
        CanJump = true;
        CanMove = true;
        JumpMaxNum = 1;
        IsUnconquerable = false;
        moveSpeedScale = 1.2f;
        this.param = new PlayerParam(false, JumpMaxNum, false, 183f);
        InitSkill();
    }

    public override void InitSkill()
    {
        skills.Add(SkillManager.SkillKeymap.MouseLeft, new FlyFireSkill(this));
    }

    public override void OnPause()
    {
        //TODO
    }

    public override void OnResume()
    {
        //TODO
    }
    
    public override void Move(Vector2 moveVector)
    {
        AnimationManager.Instance.Move(Mathf.Abs(moveVector.x));
        if (moveVector.sqrMagnitude < 0.01)
            return;
        cc2d.Move(moveVector.x * moveSpeedScale, false);
    }
}
