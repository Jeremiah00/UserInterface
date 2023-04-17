using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] targets;
    private float spawnRate = 1.0f;
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    // Update is called once per frame
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Length);
            Instantiate(targets[index]);
        }
    }
    void Update()
    {
        
    }
}
