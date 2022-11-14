using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RimuruDev
{
    public class ScalerController : MonoBehaviour
    {
        [SerializeField] private Vector2 minScale;
        [SerializeField] private Vector2 maxScale;
        [SerializeField] private bool repeateble = true;
        [SerializeField] private float speed = 2f;
        [SerializeField] private float duration = 5;

        [SerializeField] private float timeCooldown = 1.0f;

        private IEnumerator Start()
        {
            while (repeateble)
            {
                yield return RepeatLerp(minScale, maxScale, duration);
                yield return RepeatLerp(maxScale, minScale, duration);
            }
        }

        private IEnumerator RepeatLerp(Vector2 a, Vector2 b, float time)
        {
            var i = 0.0f;
            var rate = (1.0f / time) * speed;

            while (i < timeCooldown)
            {
                i += Time.deltaTime * rate;

                transform.localScale = Vector2.Lerp(a, b, i);

                yield return null;
            }
        }

    }
}
