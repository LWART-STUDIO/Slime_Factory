using System;
using Data;
using Logic.Player;
using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(PlayerDataHolder))]
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Joystick _joystick;
        private Transform _playerTransform;
        private PlayerDataHolder _playerDataHolder;
        private PlayerBaseData _playerBaseData;
        


        private void Awake()
        {
            _playerTransform = GetComponent<Transform>();
            _playerDataHolder = GetComponent<PlayerDataHolder>();
            _playerBaseData = _playerDataHolder.PlayerBaseData;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector2.left);
            }

            if (Input.GetKey(KeyCode.W))
            {
                Move(Vector2.up);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(Vector2.right);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Move(Vector2.down);
            }

            if (_joystick.Direction.sqrMagnitude > 0.01f)
            {
                Move(_joystick.Direction);
            }

        }

        private void Move(Vector2 direction)
        {
           _playerTransform.Translate(direction.normalized 
                                       * _playerBaseData.Speed
                                       * Time.deltaTime);
        }
    }
}
