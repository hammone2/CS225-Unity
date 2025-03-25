using UnityEngine;
using System.Collections; //for Ienum

public class Level2Gates : MonoBehaviour
{
    public GameObject[] gates;
    public float openPos = 45.6f;
    public float closedPos = 57.88f;
    public float speed = 10f;
    public float deactivationTime = 14f;
    private float currentXPos;


    private void Start()
    {
        StartCoroutine(Open());
        currentXPos = transform.position.x;
    }

    public void Deactivate()
    {
        StopAllCoroutines(); //probably better to stop the specific/current routine
        StartCoroutine(ReactivationTimer());
    }

    IEnumerator ReactivationTimer()
    {
        yield return new WaitForSeconds(deactivationTime);
        StartCoroutine(Open()); //change this to prev routine. store the routiune in a variable
    }

    IEnumerator Open()
    {
        while (currentXPos != openPos)
        {
            currentXPos = Mathf.MoveTowards(currentXPos, openPos, speed * Time.deltaTime);
            for (int i = 0; i < gates.Length; i++)
            {
                Transform gate = gates[i].transform;
                gate.position = new Vector3(currentXPos, gate.position.y, gate.position.z);
            }
            yield return null; //wait for next frame
        }
        Debug.Log("Opened");
        StartCoroutine(Close());
    }

    IEnumerator Close()
    {
        do //do-while ensures that the code in do{} is executed at least once
        {
            currentXPos = Mathf.MoveTowards(currentXPos, closedPos, speed * Time.deltaTime);
            for (int i = 0; i < gates.Length; i++)
            {
                Transform gate = gates[i].transform;
                gate.position = new Vector3(currentXPos, gate.position.y, gate.position.z);
            }

            yield return null;

        } while (currentXPos != closedPos);

        Debug.Log("Closed");
        StartCoroutine(Open());
    }
}
