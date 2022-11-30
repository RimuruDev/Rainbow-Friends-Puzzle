using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

namespace RimuruDev
{
    public sealed class Play : MonoBehaviour
    {
        public Action<string> OnLevelChanged;

        private string level = "Level_0";

        private void Awake()
        {
            GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadSceneAsync(level); });
        }

        private void OnEnable()
        {
            OnLevelChanged += SetModLevel;
        }

        private void OnDisable()
        {
            OnLevelChanged -= SetModLevel;
        }

        private void SetModLevel(string level) => this.level = level;
    }
}