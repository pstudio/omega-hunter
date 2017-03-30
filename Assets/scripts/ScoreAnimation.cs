using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreAnimation : MonoBehaviour
{

    public Vector3 DefaultPosition;
    public float AnimSpeed = 1f;
    public float AnimTime = 3f;

    private Image img;

    // Use this for initialization
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, AnimSpeed * Time.deltaTime, 0f);
    }

    void OnEnable()
    {
        StartCoroutine(Animate());

        if (!img)
        {
            img = GetComponent<Image>();
        }
        img.CrossFadeAlpha(0f, AnimTime, false);
    }

    IEnumerator Animate()
    {
        yield return new WaitForSeconds(AnimTime);

        transform.localPosition = DefaultPosition;
        img.color = Color.white;
        gameObject.SetActive(false);
    }
}
