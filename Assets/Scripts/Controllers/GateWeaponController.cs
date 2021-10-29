using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fathergame.Managers;

namespace fathergame.Controllers
{
    public class GateWeaponController : MonoBehaviour
    {
        [SerializeField]
        private Transform _weaponWillBeGiven;

        private void OnTriggerEnter(Collider other)
        {
            SelectWeapon();
        }

        private void SelectWeapon()
        {
            ManagersHolder.PlayerTransformManager.SelectedWeapon = _weaponWillBeGiven;
        }
    }
}
