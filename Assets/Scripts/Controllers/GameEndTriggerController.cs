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

        private Transform _player;

        private void OnTriggerEnter(Collider other)
        {
            _characterCollision = other.gameObject.GetComponent<CharacterCollisionController>();
            _player = other.transform;
            GameManager.Instance.IsGameEnded = true;
            StartPlayerAnimation();
        }
        private void StartPlayerAnimation()
        {
            _characterCollision.SelectedWeapon.gameObject.SetActive(true);
            _characterCollision.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("gameEnded"));
            CheckIsPlayerFailed();
        }

        private void CheckIsPlayerFailed()
        {
            if (!_characterCollision.SelectedWeapon.gameObject.activeInHierarchy)
            {
                GameManager.Instance.IsPlayerFailed = true;
                StartCoroutine(GameManager.Instance.LoadCurrentLevel());
                return;
            }
            else
            {
                StartCoroutine(KillZombies());
            }
        }

        IEnumerator KillZombies()
        {
            Camera.main.transform.parent = null;
            for (int i = 0; i < _zombies.childCount; i++)
            {
                _player.LookAt(_zombies.GetChild(i));
                yield return new WaitForSeconds(1.2f);
                _zombies.GetChild(i).GetComponent<Animator>().SetTrigger(Animator.StringToHash("killZombie"));
            }
            _characterCollision.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("zombiesDied"));
            StartCoroutine(GameManager.Instance.LoadNextScene());
        }
    }
}
