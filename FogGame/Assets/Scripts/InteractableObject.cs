using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public UnityEvent onInteracted;

    public void InteractedWith()
    {
        if (onInteracted != null)
            onInteracted.Invoke();
    }
}
