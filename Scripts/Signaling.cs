using System.Collections;
using UnityEngine;

public class Signaling : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField]private SignalingSencor _signalingSencor;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _signalingSencor.Entered += OnEntered;
        _signalingSencor.Exited += OnExited;
    }

    private void OnDisable()
    {
        _signalingSencor.Entered -= OnEntered;
        _signalingSencor.Exited -= OnExited;
    }

    public void OnEntered() => RestartSignaling(_audioSource.maxDistance);

    public void OnExited() => RestartSignaling(_audioSource.minDistance);

    private void RestartSignaling(float value)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangingVolume(value));
    }

    private IEnumerator ChangingVolume(float targetVolume)
    {
        float changingVolume = 0.1f;

        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, changingVolume * Time.deltaTime);

            yield return null;
        }

        if (_audioSource.volume == _audioSource.minDistance)
            _audioSource.Stop();
    }
}