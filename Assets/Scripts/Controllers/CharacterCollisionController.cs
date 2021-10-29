using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;

namespace fathergame.Controllers
{
    public class CharacterCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            GivePoints(other.transform);
        }
        
        private void GivePoints(Transform other)
        {
            if (other.CompareTag("GoodGate"))
            {
                GameManager.Instance.Points += 6;
                ManagersHolder.UiManager.UpdateFillBar();
            }
            else if (other.CompareTag("BadGate"))
            {
                GameManager.Instance.Points -= 6;
                ManagersHolder.UiManager.UpdateFillBar();
            }

            if (other.CompareTag("FatherGate"))
            {
                GameManager.Instance.IsFather = true;
            }
        }
    }
}
