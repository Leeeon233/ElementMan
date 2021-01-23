using QFramework;
using UnityEngine;


public class AnimationManager : Singleton<AnimationManager>
{
    public static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
    public static readonly int AnimationSpeed = Animator.StringToHash("AnimationSpeed");
    public static readonly int IsCrouch = Animator.StringToHash("IsCrouch");
    public static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private Player _curPlayer;
    private Animator _anim;


    // Use this for initialization
    private AnimationManager()
    {
        
    }
    public override void OnSingletonInit()
    {
        "初始化AnimationManager".LogInfo();
        
    }

    public void Move(float moveSpeed)
    {
        _anim = getAnimator();
        _anim.SetFloat(MoveSpeed, moveSpeed);
    }

    public void Crouch()
    {
        _anim = getAnimator();
        _anim.SetBool(IsCrouch, true);
    }

    public void Idle()
    {
        _anim = getAnimator();
        _anim.SetBool(IsCrouch, false);
        //_anim.SetBool(IsJumping, false);
    }
    
    private Animator getAnimator()
    {
        _curPlayer = PlayerManager.Instance.CurPlayer;
        return _curPlayer.GetComponent<Animator>();
    }
}
