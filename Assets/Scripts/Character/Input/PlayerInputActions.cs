// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Character/Input/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""GamePlay"",
            ""id"": ""52689693-33b9-498d-a80d-1e5339f98565"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""475c4d57-8919-44b0-a0a0-c5e53ce6f6f4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""51045687-dc16-41a9-8c84-a6f017eb4c23"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""84a13452-7b95-42fd-ac84-c3bcebe0ecef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Skill_Mouse_Left"",
                    ""type"": ""Button"",
                    ""id"": ""ffb1b61d-ade1-4fa0-b04f-605f2a008b37"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Skill_Mouse_Right"",
                    ""type"": ""Button"",
                    ""id"": ""e9e45975-0f13-49ea-bdc1-02df14af6892"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Last_Player"",
                    ""type"": ""Button"",
                    ""id"": ""67f5ab6c-1e27-46d9-968c-b42437679271"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Next_Player"",
                    ""type"": ""Button"",
                    ""id"": ""339cbcf3-a4cd-424d-8ecf-93c975b38ede"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""13e4f0f1-0c44-4369-b0ea-876cbf7764e9"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6fba9012-e670-4cbb-82b7-93918b894e26"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""71ec02a8-c918-4683-b605-c958dedc1921"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""71923228-462f-4b0a-ab6c-20f47874e567"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c4fa57cc-1a6d-4a63-9bff-18c81192e457"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b53a295f-9be7-48bd-a81e-829fcc445fe5"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f080c0f2-fecb-489c-9ee9-643c47eb39e5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60c97bda-c891-4adc-8924-b4d8d8dc45b9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff4f361e-9ed4-4638-9bc5-08c40b921fdc"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a176389-8ff6-429d-afd3-d2eb69cdb165"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_Mouse_Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ca73366-2a52-462a-95f2-20492bdde304"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Skill_Mouse_Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a453f42-fb7f-429b-9fc0-ce84c81e44dc"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Last_Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f8b2f5db-1bad-4c4b-805b-cc55d6bff014"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Next_Player"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GamePlay
        m_GamePlay = asset.FindActionMap("GamePlay", throwIfNotFound: true);
        m_GamePlay_Movement = m_GamePlay.FindAction("Movement", throwIfNotFound: true);
        m_GamePlay_Jump = m_GamePlay.FindAction("Jump", throwIfNotFound: true);
        m_GamePlay_Crouch = m_GamePlay.FindAction("Crouch", throwIfNotFound: true);
        m_GamePlay_Skill_Mouse_Left = m_GamePlay.FindAction("Skill_Mouse_Left", throwIfNotFound: true);
        m_GamePlay_Skill_Mouse_Right = m_GamePlay.FindAction("Skill_Mouse_Right", throwIfNotFound: true);
        m_GamePlay_Last_Player = m_GamePlay.FindAction("Last_Player", throwIfNotFound: true);
        m_GamePlay_Next_Player = m_GamePlay.FindAction("Next_Player", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // GamePlay
    private readonly InputActionMap m_GamePlay;
    private IGamePlayActions m_GamePlayActionsCallbackInterface;
    private readonly InputAction m_GamePlay_Movement;
    private readonly InputAction m_GamePlay_Jump;
    private readonly InputAction m_GamePlay_Crouch;
    private readonly InputAction m_GamePlay_Skill_Mouse_Left;
    private readonly InputAction m_GamePlay_Skill_Mouse_Right;
    private readonly InputAction m_GamePlay_Last_Player;
    private readonly InputAction m_GamePlay_Next_Player;
    public struct GamePlayActions
    {
        private @PlayerInputActions m_Wrapper;
        public GamePlayActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GamePlay_Movement;
        public InputAction @Jump => m_Wrapper.m_GamePlay_Jump;
        public InputAction @Crouch => m_Wrapper.m_GamePlay_Crouch;
        public InputAction @Skill_Mouse_Left => m_Wrapper.m_GamePlay_Skill_Mouse_Left;
        public InputAction @Skill_Mouse_Right => m_Wrapper.m_GamePlay_Skill_Mouse_Right;
        public InputAction @Last_Player => m_Wrapper.m_GamePlay_Last_Player;
        public InputAction @Next_Player => m_Wrapper.m_GamePlay_Next_Player;
        public InputActionMap Get() { return m_Wrapper.m_GamePlay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GamePlayActions set) { return set.Get(); }
        public void SetCallbacks(IGamePlayActions instance)
        {
            if (m_Wrapper.m_GamePlayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnJump;
                @Crouch.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Crouch.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Crouch.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnCrouch;
                @Skill_Mouse_Left.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Left;
                @Skill_Mouse_Left.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Left;
                @Skill_Mouse_Left.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Left;
                @Skill_Mouse_Right.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Right;
                @Skill_Mouse_Right.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Right;
                @Skill_Mouse_Right.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnSkill_Mouse_Right;
                @Last_Player.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLast_Player;
                @Last_Player.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLast_Player;
                @Last_Player.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnLast_Player;
                @Next_Player.started -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNext_Player;
                @Next_Player.performed -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNext_Player;
                @Next_Player.canceled -= m_Wrapper.m_GamePlayActionsCallbackInterface.OnNext_Player;
            }
            m_Wrapper.m_GamePlayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Crouch.started += instance.OnCrouch;
                @Crouch.performed += instance.OnCrouch;
                @Crouch.canceled += instance.OnCrouch;
                @Skill_Mouse_Left.started += instance.OnSkill_Mouse_Left;
                @Skill_Mouse_Left.performed += instance.OnSkill_Mouse_Left;
                @Skill_Mouse_Left.canceled += instance.OnSkill_Mouse_Left;
                @Skill_Mouse_Right.started += instance.OnSkill_Mouse_Right;
                @Skill_Mouse_Right.performed += instance.OnSkill_Mouse_Right;
                @Skill_Mouse_Right.canceled += instance.OnSkill_Mouse_Right;
                @Last_Player.started += instance.OnLast_Player;
                @Last_Player.performed += instance.OnLast_Player;
                @Last_Player.canceled += instance.OnLast_Player;
                @Next_Player.started += instance.OnNext_Player;
                @Next_Player.performed += instance.OnNext_Player;
                @Next_Player.canceled += instance.OnNext_Player;
            }
        }
    }
    public GamePlayActions @GamePlay => new GamePlayActions(this);
    public interface IGamePlayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnSkill_Mouse_Left(InputAction.CallbackContext context);
        void OnSkill_Mouse_Right(InputAction.CallbackContext context);
        void OnLast_Player(InputAction.CallbackContext context);
        void OnNext_Player(InputAction.CallbackContext context);
    }
}
