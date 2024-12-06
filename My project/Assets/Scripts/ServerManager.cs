using Unity.Netcode;
using UnityEngine;

public class ServerManager : MonoBehaviour
{
    public GameObject arenaPrefab;

    /// <summary>
    /// Starts the server
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
}
