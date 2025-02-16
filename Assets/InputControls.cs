//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/InputControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""6b73eb51-66cb-4b0e-b44b-fb9835b4a689"",
            ""actions"": [
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""Button"",
                    ""id"": ""26e93200-d525-41a4-95ba-16c351c3f7ee"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PressTouch"",
                    ""type"": ""Button"",
                    ""id"": ""6bbb1281-c94e-4df4-ac94-29c6c0a06902"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchPosition_00"",
                    ""type"": ""PassThrough"",
                    ""id"": ""b18f0229-88e1-46d1-8ede-09fa1efa7306"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchPosition_01"",
                    ""type"": ""PassThrough"",
                    ""id"": ""5ae752b0-793e-436a-a848-027f61f27ccf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PrimaryDelta"",
                    ""type"": ""PassThrough"",
                    ""id"": ""9c2a6eee-7e08-47e2-b3b4-53ee4a591226"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""CountTouches"",
                    ""type"": ""Value"",
                    ""id"": ""2b09d6ee-16bd-4490-bcad-67ba7b745234"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""TouchDelta_00"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d92b7cf1-a714-4b62-be13-262f90485683"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TouchDelta_01"",
                    ""type"": ""PassThrough"",
                    ""id"": ""e1cff19d-a0ff-4d78-a3e1-1c3373f22a05"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e30102ba-7c4f-4667-83d6-6cac03262dce"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e7efef3-2e5c-46ee-af1f-9773d204469c"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PressTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8dae9879-19f1-4997-9da2-9eccfadc7aef"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition_00"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""235936c0-4e6b-459f-867f-c93826c5cd05"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition_01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c2ad9c3-c255-4810-9579-a8bc7d2c0f7b"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryDelta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0611fac8-6723-4017-80d7-a16a2aba73bf"",
                    ""path"": ""<Touchscreen>/primaryTouch"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CountTouches"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3e1e88f0-3a84-443a-b457-ba1e731fda75"",
                    ""path"": ""<Touchscreen>/touch0/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta_00"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4cd50f74-d316-4cda-9243-666bf3ef4b38"",
                    ""path"": ""<Touchscreen>/touch1/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchDelta_01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_PrimaryTouch = m_Player.FindAction("PrimaryTouch", throwIfNotFound: true);
        m_Player_PressTouch = m_Player.FindAction("PressTouch", throwIfNotFound: true);
        m_Player_TouchPosition_00 = m_Player.FindAction("TouchPosition_00", throwIfNotFound: true);
        m_Player_TouchPosition_01 = m_Player.FindAction("TouchPosition_01", throwIfNotFound: true);
        m_Player_PrimaryDelta = m_Player.FindAction("PrimaryDelta", throwIfNotFound: true);
        m_Player_CountTouches = m_Player.FindAction("CountTouches", throwIfNotFound: true);
        m_Player_TouchDelta_00 = m_Player.FindAction("TouchDelta_00", throwIfNotFound: true);
        m_Player_TouchDelta_01 = m_Player.FindAction("TouchDelta_01", throwIfNotFound: true);
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
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_PrimaryTouch;
    private readonly InputAction m_Player_PressTouch;
    private readonly InputAction m_Player_TouchPosition_00;
    private readonly InputAction m_Player_TouchPosition_01;
    private readonly InputAction m_Player_PrimaryDelta;
    private readonly InputAction m_Player_CountTouches;
    private readonly InputAction m_Player_TouchDelta_00;
    private readonly InputAction m_Player_TouchDelta_01;
    public struct PlayerActions
    {
        private @InputControls m_Wrapper;
        public PlayerActions(@InputControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @PrimaryTouch => m_Wrapper.m_Player_PrimaryTouch;
        public InputAction @PressTouch => m_Wrapper.m_Player_PressTouch;
        public InputAction @TouchPosition_00 => m_Wrapper.m_Player_TouchPosition_00;
        public InputAction @TouchPosition_01 => m_Wrapper.m_Player_TouchPosition_01;
        public InputAction @PrimaryDelta => m_Wrapper.m_Player_PrimaryDelta;
        public InputAction @CountTouches => m_Wrapper.m_Player_CountTouches;
        public InputAction @TouchDelta_00 => m_Wrapper.m_Player_TouchDelta_00;
        public InputAction @TouchDelta_01 => m_Wrapper.m_Player_TouchDelta_01;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @PrimaryTouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryTouch;
                @PressTouch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressTouch;
                @PressTouch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressTouch;
                @PressTouch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPressTouch;
                @TouchPosition_00.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_00;
                @TouchPosition_00.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_00;
                @TouchPosition_00.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_00;
                @TouchPosition_01.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_01;
                @TouchPosition_01.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_01;
                @TouchPosition_01.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchPosition_01;
                @PrimaryDelta.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryDelta;
                @PrimaryDelta.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryDelta;
                @PrimaryDelta.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrimaryDelta;
                @CountTouches.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCountTouches;
                @CountTouches.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCountTouches;
                @CountTouches.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCountTouches;
                @TouchDelta_00.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_00;
                @TouchDelta_00.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_00;
                @TouchDelta_00.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_00;
                @TouchDelta_01.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_01;
                @TouchDelta_01.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_01;
                @TouchDelta_01.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnTouchDelta_01;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouch;
                @PressTouch.started += instance.OnPressTouch;
                @PressTouch.performed += instance.OnPressTouch;
                @PressTouch.canceled += instance.OnPressTouch;
                @TouchPosition_00.started += instance.OnTouchPosition_00;
                @TouchPosition_00.performed += instance.OnTouchPosition_00;
                @TouchPosition_00.canceled += instance.OnTouchPosition_00;
                @TouchPosition_01.started += instance.OnTouchPosition_01;
                @TouchPosition_01.performed += instance.OnTouchPosition_01;
                @TouchPosition_01.canceled += instance.OnTouchPosition_01;
                @PrimaryDelta.started += instance.OnPrimaryDelta;
                @PrimaryDelta.performed += instance.OnPrimaryDelta;
                @PrimaryDelta.canceled += instance.OnPrimaryDelta;
                @CountTouches.started += instance.OnCountTouches;
                @CountTouches.performed += instance.OnCountTouches;
                @CountTouches.canceled += instance.OnCountTouches;
                @TouchDelta_00.started += instance.OnTouchDelta_00;
                @TouchDelta_00.performed += instance.OnTouchDelta_00;
                @TouchDelta_00.canceled += instance.OnTouchDelta_00;
                @TouchDelta_01.started += instance.OnTouchDelta_01;
                @TouchDelta_01.performed += instance.OnTouchDelta_01;
                @TouchDelta_01.canceled += instance.OnTouchDelta_01;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnPressTouch(InputAction.CallbackContext context);
        void OnTouchPosition_00(InputAction.CallbackContext context);
        void OnTouchPosition_01(InputAction.CallbackContext context);
        void OnPrimaryDelta(InputAction.CallbackContext context);
        void OnCountTouches(InputAction.CallbackContext context);
        void OnTouchDelta_00(InputAction.CallbackContext context);
        void OnTouchDelta_01(InputAction.CallbackContext context);
    }
}
