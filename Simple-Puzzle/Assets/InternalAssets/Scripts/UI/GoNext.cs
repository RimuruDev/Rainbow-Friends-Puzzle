using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RimuruDev
{
    public class GoNext : MonoBehaviour
    {
        public float time = 3;
        private UnityEngine.UI.Text text;
        private TMPro.TMP_Text btext;

        private void Start()
        {
            btext = GetComponent<Button>().GetComponentInChildren<TMPro.TMP_Text>();
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate
            {/*
                if (SceneManager.GetActiveScene().name == "Level_4")
                {
                    Debug.Log("Max level");
                    text = GameObject.FindGameObjectWithTag("WinText").GetComponent<UnityEngine.UI.Text>();
                    text.text = "You Win Game!\nGo Main Menu!";
                    StartCoroutine(Timer());
                    return;
                }

                var index = SceneManager.GetActiveScene().buildIndex;
                //index++;
                */
                // SceneManager.LoadSceneAsync($"Level_{index}");
                SceneManager.LoadSceneAsync($"Level_{0}");
            });
        }
        bool istext;
        private IEnumerator Timer()
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