using UnityEngine;
using UnityEngine.Events;

public class PillarPuzzle : MonoBehaviour, IActivator
{
    [SerializeField] private Vector3Int m_solution;
    [SerializeField] private PuzzlePillar m_pillar1, m_pillar2, m_pillar3;

    [field: SerializeField] public UnityEvent OnActivate { get; set; }
    [field: SerializeField] public UnityEvent OnDeactivate { get; set; }

    public void CheckResult()
    {
        if (m_pillar1.currentFace == m_solution.x && m_pillar2.currentFace == m_solution.y && m_pillar3.currentFace == m_solution.z)
        {
            OnActivate?.Invoke();
        } else
        {
            OnDeactivate?.Invoke();
        }
    }
}
