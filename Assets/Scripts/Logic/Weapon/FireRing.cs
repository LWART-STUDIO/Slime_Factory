using System;
using UnityEngine;

namespace Logic.Weapon
{
    public class FireRing : Weapon
    {
        [SerializeField] private float _r;
        private void Start()
        {
            Shoot(Vector3.zero, 0.6f,1,_r);
        }

        public override void Shoot(Vector3 direction,float speed, int damage, float radius )
        {
            base.Shoot(direction, speed, damage,radius);
            StartCoroutine(DurationDamage(speed));
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position,_r);
        }
    }
}
