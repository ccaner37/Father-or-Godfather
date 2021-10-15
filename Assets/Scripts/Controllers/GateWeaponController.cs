using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame.Controllers
{
    public class GateWeaponController : MonoBehaviour
    {
        [SerializeField]
        private Transform _weaponWillBeGiven;

        private void OnTriggerEnter(Collider other)
        {
            SelectWeapon(other.transform);
        }

        private void SelectWeapon(Transform player)
        {
            player.GetComponent<CharacterCollisionController>().SelectedWeapon = _weaponWillBeGiven;
        }
    }
}
