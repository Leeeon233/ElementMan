using UnityEngine;

/// <summary>
/// Ese游戏暂停跳出菜单
/// 游戏从上一次记录点开始
/// 游戏继续
/// 游戏退出
/// </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField] private int FPS = 60;

    private void Awake()
    {
        Application.targetFrameRate = FPS;
    }

    
}