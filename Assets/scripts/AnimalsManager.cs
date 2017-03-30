using UnityEngine;
using System.Collections;

public class AnimalsManager : MonoBehaviour
{
    public static AnimalsManager instance;

    public float SpawnRate = 3f;

    private Animal[] animals;
    private float counter;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start()
    {
        animals = transform.GetComponentsInChildren<Animal>(true);

        if (animals == null)
        {
            Debug.LogError("Animals Manager could not find any Animals");
        }

        Reset();
    }

    public void Reset()
    {
        counter = 0f;
    }

    void OnEnable()
    {
        Reset();
    }


    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        if (counter > SpawnRate * (GameManager.instance.time/GameManager.instance.GameTime) + 1f)
        {
            Spawn();
            counter = 0f;
        }
    }

    private void Spawn()
    {
        bool spawned;

        do
        {
            var i = Random.Range(0, animals.Length);
            spawned = animals[i].gameObject.activeInHierarchy;

            if (!spawned)
            {
                animals[i].Spawn(SpawnRate * (GameManager.instance.time / GameManager.instance.GameTime) + 2f);
            }
        } while (spawned);
    }
}
