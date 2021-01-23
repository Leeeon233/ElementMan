using System;
using QFramework;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    // Start is called before the first frame update
    public Player[] players;

    private int playerNum;
    private int curPlayerIndex;
    public Player CurPlayer => players[curPlayerIndex];

    private bool canChange = true;

    private PlayerManager() { }


    private void Start()
    {
        playerNum = players.Length;
        curPlayerIndex = 0;
    }

    public Player GetDefaultPlayer()
    {
        return players[0];
    }


    public Player ChangeForm(bool next)
    {
        
        if (canChange && !CurPlayer.CannotStand && !CurPlayer.param.IsCrouch)
        {
            canChange = false;
            int n = next ? 1 : -1;
            int nextPlayerIndex = (curPlayerIndex + playerNum + n) % playerNum;
            canChange = true;
            return ChangeByIndex(nextPlayerIndex, CurPlayer.param);
        }
        return null;
    }

    private Player ChangeByIndex(int idx, PlayerParam param)
    {
        // 当前人物暂停，处理自身相关数据。
        players[curPlayerIndex].OnPause();
        players[curPlayerIndex].gameObject.SetActive(false);

        curPlayerIndex = idx;
        players[idx].setPararm(param);
        players[idx].gameObject.SetActive(true);
        return players[idx];
    }
}