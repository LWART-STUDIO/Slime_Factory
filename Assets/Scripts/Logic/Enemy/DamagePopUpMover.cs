using System;
using TMPro;
using UnityEngine;

namespace Logic.Enemy
{

    public class DamagePopUpMover : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _opacityCurve;
        [SerializeField] private AnimationCurve _scaleCurve;
        [SerializeField] private AnimationCurve _moveCurve;
        private TextMeshProUGUI _tmp;
        private float _time = 0f;
        private Vector3 origin;

        private void Awake()
        {
            _tmp = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            origin = transform.position;
        }

        private void Update()
        {
            _tmp.color = new Color(1, 1, 1, _opacityCurve.Evaluate(_time));
            transform.localScale = Vector3.one*_scaleCurve.Evaluate(_time);
            transform.position = origin + new Vector3(0, 1 + _moveCurve.Evaluate(_time), 0);
            _time += Time.deltaTime;
        }

        private void OnDisable()
        {
            _time = 0f;
        }
    }
}
