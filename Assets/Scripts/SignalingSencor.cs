using System;
using UnityEngine;

public class SignalingSencor : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public event Action Entered;
    public event Action Exited;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            Entered?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            Exited?.Invoke();
    }
}
