using UnityEngine;

public class Glider : MonoBehaviour
{
    public Transform orientation; // Reference to the empty object (player's orientation)
    public Transform model; // Reference to the player's model (the object you want to rotate)

    public float rotationSpeed = 10f; // Rotation speed for the model
    public Vector3 rotationOffset = Vector3.zero; // Rotation offset to apply to the model's rotation

    private void Awake()
    {
        UpdateModelRotation();  
    }

    private void Update()
    {
        // Sync the model rotation with the orientation, applying the offset
        UpdateModelRotation();
    }



    // Sync the model's rotation with the orientation object and apply the offset
    private void UpdateModelRotation()
    {
        // Calculate the target rotation based on the orientation and apply the offset
        Quaternion targetRotation = Quaternion.Euler(0f, orientation.eulerAngles.y + rotationOffset.y, 0f);

        // Smoothly rotate the model towards the target rotation
        model.rotation = Quaternion.Slerp(model.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}