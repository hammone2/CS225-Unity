using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class PuzzlePillar : MonoBehaviour, IActivator
{
    public int currentFace = 0, solutionFace = 2;
    [SerializeField] private float m_rotateTime = 2f;
    [SerializeField] private float m_offsetRotation = 0f;
    private bool m_isRotating = false;
    public UnityEvent<int> OnFaceChanged;
    [field: SerializeField] public UnityEvent OnActivate { get; set; }
    [field: SerializeField] public UnityEvent OnDeactivate { get; set; }


    private void Awake()
    {
        transform.localRotation = Quaternion.Euler(0, 120 * currentFace + m_offsetRotation, 0);
    }

    public void Activate()
    {
        if (!m_isRotating)
            StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        if (currentFace == solutionFace)
            OnDeactivate?.Invoke();

        currentFace++;
        if (currentFace > 2) currentFace = 0;

        float timeRotating = m_rotateTime;
        Quaternion start = transform.localRotation;
        Quaternion target = Quaternion.Euler(0, transform.localRotation.eulerAngles.y + 120, 0);
        m_isRotating = true;

        while (timeRotating > 0)
        {
            timeRotating -= Time.deltaTime;
            transform.localRotation = Quaternion.Lerp(start, target, 1 - (timeRotating / m_rotateTime));
            yield return new WaitForEndOfFrame();
        }

        m_isRotating = false;
        OnFaceChanged?.Invoke(currentFace);

        if (currentFace == solutionFace)
            OnActivate?.Invoke();

        yield return null;
    }
}
