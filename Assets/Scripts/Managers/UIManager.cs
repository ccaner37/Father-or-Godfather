using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace fathergame.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _levelCompletedText, _levelFailedText, _playerText;

        [SerializeField]
        private Image _fillBar;

        private int plylevel;

        Dictionary<int, string> numberNames = new Dictionary<int, string>();

        private void Start()
        {
            numberNames.Add(1, "Father");
            numberNames.Add(-1, "Godfather");
        }

        public void EnableLevelCompletedText()
        {
            _levelCompletedText.gameObject.SetActive(true);
        }

        public void EnableLevelFailedText()
        {
            _levelFailedText.gameObject.SetActive(true);
        }

        public void UpdateFillBar()
        {
            ManageFillBar();
            float fillAmount = Mathf.InverseLerp(0f, 10f, Mathf.Abs(GameManager.Instance.Points));
            _fillBar.fillAmount = fillAmount;
        }

        private void ManageFillBar()
        {
            if (GameManager.Instance.Points >= 10) // && GameManager.Instance.IsFather
            {
                plylevel++;
                _playerText.text = numberNames[plylevel];
                _fillBar.color = Color.blue;
                GameManager.Instance.Points -= 10;
            }
            else if (GameManager.Instance.Points <= -10) // && !GameManager.Instance.IsFather
            {
                plylevel--;
                _playerText.text = numberNames[plylevel];
                _fillBar.color = Color.red;
                GameManager.Instance.Points += 10;
            }
        }
    }
}
