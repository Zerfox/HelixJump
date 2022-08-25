using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPosition;

    private void Awake()
    {
        Instantiate(_ball, _spawnPosition.position, Quaternion.identity);
    }
}
 