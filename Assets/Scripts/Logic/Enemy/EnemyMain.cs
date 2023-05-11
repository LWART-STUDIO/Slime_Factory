using System;
using System.Collections;
using Extensions;
using Logic.Gameplay;
using UnityEngine;

namespace Logic.Enemy
{
    [RequireComponent(typeof(EnemyDataHolder),typeof(DamagePopUpGenerator))]
    public class EnemyMain : MonoBehaviour
    {
        [SerializeField] private EnemyMover _enemyMover;

        private EnemysInfoHolder _enemysInfo;
        private DamagePopUpGenerator _damagePopUpGenerator;
        private EnemyDataHolder _enemyDataHolder;
        private Material _material;
        private int _health;

        private void Awake()
        {
            _enemysInfo = FindObjectOfType<EnemysInfoHolder>();
            _enemyDataHolder = GetComponent<EnemyDataHolder>();
            _damagePopUpGenerator = GetComponent<DamagePopUpGenerator>();
            _health = _enemyDataHolder.EnemyBaseData.HealthPoints;
            _material = gameObject.GetComponent<SpriteRenderer>().material;
        }

        public void GetHit(int damage)
        {
            _health -= Mathf.Clamp(damage, 0, _health);
            _damagePopUpGenerator.CreatePopUp(transform.position,damage.ToString());
            if(_health<=0)
                Die();
            else
                StartCoroutine(TakeHit());
        }

        private IEnumerator TakeHit()
        {
            _material.SetFloat("_Brightness_Fade_1",1F);
            yield return new WaitForSeconds(0.2f);
            _material.SetFloat("_Brightness_Fade_1",0F);
        }

        private void Die()
        {
            _enemyMover.enabled = false;
            _enemysInfo.RemoveEnemy(this);
            gameObject.Recycle();
        }
    }
}
