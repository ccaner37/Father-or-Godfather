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

        private PlayerTransformManager _transformManager;

        private void Start()
        {
            _transformManager = ManagersHolder.PlayerTransformManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            _player = other.transform;
            GameManager.Instance.IsGameEnded = true;
            StartPlayerAnimation();
        }
        private void StartPlayerAnimation()
        {
            if (CheckIsPlayerFailed())
            {
                _transformManager.SelectedWeapon.gameObject.SetActive(true);
                _transformManager.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("gameEnded"));
                StartCoroutine(KillZombies());
            }
        }

        private bool CheckIsPlayerFailed()
        {
            if (!GameManager.Instance.IsFather && GameManager.Instance.Points > 0 || 
                 GameManager.Instance.IsFather && GameManager.Instance.Points < 0 ||
                 GameManager.Instance.Points == 0)
            {
                GameManager.Instance.IsPlayerFailed = true;
                StartCoroutine(GameManager.Instance.LoadCurrentLevel());
                _transformManager.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("Kill"));
                return false;
            }
            else
            {
                return true;
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
            _transformManager.ActiveCharacter.GetComponent<Animator>().SetTrigger(Animator.StringToHash("zombiesDied"));
            StartCoroutine(GameManager.Instance.LoadNextScene());
        }
    }
}
