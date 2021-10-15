using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Controllers
{
    public class CharacterCollisionController : MonoBehaviour
    {
        private CharacterController _characterController;

        public bool IsFather;

        private int points;

        public Transform Citizen, Mafia, Alexander, ActiveCharacter, SelectedWeapon;

        void Start()
        {
            ActiveCharacter = Citizen;
            _characterController = gameObject.GetComponent<CharacterController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("FatherGate"))
            {
                IsFather = true;
                Camera.main.backgroundColor = new Color(142f / 255f, 198f / 255f, 233f / 255f);
            }
            else if (other.CompareTag("GodfatherGate"))
            {
                Camera.main.backgroundColor = new Color(84f / 255f, 35f / 255f, 35f / 255f);
            }

            GivePoints(other.transform);
            ShouldTransform();
        }
        
        private void GivePoints(Transform other)
        {
            if (other.CompareTag("GoodGate"))
            {
                points += 10;
            }
            else if (other.CompareTag("BadGate"))
            {
                points -= 10;
            }
        }

        private void ShouldTransform()
        {
            if (points >= 10 && IsFather)
            {
                Citizen.gameObject.SetActive(false);
                Alexander.gameObject.SetActive(true);
                ActiveCharacter = Alexander;
            }
            else if (points <= -10 && !IsFather)
            {
                Citizen.gameObject.SetActive(false);
                Mafia.gameObject.SetActive(true);
                ActiveCharacter = Mafia;
            }
        }
    }
}
