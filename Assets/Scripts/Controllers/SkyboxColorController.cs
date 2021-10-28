using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame
{
    public class SkyboxColorController : MonoBehaviour
    {
        [SerializeField]
        private Color _startColor, _fatherColor, _godfatherColor, _targetColor;

        private float _duration = 3.0f;

        private bool _shouldChangeColor;

        private void Start()
        {
            RenderSettings.skybox.SetColor("_SkyTint", _startColor);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (transform.CompareTag("FatherGate"))
            {
                _targetColor = _fatherColor;
            }
            else if (transform.CompareTag("GodfatherGate"))
            {
                _targetColor = _godfatherColor;
            }
            _shouldChangeColor = true;
            StartCoroutine(StopColor());
        }

        void Update()
        {
            if (_shouldChangeColor)
            {
                float lerp = Mathf.PingPong(Time.time, _duration) / _duration;
                Color a = Color.Lerp(_targetColor, _startColor, lerp);
                RenderSettings.skybox.SetColor("_SkyTint", a);
            }
        }

        private IEnumerator StopColor()
        {
            yield return new WaitForSeconds(_duration);
            this.enabled = false;
        }
    }
}
