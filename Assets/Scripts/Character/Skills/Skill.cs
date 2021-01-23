using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public abstract class Skill
{
    //public SkillData skillData;
    protected bool CanRelease=true;
    protected Camera cam;
    protected Vector3 mousePos;
    protected Player player;


    /// <summary>
    /// 技能按键  按下、按住、抬起  需要实现的功能
    /// </summary>
    public abstract void PressStart();

    public abstract void PressPerform();

    public abstract void PressCancel();

    protected Vector3 GetMousePos()
    {
        return cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }
}