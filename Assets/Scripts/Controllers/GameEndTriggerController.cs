using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;
using System;

namespace fathergame.Controllers
{
    public class GameEndTriggerController : MonoBehaviour
    {
        private CharacterCollisionController _characterCollision;

        [SerializeField]
        private Transform _zombies;

        private void OnTriggerEnter(Collider other)
        {
            _characterCollision = other.gameObject.GetComponent<CharacterCollisionController>();
            GameManager.Instance.IsGameEnded = true;

            StartPlayerAnimation();
            StartCoroutine(KillZombie(other.transform));
        }

        private void StartPlayerAnimation()
        {
            _characterCollision.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("gameEnded"));

            if (_characterCollision.SelectedWeapon != null)
            {
                _characterCollision.SelectedWeapon.gameObject.SetActive(true);
            }

            //if (_characterCollision.IsFather)
            //{
            //    _bible.gameObject.SetActive(true);
            //}
            //else
            //{
            //    _tommygun.gameObject.SetActive(true);
            //}
        }

        IEnumerator KillZombie(Transform player)
        {
            Camera.main.transform.parent = null;
            for (int i = 0; i < _zombies.childCount; i++)
            {
                player.LookAt(_zombies.GetChild(i));
                yield return new WaitForSeconds(1.2f);
                _zombies.GetChild(i).GetComponent<Animator>().SetTrigger(Animator.StringToHash("killZombie"));
            }
            _characterCollision.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("zombiesDied"));
        }
    }
}
