using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "WeaponData",menuName = "Add/Data/Weapon/Weapon Data")]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        [SerializeField] private float _fireRate;
        public float FireRate => _fireRate;
        public float Speed => _speed;
        public int Damage => _damage;
    }
}
