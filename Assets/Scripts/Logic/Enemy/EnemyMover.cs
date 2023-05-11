using System;
using Data;
using Logic.Player;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyMover : MonoBehaviour
    {
        private Transform _enemyTransform;
        private EnemyDataHolder _enemyDataHolder;
        private EnemyBaseData _enemyBaseData;
        private Transform _playerTransform;


        private void Awake()
        {
            _enemyTransform = GetComponent<Transform>();
            _enemyDataHolder = GetComponent<EnemyDataHolder>();
            _enemyBaseData = _enemyDataHolder.EnemyBaseData;
            _playerTransform = FindObjectOfType<PlayerMover>().transform;
        }

        private void Update()
        {
            FollowPlayer();
        }

        private void FollowPlayer()
        {
            transform.Translate((_playerTransform.position-transform.position).normalized
                                *_enemyBaseData.Speed
                                *Time.deltaTime);
        }
    }
}
