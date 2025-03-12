using UnityEngine;
using UnityEngine.Events;

[SelectionBase]
public class Button : MonoBehaviour, IActivator
{
    [SerializeField] bool m_isToggle = false;
    [HideInInspector] internal bool isActivated = false;

    /// <summary>
    /// Called when the button is pressed. Not called when deactivated if it is a toggle.
    /// </summary>
    [field: SerializeField] public UnityEvent OnActivate { get; set; }
    /// <summary>
    /// Called when the button is deactivated and only when the button is a toggle.
    /// </summary>
    [field: SerializeField] public UnityEvent OnDeactivate { get; set; }

    /// <summary>
    /// Activates the button.
    /// </summary>
    public void Activate()
    {
        Debug.Log("Button pressed");

        if(m_isToggle)
        {
            isActivated = !isActivated;
            if (isActivated) OnActivate?.Invoke();
            else OnDeactivate?.Invoke();
        } 
        else
        {
            OnActivate?.Invoke();
        }
    }
}
