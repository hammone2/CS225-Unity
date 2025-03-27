using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class PuzzlePillar : MonoBehaviour
{
    public int currentFace = 0;
    [SerializeField] private float m_rotateTime = 2f;
    [SerializeField] private float m_offsetRotation = 0f;
    private bool m_isRotating = false;
    public UnityEvent<int> OnFaceChanged;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, 120 * currentFace + m_offsetRotation, 0);
    }

    public void Activate()
    {
        if (!m_isRotating)
            StartCoroutine(Rotate());
    }

    IEnumerator Rotate()
    {
        currentFace++;
        if (currentFace > 2) currentFace = 0;

        float timeRotating = m_rotateTime;
        Quaternion start = transform.rotation;
        Quaternion target = Quaternion.Euler(0, transform.eulerAngles.y + 120, 0);
        m_isRotating = true;
        while (timeRotating > 0)
        {
            timeRotating -= Time.deltaTime;
            transform.rotation = Quaternion.Lerp(start, target, 1 - (timeRotating / m_rotateTime));
            yield return new WaitForEndOfFrame();
        }
        m_isRotating = false;
        OnFaceChanged?.Invoke(currentFace);
        yield return null;
    }
}
