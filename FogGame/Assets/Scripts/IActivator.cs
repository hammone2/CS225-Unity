using UnityEngine;
using UnityEngine.Events;

public interface IActivator
{
    UnityEvent OnActivate { get; set; }
    UnityEvent OnDeactivate { get; set; }
}
