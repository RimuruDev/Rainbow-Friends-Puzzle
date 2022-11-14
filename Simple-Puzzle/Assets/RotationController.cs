using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public class RotationController : MonoBehaviour
    {
        [SerializeField] private float rotaionSpeed_X = 0f;
        [SerializeField] private float rotaionSpeed_Y = 0f;
        [SerializeField] private float rotaionSpeed_Z = 3f;

        public float cooldown = 5;
        public bool isRotate = true;

        //private void Start() => StartCoroutine(InfinityRotateMedKin());
//
        private IEnumerator InfinityRotateMedKin()
        {
            while (transform.rotation.z < 180)
            {
                transform.Rotate(rotaionSpeed_X, rotaionSpeed_Y, rotaionSpeed_Z);

                yield return new WaitForSeconds(cooldown);

                if (transform.rotation.z >= -180f)
                    isRotate = false;
            }

            while (transform.rotation.z > 180)
            {
                transform.Rotate(rotaionSpeed_X, rotaionSpeed_Y, -rotaionSpeed_Z);

                yield return new WaitForSeconds(cooldown);

                if (transform.rotation.z >= 180f)
                    isRotate = false;
            }
        }
    }
}
