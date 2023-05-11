using Logic.Enemy;
using UnityEngine;

namespace Logic.Weapon
{
    public class Bullet : Weapon
    {
       


        public override void Shoot(Vector3 direction,float speed, int damage,float radius = 0f)
        {
            base.Shoot(direction, speed, damage);
            _rigidbody.velocity = new Vector2(_direction.x, _direction.y) * _speed;
            _waitToDestroy = StartCoroutine(WaitToDestroy());
        }

        private void Update()
        {
            if(!_wasFired)
                return;
            
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.TryGetComponent(out EnemyMain enemy))
            {
                enemy.GetHit(_damage);
                DestroyBullet();
            }
        }
        
    }
}
