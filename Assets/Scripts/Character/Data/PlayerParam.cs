using System;

[Serializable]
public struct PlayerParam
{
    public bool IsJumping;
    public bool IsCrouch;
    public byte JumpNumLeft;
    public bool IsFalling;
    public float Temperature;

    public PlayerParam(bool isJumping, byte jumpNumLeft, bool isFalling, float temperature)
    {
        IsJumping = isJumping;
        JumpNumLeft = jumpNumLeft;
        IsFalling = isFalling;
        Temperature = temperature;
        IsCrouch = false;
    }
}