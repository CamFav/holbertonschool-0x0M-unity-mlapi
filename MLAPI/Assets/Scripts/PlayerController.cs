using Unity.Netcode;
using UnityEngine;


/// <summary>
/// Player's movement and multiplayer synchronization
/// </summary>
public class PlayerController : NetworkBehaviour
{
    public float speed = 5f; // Walking speed

    /// <summary>
    /// Player Controller
    /// </summary>
    private void Update()
    {
        if (!IsOwner) return; // Only local player can control this object

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Send the updated position to the server
        UpdateMovementServerRpc(transform.position);
    }

    /// <summary>
    /// Updates the player's position on the server
    /// </summary>
    /// <param name="newPosition">The position of the player</param>
    [ServerRpc]
    private void UpdateMovementServerRpc(Vector3 newPosition)
    {
        // Update the position on the server
        transform.position = newPosition;

        // Broadcast the new position to all clients
        UpdateMovementClientRpc(newPosition);
    }

    /// <summary>
    /// Updates the player's position on connected clients
    /// </summary>
    /// <param name="newPosition">Position of the player</param>
    [ClientRpc]
    private void UpdateMovementClientRpc(Vector3 newPosition)
    {
        if (IsOwner) return; // Skip for the owning client

        // Update the position for non-owners
        transform.position = newPosition;
    }
}
