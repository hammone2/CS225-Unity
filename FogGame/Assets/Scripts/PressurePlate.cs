using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour, IActivator
{
    /// <summary>
    /// Called when the pressure plate is pressed.
    /// </summary>
    [field: SerializeField] public UnityEvent OnActivate { get; set; }
    /// <summary>
    /// Called when the pressure plate is released.
    /// </summary>
    [field: SerializeField] public UnityEvent OnDeactivate { get; set; }

    private Animator m_animator;
    private List<Collider> m_collidingObjects;

    private bool IsDown { get 
        {
            if (m_collidingObjects != null)
            {
                return m_collidingObjects.Count > 0;
            }
            return true;
        }
    }

    private void OnEnable()
    {
        m_animator = GetComponent<Animator>();
        m_collidingObjects = new();

        OnActivate ??= new();
        OnDeactivate ??= new();
    }

    private void OnTriggerStay(Collider other)
    {
        bool wasDown = IsDown;

        if (!m_collidingObjects.Contains(other))
        {
            m_collidingObjects.Add((other));
        }

        UpdatePlate(wasDown);
    }

    private void UpdatePlate(bool wasDown)
    {
        if (wasDown != IsDown)
        {
            m_animator.SetBool("isDown", IsDown);
            if (IsDown)
                OnActivate?.Invoke();
            else
                OnDeactivate?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        bool wasDown = IsDown;

        if (m_collidingObjects.Contains(other))
        {
            m_collidingObjects.Remove(other);
        }

        UpdatePlate(wasDown);
    }
}
