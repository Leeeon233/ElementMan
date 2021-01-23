using UnityEngine;
using System.Collections;

public class CancelWaterShield : Skill
{
    public CancelWaterShield(Player player)
    {
        this.player = player;
    }
    private GameObject waterShield;
    public override void PressCancel()
    {
        return;
    }

    public override void PressPerform()
    {
        return;
    }

    public override void PressStart()
    {
        //Debug.Log("取消按键");
        //TODO 是否有更好的方案？  事件？
        waterShield = GameObject.Find("WaterShield(Clone)");
        GameObject.Destroy(waterShield);
    }
}
