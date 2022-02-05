using System;
using UnityEngine;

[Serializable]
public struct CharacterSpawnInfo
{
    [SerializeField] public Character Character;
    [SerializeField] public Vector3 SpawnPosition;

    public CharacterSpawnInfo (Character character, Vector3 spawnPosition)
    {
        Character = character;
        SpawnPosition = spawnPosition;
    }

    private void OnValidate()
    {
        if (SpawnPosition.z != 0)
        {
            SpawnPosition = new Vector3(SpawnPosition.x, SpawnPosition.y, 0);
        }
    }
}
