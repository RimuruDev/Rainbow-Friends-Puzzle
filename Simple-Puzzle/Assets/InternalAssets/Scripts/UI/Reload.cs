using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public sealed class Reload : MonoBehaviour
    {
        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(delegate
            {
                if (gameObject.CompareTag("Finish"))
                    SceneManager.LoadSceneAsync("MainScene");
                else
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            });
        }
    }
}