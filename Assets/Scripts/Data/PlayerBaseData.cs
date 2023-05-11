using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "PlayerData",menuName = "Add/Data/Player/Player Base Data")]
    public class PlayerBaseData : ScriptableObject
    {
        [SerializeField] private float _speed;
        
        public float Speed => _speed;
      
    }
}
