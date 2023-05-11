using System;
using System.Collections;
using Data;
using Extensions;
using Logic.Enemy;
using Logic.Gameplay;
using Unity.Mathematics;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerShooter:MonoBehaviour
    {
        [SerializeField] private Weapon.Weapon _bullet;
        [SerializeField] private PlayerDataHolder _playerDataHolder;
        
        private EnemysInfoHolder _enemysInfo;

        private void Awake()
        {
            _enemysInfo = FindObjectOfType<EnemysInfoHolder>();
        }

        private void Start()
        {
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(_playerDataHolder.BaseWeaponData.FireRate);
                Vector3 direction;
                EnemyMain enemy = _enemysInfo.FindNearestEnemy(transform.position);
                if (enemy != null)
                {
                    direction = enemy.transform.position-transform.position;
                }
                else
                {
                    direction = Vector3Extension.RandomPointOnCircleEdge(5f, transform.position);
                }
                float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                _bullet.Spawn(transform.position,Quaternion.Euler(0,0,rot))
                    .Shoot(direction,
                        _playerDataHolder.BaseWeaponData.Speed,
                        _playerDataHolder.BaseWeaponData.Damage);
            }
        }
    }
}