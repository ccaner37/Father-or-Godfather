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
        private TextMeshProUGUI _levelCompletedText, _levelFailedText;

        public TextMeshProUGUI PlayerHeadText;

        public Image FillBar;

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
            ManagersHolder.PlayerTransformManager.ManagePlayerTransform();
            float fillAmount = Mathf.InverseLerp(0f, 10f, Mathf.Abs(GameManager.Instance.Points));
            FillBar.fillAmount = fillAmount;
        }
    }
}
