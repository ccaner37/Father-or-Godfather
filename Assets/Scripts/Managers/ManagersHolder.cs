using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Managers
{
    public class ManagersHolder : MonoBehaviour
    {
        public static UIManager UiManager { get; private set; }
        private void Awake()
        {
            UiManager = gameObject.GetComponent<UIManager>();
        }
    }
}
