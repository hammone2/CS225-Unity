using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public void GetPickedUp()
    {
        Destroy(gameObject); //this is obviously temporary
    }
}
