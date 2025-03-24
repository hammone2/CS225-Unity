using UnityEngine;

public class Level1Gate : MonoBehaviour
{
    public enum GateState
    {
        CLOSING,
        OPENING,
        DONE
    }
    private GateState currentState;


    public float openHeight;
    public float closedHeight;
    public float speed = 10f;

    private float newY;

    private void Start()
    {
        newY = transform.position.y;
    }

    private void Update()
    {
        switch (currentState)
        {
            case GateState.CLOSING:
                newY = Mathf.MoveTowards(newY, closedHeight, speed * Time.deltaTime);

                transform.position = new Vector3(transform.position.x, newY, transform.position.z);

                Debug.Log(transform.position.y);

                if (newY >= closedHeight)
                    currentState = GateState.DONE;
                break;

            case GateState.OPENING:
                newY = Mathf.MoveTowards(newY, openHeight, speed * Time.deltaTime);

                transform.position = new Vector3(transform.position.x, newY, transform.position.z);

                Debug.Log(transform.position.y);

                if (newY <= openHeight)
                    currentState = GateState.DONE;
                break;

            case GateState.DONE:
                //do nothing
                break;
        }
    }


    public void Open()
    {
        currentState = GateState.OPENING;
    }

    public void Close()
    {
        currentState = GateState.CLOSING;
    }

    public void Done()
    {
        currentState = GateState.DONE;
    }
}
