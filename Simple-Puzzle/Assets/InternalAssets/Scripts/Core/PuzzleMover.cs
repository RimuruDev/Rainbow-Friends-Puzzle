using System.Collections.Generic;
using UnityEngine;

public class PuzzleMover : MonoBehaviour
{
    public System.Action OnWin;
    public Transform popup;
    [SerializeField] private bool isImmediately = true;
    [SerializeField] private float duration = 0.3f;
    [SerializeField] private AnimationCurve animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private AnimationCurve scaleCurve = null;

    private bool isMoving = false;
    private float percentage01 = 0;
    private List<PuzzleElement> movingPuzzles = new List<PuzzleElement>();

    private PuzzleGenerator puzzleGenerator = null;
    private PuzzleClicker puzzleClicker = null;

    private void Reset()
    {
        // duration = 1;
        isImmediately = true;
        animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    }

    private void Awake()
    {
        duration = 0.3f;
        popup = GameObject.FindGameObjectWithTag("Finish").transform;
        popup.gameObject.SetActive(false);
    }

    private void Start()
    {
        puzzleGenerator = FindObjectOfType<PuzzleGenerator>();
        puzzleClicker = FindObjectOfType<PuzzleClicker>();

        //popup = GameObject.FindGameObjectWithTag("Finish").transform;
    }

    private void Update()
    {
        OnUpdateMovePuzzles();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            puzzleGenerator.Finish();
        }
    }

    private void OnEnable() => OnWin += Win;

    private void OnDisable() => OnWin -= Win;

    private void OnUpdateMovePuzzles()
    {
        if (isMoving)
        {
            puzzleClicker.gameObject.SetActive(false);
            {
                percentage01 += 1f / duration * Time.deltaTime;

                float smoothPercent01 = animationCurve.Evaluate(percentage01);
                float scaleValue = scaleCurve.Evaluate(percentage01);

                for (int i = 0; i < movingPuzzles.Count; i++)
                {
                    var p = movingPuzzles[i];
                    p.LerpTowards(smoothPercent01);

                    p.transform.localScale = Vector2.one * scaleValue;
                }

                if (percentage01 >= 1)
                {
                    for (int i = 0; i < movingPuzzles.Count; i++)
                    {
                        var p = movingPuzzles[i];
                        p.SetTarget();
                    }

                    if (puzzleGenerator.ValidatePuzzles())
                    {
                        Debug.Log("Success! (smooth)");
                        Debug.Log("YouWin");
                        OnWin?.Invoke();
                    }

                    isMoving = false;
                }
            }
            puzzleClicker.gameObject.SetActive(true);
        }
    }

    public void MovePuzzles(PuzzleElement p1, PuzzleElement p2)
    {
        Vector2Int a = p1.GetPosition();
        Vector2Int b = p2.GetPosition();

        if (isImmediately)
        {
            p1.SetPosition(b);
            p2.SetPosition(a);

            if (puzzleGenerator.ValidatePuzzles())
            {
                Debug.Log("Success! (isImmediately)");
            }
        }
        else
        {
            p1.SetSmoothTarget(b);
            p2.SetSmoothTarget(a);

            movingPuzzles.Clear();
            movingPuzzles.Add(p1);
            movingPuzzles.Add(p2);

            isMoving = true;
            percentage01 = 0;
        }
    }

    private void Win()
    {
        int index = PlayerPrefs.GetInt("Index");
        index++;
        PlayerPrefs.SetInt("Index", index);

        Destroy(FindObjectOfType<PuzzleGenerator>().gameObject);
        popup.gameObject.SetActive(true);
    }
}