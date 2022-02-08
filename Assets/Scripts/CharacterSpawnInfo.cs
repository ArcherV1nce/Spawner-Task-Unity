using System;
using UnityEngine;

[Serializable]
public struct CharacterSpawnInfo
{
    [SerializeField] private Character _character;
    [SerializeField] private Vector3 _spawnPosition;

    public Character Character => _character;
    public Vector3 SpawnPosition => _spawnPosition;

    public CharacterSpawnInfo (Character character, Vector3 spawnPosition)
    {
        _character = character;
        _spawnPosition = spawnPosition;
    }

    private void OnValidate()
    {
        if (SpawnPosition.z != 0)
        {
            _spawnPosition = new Vector3(SpawnPosition.x, SpawnPosition.y, 0);
        }
    }
}
