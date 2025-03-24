using UnityEngine;

public class Level1Bridge : MonoBehaviour
{
    private bool isExtending = false;
    public float rotationSpeed = 10f;
    private float targetRotationX = 0f;

    private void Update()
    {
        if (!isExtending)
            return;

        float newRotationX = Mathf.MoveTowardsAngle(transform.rotation.eulerAngles.x, targetRotationX, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(newRotationX, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    public void Extend()
    {
        if (isExtending)
            return;
        isExtending = true;
    }

}
