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

    private void OnEnable()
    {
        OnActivate ??= new();
        OnDeactivate ??= new();
    }

    private void OnTriggerEnter(Collider other)
    {
        OnActivate?.Invoke();
        Debug.Log("Pressure Plate Activated");
    }

    private void OnTriggerExit(Collider other)
    {
        OnDeactivate?.Invoke();
        Debug.Log("Pressure Plate Deactivated");
    }
}
