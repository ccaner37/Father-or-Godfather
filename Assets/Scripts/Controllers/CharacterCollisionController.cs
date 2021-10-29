using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;

namespace fathergame.Controllers
{
    public class CharacterCollisionController : MonoBehaviour
    {
        private CharacterController _characterController;

        public Transform Citizen, Mafia, Alexander, ActiveCharacter, SelectedWeapon;

        void Start()
        {
            ActiveCharacter = Citizen;
            _characterController = gameObject.GetComponent<CharacterController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            GivePoints(other.transform);
        }
        
        private void GivePoints(Transform other)
        {
            if (other.CompareTag("GoodGate"))
            {
                GameManager.Instance.Points += 15;
                ShouldTransform();
                ManagersHolder.UiManager.UpdateFillBar();
            }
            else if (other.CompareTag("BadGate"))
            {
                GameManager.Instance.Points -= 15;
                ShouldTransform();
                ManagersHolder.UiManager.UpdateFillBar();
            }

            if (other.CompareTag("FatherGate"))
            {
                GameManager.Instance.IsFather = true;
            }
        }

        private void ShouldTransform()
        {
            if (GameManager.Instance.Points >= 10 && GameManager.Instance.IsFather)
            {
                Citizen.gameObject.SetActive(false);
                Alexander.gameObject.SetActive(true);
                ActiveCharacter = Alexander;
            }
            else if (GameManager.Instance.Points <= -10 && !GameManager.Instance.IsFather)
            {
                Citizen.gameObject.SetActive(false);
                Mafia.gameObject.SetActive(true);
                ActiveCharacter = Mafia;
            }
        }
    }
}
