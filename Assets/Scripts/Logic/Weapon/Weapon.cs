using System.Collections;
using Extensions;
using Logic.Enemy;
using UnityEngine;

namespace Logic.Weapon
{
    public class Weapon : MonoBehaviour
    {
        protected Rigidbody2D _rigidbody;
        protected Coroutine _waitToDestroy;
        protected bool _wasFired = false;
        protected Vector3 _direction;
        protected float _speed;
        protected float _radius;
        
        protected int _damage;
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public virtual void Shoot(Vector3 direction = new Vector3(),float speed = 0f, int damage = 0, float radius = 0f)
        {
            _direction = direction.normalized;
            _speed = speed;
            _damage = damage;
            _radius = radius;
            _wasFired = true;
        }
        public virtual void DestroyBullet()
        {
            if(_waitToDestroy!=null)
                StopCoroutine(_waitToDestroy);
            gameObject.Recycle();
        }

        protected IEnumerator DurationDamage(float time)
        {
            while (true)
            {
                Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radius);
                foreach (Collider2D collider in hitColliders)
                {
                    if (collider.TryGetComponent(out EnemyMain enemy))
                    {
                        enemy.GetHit(_damage);
                    }
                }
                yield return new WaitForSeconds(time);
            }
        }
        

        protected  IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(5f);
            DestroyBullet();
        }
        
    }
}
