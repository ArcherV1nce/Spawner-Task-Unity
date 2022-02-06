using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private List<CharacterSpawnInfo> _objectsInfo;
    [SerializeField, Range (0f, 30f)] private float _spawnDelay;
    [SerializeField] private bool _isLooped;

    private int _currentSpawnInfoNumber;
    private Timer _spawnTimer;
    private Coroutine _spawningCoroutine;

    public void AddInfo (CharacterSpawnInfo spawnInfo)
    {
        _objectsInfo.Add (spawnInfo);
    }

    private void Awake()
    {
        _spawnTimer = GetComponent<Timer>();
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

    private IEnumerator SpawnCharacters ()
    {
        do
        {
            for (int i = 0; i < _objectsInfo.Count; i++)
            {
                Instantiate(_objectsInfo[i].Character, _objectsInfo[i].SpawnPosition, Quaternion.identity);
                _spawnTimer.SetTime(_spawnDelay);
                _spawnTimer.StartCountDown();

                yield return new WaitUntil(() => _spawnTimer.IsFinished);
            }
        }
        while (_isLooped);
    }
}
