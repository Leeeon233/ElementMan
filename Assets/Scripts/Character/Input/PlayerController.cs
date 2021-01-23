using System;
using System.Collections.Generic;
using QFramework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputAction;
    private PlayerManager pm;
    private SkillManager sm;
    private Player curPlayer;
    private Dictionary<string, SkillManager.SkillKeymap> SkillInputMap = new Dictionary<string, SkillManager.SkillKeymap>();

    // Use this for initialization
    private void Awake()
    {
        inputAction = new PlayerInputActions();
        SkillInputMap.Add("Skill_Mouse_Left", SkillManager.SkillKeymap.MouseLeft);
        SkillInputMap.Add("Skill_Mouse_Right", SkillManager.SkillKeymap.MouseRight);

        pm = PlayerManager.Instance;
        sm = SkillManager.Instance;
    }

    private void Start()
    {
        curPlayer = pm.GetDefaultPlayer();

    }

    // Update is called once per frame
    private void Update()
    {
        var move = inputAction.GamePlay.Movement.ReadValue<Vector2>();
        curPlayer.Move(move);
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.GamePlay.Jump.performed += Jump;
        inputAction.GamePlay.Crouch.performed += Crouch;
        inputAction.GamePlay.Skill_Mouse_Left.performed += SkillButtonInput;
        inputAction.GamePlay.Skill_Mouse_Right.performed += SkillButtonInput;

        inputAction.GamePlay.Last_Player.performed += Last_Player_performed;
        inputAction.GamePlay.Next_Player.performed += Next_Player_performed;
    }

    private void Next_Player_performed(InputAction.CallbackContext context)
    {
        curPlayer = pm.ChangeForm(true);
    }

    private void Last_Player_performed(InputAction.CallbackContext context)
    {
        curPlayer = pm.ChangeForm(false);
    }

    private void SkillButtonInput(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            sm.Skill_Release(SkillInputMap[context.action.name], SkillManager.SkillStatus.Start);
        }
        else
        {
            sm.Skill_Release(SkillInputMap[context.action.name], SkillManager.SkillStatus.Cancel);
        }
    }

    private void Crouch(InputAction.CallbackContext context)
    {
        curPlayer.Crouch(context.ReadValueAsButton());
    }

    private void Jump(InputAction.CallbackContext context)
    {
        curPlayer.Jump(context.ReadValueAsButton());
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.GamePlay.Jump.performed -= Jump;
        inputAction.GamePlay.Crouch.performed -= Crouch;
        inputAction.GamePlay.Skill_Mouse_Left.performed -= SkillButtonInput;
        inputAction.GamePlay.Skill_Mouse_Right.performed -= SkillButtonInput;
        inputAction.GamePlay.Last_Player.performed -= Last_Player_performed;
        inputAction.GamePlay.Next_Player.performed -= Next_Player_performed;
    }
}