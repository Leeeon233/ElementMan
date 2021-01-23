using System;
using QFramework;
using UnityEngine;

public class SkillManager : Singleton<SkillManager>
{
    public enum SkillStatus {Start, Perform, Cancel };
    public enum SkillKeymap {MouseLeft=0, MouseRight };
    private PlayerManager pm;

    private SkillManager()
    {
        pm = PlayerManager.Instance;
    }

    public void Skill_Release(SkillKeymap key, SkillStatus status)
    {
        if (!pm.CurPlayer.skills.ContainsKey(key)) return;
        switch (status)
        {
            case SkillStatus.Start:
                pm.CurPlayer.skills[key].PressStart();
                break;
            case SkillStatus.Perform:
                pm.CurPlayer.skills[key].PressPerform();
                break;
            case SkillStatus.Cancel:
                pm.CurPlayer.skills[key].PressCancel();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(status), status, null);
        }
    }

}
