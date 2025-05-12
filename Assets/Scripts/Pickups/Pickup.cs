using UnityEngine;

public class Pickup : MonoBehaviour
{
    private const string playerString = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
            Debug.Log(other.gameObject.name);
    }
}