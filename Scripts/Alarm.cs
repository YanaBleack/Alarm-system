using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _delayTime = 0.5f;

    private const float MaxVolumValue = 1f;
    private const float MinVolumValue = 0f;

    private Coroutine _fadeCoroutine;

    public void Play()
    {
        _audioSource.Play();
        Restart(MaxVolumValue); 
    }

    public void Stop()
    {
        Restart(MinVolumValue);        
    }

    private void Restart(float targetVolume)       
    {
        if(_fadeCoroutine != null)
        {
            StopCoroutine(_fadeCoroutine);
        }

        _fadeCoroutine = StartCoroutine(Fading(targetVolume));    
    }

    private IEnumerator Fading(float targetVolume)
    {
        float interpolationValue = 0.1f;

        WaitForSeconds delay = new WaitForSeconds( _delayTime );

        while(_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, interpolationValue);

            yield return delay;
        } 

        _fadeCoroutine = null;     
    }
}
