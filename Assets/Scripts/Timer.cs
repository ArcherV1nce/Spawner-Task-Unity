using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _timeRemaining;
    private Coroutine _countDown;

    public bool IsFinished => _timeRemaining <= 0;
    public float TimeRemaining => _timeRemaining;

    public Timer (float waitingTime)
    {
        _timeRemaining = waitingTime;
    }

    public void SetTime (float time)
    {
        _timeRemaining = time;
    }

    public void StartCountDown ()
    {
        if (_countDown != null)
        {
            StopCoroutine(_countDown);
            _countDown = null;
        }

        _countDown = StartCoroutine(CountDown());
    }

    private IEnumerator CountDown ()
    {
        while (IsFinished == false)
        {
            _timeRemaining -= Time.deltaTime;
            Debug.Log($"{TimeRemaining} seconds until next spawn.");
            yield return new WaitForFixedUpdate();
        }
    }
}
