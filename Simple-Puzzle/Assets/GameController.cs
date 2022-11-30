using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RimuruDev
{
    public struct Tag
    {
        public static string LEVEL_ID;
    }

    [DisallowMultipleComponent]
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField, Space] public MonsterDataset comaryDataset;
        [SerializeField, Space] public SpriteRenderer background;

        [SerializeField, HideInInspector] private PuzzleClicker puzzleClicker = null;
        [SerializeField, HideInInspector] private PuzzleElement puzzleElement = null;
        [SerializeField, HideInInspector] private PuzzleGenerator puzzleGenerator = null;
        [SerializeField, HideInInspector] private PuzzleMover puzzleMover = null;


        private int index = 0;
        public int Index { get => index; set => index = value; }

        private void Awake() => CheckRefs();

        private void Start()
        {
            // if (PlayerPrefs.GetInt("Index") <= 0)
            //PlayerPrefs.SetInt("Index", 0);
            // else
            index = PlayerPrefs.GetInt("Index");

            Debug.Log($"Current level: {index}");

            if (index >= comaryDataset.GetMonsterData.Length)
            {
                index = 0;
                Debug.Log("You with maximum levels!");
            }

            background.sprite = comaryDataset.GetMonsterData[index].MonsterSprite;
            puzzleGenerator.GetpuzzleElementPrefab = comaryDataset.GetMonsterData[index].MonsterPrefab.GetComponent<PuzzleElement>();

            Debug.Log($"Sprite: [{comaryDataset.GetMonsterData[index].MonsterSprite.name}]");
            Debug.Log($"Prefab: [{comaryDataset.GetMonsterData[index].MonsterPrefab.name}]");
        }

        public float time = 3;
        private Text text;
        private Text btext;
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


        [System.Diagnostics.Conditional("DEBUG")]
        private void OnValidate() => CheckRefs();

        private void CheckRefs()
        {
            if (puzzleClicker == null)
                puzzleClicker = FindObjectOfType<PuzzleClicker>();

            if (puzzleElement == null)
                puzzleElement = FindObjectOfType<PuzzleElement>();

            if (puzzleElement == null)
                puzzleGenerator = FindObjectOfType<PuzzleGenerator>();

            if (puzzleElement == null)
                puzzleMover = FindObjectOfType<PuzzleMover>();
        }
    }
}