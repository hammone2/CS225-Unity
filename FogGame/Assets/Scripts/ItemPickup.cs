using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private bool pickedUp = false;
    private Rigidbody rb;

    public void Interaction()
    {
        if (pickedUp == false)
            GetPickedUp();
        else
            Drop();
    }

    private void GetPickedUp()
    {
        if (GameManager.player == null)
            return;
        if (GameManager.player.isHoldingObject == true)
            return;
        pickedUp = true;
        GameManager.player.isHoldingObject = true;
        Transform hand = GameManager.player.hand.transform;
        transform.position = hand.position;
        transform.SetParent(hand);
        if (rb)
            rb.useGravity = false;
    }

    private void Drop()
    {
        if (rb)
            rb.useGravity = true;
        transform.SetParent(null);
        pickedUp = false;
        GameManager.player.isHoldingObject = false;
        rb.AddForce(GameManager.player.hand.transform.forward * 1000f, ForceMode.Force);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!pickedUp)
            return;
        transform.position = Vector3.MoveTowards(transform.position, GameManager.player.hand.transform.position, 5 * Time.deltaTime);
    }
}
