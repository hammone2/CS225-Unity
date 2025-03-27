using System;
using System.Collections;
using UnityEngine;

public class MetalGate : MonoBehaviour
{
    [SerializeField] private float m_gateSpeed = 2f;
    [SerializeField] private float m_startHeight;
    [SerializeField] private float m_endHeight;

    private void Reset()
    {
        m_startHeight = transform.position.y;
        m_endHeight = m_startHeight + 10;
    }
    public void Open()
    {
        StopAllCoroutines();
        StartCoroutine(OpenGate());
    }
    public void Close()
    {
        StopAllCoroutines();
        StartCoroutine(CloseGate());
    }

    private IEnumerator OpenGate()
    {
        while(transform.position.y < m_endHeight)
        {
            transform.position += new Vector3(0, 1, 0) * Time.deltaTime * m_gateSpeed;
            yield return new WaitForEndOfFrame();
        }
    }

    private IEnumerator CloseGate()
    {
        while (transform.position.y > m_startHeight)
        {
            transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * m_gateSpeed;
            yield return new WaitForEndOfFrame();
        }
    }
}
