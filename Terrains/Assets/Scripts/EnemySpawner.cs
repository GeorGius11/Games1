using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    [SerializeField]
    private Transform[] _spawnPositions;

    [SerializeField]
    private int _posCounter;

    [SerializeField]
    private float _spawnCoolDown = 3.0f;

    [SerializeField]
    private float _spawnTimer;

    private void Awake()
    {
        _spawnTimer = _spawnCoolDown;
    }

    private void Update()
    {
        if(_spawnTimer != 0)
        {
            _spawnTimer -= Time.deltaTime;
        }
        
        if(_spawnTimer < 0)
        {
            _spawnTimer = 0;
        }

        if(_spawnTimer == 0 && _posCounter != _spawnPositions.Length)
        {
            _spawnTimer = _spawnCoolDown;
            Spawn();
        }
    }

    private void Spawn()
    {
        var enemy = Instantiate(_enemyPrefab, _spawnPositions[_posCounter].position, Quaternion.identity);
        var enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.SetPlayerPos(transform);
        _posCounter++;
    }
}

