using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _playerPos;

    [SerializeField]
    private Animator _animator;

    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_playerPos != null)
        {
            _navMeshAgent.SetDestination(_playerPos.position);

            if (Vector3.Distance(transform.position, _playerPos.position) <= 4.5f)
            {
                _animator.SetBool("Punch", true);
                _navMeshAgent.speed = 0.0f;
            }
            else
            {
                _animator.SetBool("Punch", false);
                _navMeshAgent.speed = 3.5f;
            }
        }
    }

    public void SetPlayerPos(Transform playerPos)
    {
        _playerPos = playerPos;
    }
}
