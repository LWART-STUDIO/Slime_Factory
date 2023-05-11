using Data;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerDataHolder : MonoBehaviour
    {
        [SerializeField] private PlayerBaseData _playerBaseData;
        [SerializeField] private WeaponData _baseWeaponData;
        public PlayerBaseData PlayerBaseData => _playerBaseData;
        public WeaponData BaseWeaponData => _baseWeaponData;
    }
}
