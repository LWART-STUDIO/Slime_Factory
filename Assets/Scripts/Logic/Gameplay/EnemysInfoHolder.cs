using Extensions;
using Logic.Enemy;
using UnityEngine;

namespace Logic.Gameplay
{
    public class EnemysInfoHolder : MonoBehaviour
    {
        private KdTree<EnemyMain> _enemies= new KdTree<EnemyMain>();

        public EnemyMain FindNearestEnemy(Vector3 position)
        {
            return _enemies.FindClosest(position);
        }

        public void AddEnemy(EnemyMain enemy)
        {
            _enemies.Add(enemy);
        }

        public void RemoveEnemy(EnemyMain enemy)
        {
            _enemies.RemoveAt(_enemies.ToList().IndexOf(enemy));
        }
    }
}
