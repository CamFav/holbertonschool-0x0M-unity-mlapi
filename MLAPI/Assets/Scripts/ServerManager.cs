using Unity.Netcode;
using UnityEngine;

/// <summary>
/// Manages server and client interactions
/// </summary>
public class ServerManager : MonoBehaviour
{
    public GameObject arenaPrefab; // Arena prefab

    /// <summary>
    /// Starts the server and spawns the arena.
    /// </summary>
    public void startServer()
    {
        if (NetworkManager.Singleton.StartServer())
        {
            Debug.Log("Server started successfully.");

            GameObject arena = Instantiate(arenaPrefab);
            arena.GetComponent<NetworkObject>().Spawn();
        }
        else
        {
            Debug.LogError("Failed to start the server.");
        }
    }

    /// <summary>
    /// Connects the client to the server
    /// </summary>
    public void connectToServer()
    {
      if (NetworkManager.Singleton.StartClient())
        {
            Debug.Log("Client connected successfully.");
        }
        else
        {
            Debug.LogError("Failed to connect client.");
        }
    }
}
