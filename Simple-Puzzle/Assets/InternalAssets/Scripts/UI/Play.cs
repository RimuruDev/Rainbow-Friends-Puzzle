using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public class Play : MonoBehaviour
    {
        private void Awake() => GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadSceneAsync("Level_0"); });
    }
}