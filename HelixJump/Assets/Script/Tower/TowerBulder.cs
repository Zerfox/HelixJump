using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulder : MonoBehaviour
{
    [SerializeField] private int _lievelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private Platform [] _massPlatforms;
    [SerializeField] private FinishPlatform _finishPlatform;

    private float _startAndFinishAdditionalScale = 1f;

    public float BeamScaly => _lievelCount + _startAndFinishAdditionalScale;
    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, BeamScaly, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y;

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _lievelCount-1; i++)
        {
            SpawnPlatform(_massPlatforms[Random.Range(0, _massPlatforms.Length)], ref spawnPosition, beam.transform);
        }
        
        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform (Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }
}
