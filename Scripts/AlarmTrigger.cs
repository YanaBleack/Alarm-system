using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlarmTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent _playerEntered;
    [SerializeField] private UnityEvent _playerExited;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Зашел");


        if (other.TryGetComponent<Player>(out Player player))
        {         
            _playerEntered?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Вышел");


        if (other.TryGetComponent<Player>(out Player player))
        {
            _playerExited?.Invoke();
        }
    }
}
