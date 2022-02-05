using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private List<CharacterSpawnInfo> _objectsInfo;
    [SerializeField, Range (0f, 30f)] private float _spawnDelay;
    [SerializeField] private bool _isLooped;

    private int _currentSpawnInfoNumber;
    private Timer _spawnTimer;
    private Coroutine _spawningCoroutine;

    public void AddSpawnInfo (CharacterSpawnInfo spawnInfo)
    {
        _objectsInfo.Add (spawnInfo);
    }

    private void OnValidate()
    {
        if (_objectsInfo == null)
        {
            _objectsInfo = new List<CharacterSpawnInfo> ();
        }

        if (_currentSpawnInfoNumber < 0 || _currentSpawnInfoNumber >= _objectsInfo.Count)
        {
            _currentSpawnInfoNumber = 0;
        }
    }

    private void OnEnable()
    {
        if (_spawningCoroutine == null)
        {
            _spawningCoroutine = StartCoroutine(SpawnCharacters());
        }

        else
        {
            StopCoroutine(_spawningCoroutine);
        }

        _currentSpawnInfoNumber = 0;
    }

    private void OnDisable()
    {
        if (_spawningCoroutine != null)
        {
            StopCoroutine(_spawningCoroutine);
            _spawningCoroutine = null;
        }
    }

    private void ResetTimer()
    {
        _spawnTimer = new Timer(_spawnDelay);
    }

    private IEnumerator SpawnCharacters ()
    {
        do
        {
            for (int i = 0; i < _objectsInfo.Count; i++)
            {
                Instantiate(_objectsInfo[i].Character, _objectsInfo[i].SpawnPosition, Quaternion.identity);
                ResetTimer();

                while (_spawnTimer.IsFinished == false)
                {
                    _spawnTimer.ReduceTime(Time.deltaTime);
                    Debug.Log($"{_spawnTimer.TimeRemaining} seconds until next spawn.");
                    yield return new WaitForFixedUpdate();
                }

                yield return new WaitUntil(() => _spawnTimer.IsFinished);
            }
        }
        while (_isLooped);
    }
}
