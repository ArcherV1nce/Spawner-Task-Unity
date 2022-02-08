using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine _countDown;

    public bool IsFinished => TimeRemaining <= 0;
    public float TimeRemaining { get; private set; }

    public Timer (float waitingTime)
    {
        TimeRemaining = waitingTime;
    }

    public void SetTime (float time)
    {
        Reset();

        TimeRemaining = time;
    }

    public void StartCountDown ()
    {
        Reset();

        _countDown = StartCoroutine(CountDown());
    }

    private void Reset()
    {
        if (_countDown != null)
        {
            StopCoroutine(_countDown);
            _countDown = null;
        }
    }

    private IEnumerator CountDown ()
    {
        while (IsFinished == false)
        {
            TimeRemaining -= Time.deltaTime;
            Debug.Log($"{TimeRemaining} seconds until next spawn.");
            yield return new WaitForFixedUpdate();
        }
    }
}
