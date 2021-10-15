using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;

namespace fathergame.Controllers
{
    public class CharacterMovementController : MonoBehaviour
    {
        private CharacterController controller;

        private float _forwardSpeed = 6f;
        private float _speed = 10.0f;
        private float _gravity = 20.0f;
        private float _distance;

        private Vector3 _targetPos;
        private Vector3 _moveDirection = Vector3.zero;

        void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
        }

        void Update()
        {
            CalculateMousePosition();
            MovePlayer();
        }

        private void CalculateMousePosition()
        {
            _distance = transform.position.z - Camera.main.transform.position.z;
            _targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
            _targetPos = Camera.main.ScreenToWorldPoint(_targetPos);
        }

        private void MovePlayer()
        {
            if (!GameManager.Instance.IsGameEnded)
            {
                if (controller.isGrounded)
                {
                    _moveDirection = new Vector3(0, 0, 1);
                    _moveDirection *= _forwardSpeed;
                }
                _moveDirection.y -= _gravity * Time.deltaTime;
                controller.Move(_moveDirection * Time.deltaTime);

                if (Input.GetMouseButton(0))
                {
                    Vector3 followXonly = new Vector3(_targetPos.x, transform.position.y, transform.position.z);
                    transform.position = Vector3.Lerp(transform.position, followXonly, _speed * Time.deltaTime);
                }
            }
        }
    }
}