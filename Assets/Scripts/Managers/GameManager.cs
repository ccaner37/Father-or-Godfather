using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace fathergame.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public UIManager _uiManager;

        public bool IsGameEnded, IsPlayerFailed, IsFather;

        public int Points;

        private float _waitDuration = 4f;


        private void Awake()
        {
            Instance = this;
            _uiManager = gameObject.GetComponent<UIManager>();
        }

        public IEnumerator LoadNextScene()
        {
            _uiManager.EnableLevelCompletedText();
            yield return new WaitForSeconds(_waitDuration);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public IEnumerator LoadCurrentLevel()
        {
            _uiManager.EnableLevelFailedText();
            yield return new WaitForSeconds(_waitDuration);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
