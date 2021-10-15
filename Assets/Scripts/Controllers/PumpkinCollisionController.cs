using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fathergame
{
    public class PumpkinCollisionController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}
