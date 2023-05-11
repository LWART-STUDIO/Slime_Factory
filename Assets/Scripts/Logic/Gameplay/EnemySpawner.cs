using System;
using System.Collections;
using Extensions;
using Logic.Enemy;
using UnityEngine;

namespace Logic.Gameplay
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyMain _enemyPrefab;
        [SerializeField] private EnemysInfoHolder _enemysInfo;
        [SerializeField] private float _radius;
        [SerializeField] private float _delay;
        [SerializeField] private PlayerMover _playerMover;

        private void Start()
        {
            StartCoroutine(EnemySpawnProcess(_delay));
        }

        private void SpawnEnemy()
        {
            EnemyMain enemyMain = _enemyPrefab.Spawn(this.transform,Vector3Extension.RandomPointOnCircleEdge(_radius,_playerMover.transform.position),
                Quaternion.identity);
            _enemysInfo.AddEnemy(enemyMain);
            
        }

        private IEnumerator EnemySpawnProcess(float delay)
        {
            WaitForSeconds wait = new WaitForSeconds(delay);

            while (true)
            {
                SpawnEnemy();
                yield return wait;
            }
        }
    }
}
