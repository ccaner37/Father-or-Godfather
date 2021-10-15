using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public bool IsGameEnded;
    }
}
