using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 技能数据
/// 
/// </summary>
[Serializable]
public class SkillData
{
    //技能ID
    public int skillID;
    //技能名称
    public string skillName;
    //技能描述
    public string skillDescription;
    //技能冷却
    public float coolDownTime;
    //剩余冷却
    public float coolDownRemain;
    //最大（攻击）距离
    public float maxDistance;
    //持续时间
    public float durationTime;
    //作用对象
    public GameObject[] impactObjects;
    //技能所属
    public GameObject owner;

    //预制件名称
    public string prefabName;
    //预制件对象
    public GameObject prefabObject;
    //动画名称
    public string animationName;

}
