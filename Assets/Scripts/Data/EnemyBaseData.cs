using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "EnemyData",menuName = "Add/Data/Enemy/Enemy Base Data")]
    public class EnemyBaseData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _healthPoints;
        public float Speed => _speed;
        public int HealthPoints =>_healthPoints;
    }
}
