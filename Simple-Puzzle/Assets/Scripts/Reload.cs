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
                if (gameObject.name == "Menu")
                    SceneManager.LoadSceneAsync("MainScene");
                else
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}