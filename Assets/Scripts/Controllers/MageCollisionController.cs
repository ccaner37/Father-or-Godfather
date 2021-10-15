using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;

namespace fathergame.Controllers
{
    public class MageCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            CharacterCollisionController characterCollision = other.GetComponent<CharacterCollisionController>();

            int animation = Animator.StringToHash("Kill");
            Transform activeCharacter = characterCollision.ActiveCharacter;
            activeCharacter.GetComponent<Animator>().SetTrigger(animation);
            GameManager.Instance.IsGameEnded = true;

            if (characterCollision.ActiveCharacter == characterCollision.Citizen)
            {
                activeCharacter.GetChild(1).GetComponent<Renderer>().material.color = new Color(35f / 255f, 255f / 255f, 0f / 255f);
                activeCharacter.GetChild(1).GetComponent<Renderer>().material.mainTextureScale = new Vector2(9.5f, -57.7f);
            }

            Destroy(gameObject);
        }
    }
}
