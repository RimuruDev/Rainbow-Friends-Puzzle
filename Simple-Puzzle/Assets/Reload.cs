using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public class Reload : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(delegate
            {
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}