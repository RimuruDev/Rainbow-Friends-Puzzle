using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public class GoNext : MonoBehaviour
    {
        public float time = 3;
        private Text text;
        private Text btext;

        private GameController gameController;

        private void Awake()
        {
            gameController = FindObjectOfType<GameController>();
        }

        private void Start()
        {
            btext = GetComponent<Button>().GetComponentInChildren<Text>();
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
            {
                /*
                if (gameController.Index >= gameController.comaryDataset.GetComaryData.Length)
                {
                    gameController.Index = 0;
                    Debug.Log("!!!!!!!!!!!!!!!Load main menu");

                    Debug.Log("Max level");
                    text = GameObject.FindGameObjectWithTag("WinText").GetComponent<UnityEngine.UI.Text>();
                    text.text = "You Win Game!\nGo Main Menu!";
                    StartCoroutine(Timer());
                    return;
                }

                if (gameController.Index >= gameController.joJoDataset.GetJoJoData.Length)
                {
                    gameController.Index = 0;
                    Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Load main menu");

                    Debug.Log("Max level");
                    text = GameObject.FindGameObjectWithTag("WinText").GetComponent<UnityEngine.UI.Text>();
                    text.text = "You Win Game!\nGo Main Menu!";
                    StartCoroutine(Timer());
                    return;
                }*/

                /*
                if (SceneManager.GetActiveScene().buildIndex > SceneManager.sceneCount)
                {
                    Debug.Log("Max level");
                    text = GameObject.FindGameObjectWithTag("WinText").GetComponent<UnityEngine.UI.Text>();
                    text.text = "You Win Game!\nGo Main Menu!";
                    StartCoroutine(Timer());
                    return;
                }*/

                //var index = SceneManager.GetActiveScene().buildIndex;
                //index++;)
                if (SceneManager.GetActiveScene().name == "Level_0")
                    SceneManager.LoadSceneAsync("Level_0");//SceneManager.GetActiveScene().buildIndex
                else

                    SceneManager.LoadSceneAsync("Level_1");//SceneManager.GetActiveScene().buildIndex);
                // SceneManager.LoadSceneAsync($"Level_{index}");
            });
        }
        bool istext;
        public IEnumerator Timer()
        {
            istext = true;
            yield return new WaitForSeconds(time);
            istext = false;
            //  yield return new WaitForSeconds(1);
            SceneManager.LoadSceneAsync($"MainScene");
        }

        private void Update()
        {
            if (istext)
                btext.text = $"{Mathf.Floor(time -= Time.deltaTime)}";

        }
    }
}