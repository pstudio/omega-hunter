using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public Text ScoreText;
    public Text TimeText;

    public float GameTime;

    public AudioClip GunClip;
    public AudioClip ComboClip;
    public AudioClip ExcellentClip;
    public AudioClip GreatClip;

    public ScoreMenu ScoreResults;
    public GameObject Game;

    private int score;
    public float time;

    private float multiplier;

    private AnimalType? lastAnimalType;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        score = 0;
        time = GameTime;
        lastAnimalType = null;
        multiplier = 1f;
    }

    void OnEnable()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TimeText.text = ((int) time).ToString();

        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(GunClip, transform.position);
            AddScore(-1);
        }

        if (time < 0f)
        {
            ScoreResults.gameObject.SetActive(true);
            ScoreResults.ShowScore(score);
            ScoreText.text = "0";
            Game.SetActive(false);
        }
    }

    public void AddScore(AnimalType kind)
    {
        if (kind == lastAnimalType)
        {
            multiplier *= 2f;
            AudioSource.PlayClipAtPoint(ComboClip, transform.position);
        }
        else
        {
            multiplier = 1f;
        }

        lastAnimalType = kind;
        var oldScore = score;
        score += (int)((int)kind * multiplier);

        if (score - oldScore >= 1000)
        {
            AudioSource.PlayClipAtPoint(GreatClip, transform.position);
        }
        else if (score - oldScore >= 500)
        {
            AudioSource.PlayClipAtPoint(ExcellentClip, transform.position);
        }

        ScoreText.text = score.ToString();
    }

    public void AddScore(int points)
    {
        score += points;
        ScoreText.text = score.ToString();
    }
}
