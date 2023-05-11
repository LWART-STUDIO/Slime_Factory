using Data;
using UnityEngine;

namespace Logic.Enemy
{
    public class EnemyDataHolder:MonoBehaviour
    {
        [SerializeField] private EnemyBaseData _enemyBaseData;
        public EnemyBaseData EnemyBaseData => _enemyBaseData;
    }
}