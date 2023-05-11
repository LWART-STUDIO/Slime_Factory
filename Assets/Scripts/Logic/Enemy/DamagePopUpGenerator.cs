using System.Collections;
using Extensions;
using TMPro;
using UnityEngine;

namespace Logic.Enemy
{
    public class DamagePopUpGenerator : MonoBehaviour
    {
        [SerializeField] private GameObject _textPrefab;
        
        public void CreatePopUp(Vector3 position, string text)
        {

            var popUp = _textPrefab.Spawn(position, Quaternion.identity);
            var temp = popUp.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            temp.text = text;

            StartCoroutine(DestroyTimer(popUp));
        }

        private IEnumerator DestroyTimer(GameObject popUp)
        {
            yield return new WaitForSeconds(1f);
            popUp.Recycle();
        }
    }
}
