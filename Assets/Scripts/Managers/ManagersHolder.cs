using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Managers
{
    public class ManagersHolder : MonoBehaviour
    {
        public static UIManager UiManager { get; private set; }
        public static PlayerTransformManager PlayerTransformManager { get; private set; }
        private void Awake()
        {
            UiManager = gameObject.GetComponent<UIManager>();
            PlayerTransformManager = gameObject.GetComponent<PlayerTransformManager>();
        }
    }
}
