// GENERATED AUTOMATICALLY FROM 'Assets/InputActions/TouchControl.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchControl : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchControl"",
    ""maps"": [
        {
            ""name"": ""PlayerTouch"",
            ""id"": ""64ae445c-74e4-4509-a59c-712a530583be"",
            ""actions"": [
                {
                    ""name"": ""TouchPosition"",
                    ""type"": ""Value"",
                    ""id"": ""32bea8b5-e7d2-4413-a8c2-f545f0214a10"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrimaryTouch"",
                    ""type"": ""Button"",
                    ""id"": ""95fabf0c-1c4d-470f-afd7-2022a1455d46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""0ec0a898-d346-4beb-a539-104d5bd12ed9"",
                    ""path"": ""<Touchscreen>/primaryTouch/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2d5997b-0ae2-4ec1-b85a-1115b4068b29"",
                    ""path"": ""<Touchscreen>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrimaryTouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerTouch
        m_PlayerTouch = asset.FindActionMap("PlayerTouch", throwIfNotFound: true);
        m_PlayerTouch_TouchPosition = m_PlayerTouch.FindAction("TouchPosition", throwIfNotFound: true);
        m_PlayerTouch_PrimaryTouch = m_PlayerTouch.FindAction("PrimaryTouch", throwIfNotFound: true);
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

    // PlayerTouch
    private readonly InputActionMap m_PlayerTouch;
    private IPlayerTouchActions m_PlayerTouchActionsCallbackInterface;
    private readonly InputAction m_PlayerTouch_TouchPosition;
    private readonly InputAction m_PlayerTouch_PrimaryTouch;
    public struct PlayerTouchActions
    {
        private @TouchControl m_Wrapper;
        public PlayerTouchActions(@TouchControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPosition => m_Wrapper.m_PlayerTouch_TouchPosition;
        public InputAction @PrimaryTouch => m_Wrapper.m_PlayerTouch_PrimaryTouch;
        public InputActionMap Get() { return m_Wrapper.m_PlayerTouch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerTouchActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerTouchActions instance)
        {
            if (m_Wrapper.m_PlayerTouchActionsCallbackInterface != null)
            {
                @TouchPosition.started -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.performed -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnTouchPosition;
                @TouchPosition.canceled -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnTouchPosition;
                @PrimaryTouch.started -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.performed -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnPrimaryTouch;
                @PrimaryTouch.canceled -= m_Wrapper.m_PlayerTouchActionsCallbackInterface.OnPrimaryTouch;
            }
            m_Wrapper.m_PlayerTouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPosition.started += instance.OnTouchPosition;
                @TouchPosition.performed += instance.OnTouchPosition;
                @TouchPosition.canceled += instance.OnTouchPosition;
                @PrimaryTouch.started += instance.OnPrimaryTouch;
                @PrimaryTouch.performed += instance.OnPrimaryTouch;
                @PrimaryTouch.canceled += instance.OnPrimaryTouchPhase;
            }
        }
    }
    public PlayerTouchActions @PlayerTouch => new PlayerTouchActions(this);
    public interface IPlayerTouchActions
    {
        void OnTouchPosition(InputAction.CallbackContext context);
        void OnPrimaryTouch(InputAction.CallbackContext context);
        void OnPrimaryTouchPhase(InputAction.CallbackContext context);
    }
}
