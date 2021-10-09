using UnityEngine;

public class KotakGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] kotakPrefab;
    [SerializeField] private float spawnRate = 3f;

    private float spawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        //nilai counter berkurang terus
        //kalo counter sudah 0, spawnbox & set nilai spawnCounter dengan spawnRate
        spawnCounter -= Time.deltaTime;
        if(spawnCounter < 0.1f)
        {
            SpawnBox();
            spawnCounter = spawnRate;
        }
    }

    private void SpawnBox()
    {
        //pilih random prefab
        int index = Random.Range(0, kotakPrefab.Length);

        //kotak akan muncul dalam area border
        Vector3 randomPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.25f, 4.25f));

        //munculkan kotak
        Instantiate(kotakPrefab[index], randomPosition, Quaternion.identity);
    }
}
