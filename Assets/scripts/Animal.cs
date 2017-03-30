using UnityEngine;
using System.Collections;

public class Animal : MonoBehaviour {

    public AnimalType AnimalKind;

    public GameObject ScorePrefab;
    public AudioClip SpawnClip;
    public AudioClip KillClip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        Debug.Log("Animal is clicked: " + AnimalKind.ToString());
        if (ScorePrefab && !ScorePrefab.activeInHierarchy)
        {
            ScorePrefab.SetActive(true);
        }

        GameManager.instance.AddScore(AnimalKind);
        StopAllCoroutines();
        AudioSource.PlayClipAtPoint(KillClip, transform.position);
        gameObject.SetActive(false);
    }

    void OnEnable()
    {
        
    }

    public void Spawn(float time)
    {
        gameObject.SetActive(true);
        AudioSource.PlayClipAtPoint(SpawnClip, transform.position);
        StartCoroutine(Spawned(time));
    }

    IEnumerator Spawned(float time)
    {
        yield return new WaitForSeconds(time);

        gameObject.SetActive(false);
    }
}

public enum AnimalType
{
    Buffalo = 100,
    Lion = 200,
    Elephant = 250,
    Leopard = 500,
    Rhino = 1000
}
