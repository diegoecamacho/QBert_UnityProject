using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public static EnemySpawner instance = null;

     bool ContinueGame = true;

    [SerializeField] GameObject coilyEggPrefab;
    [SerializeField] GameObject greenBallPrefab;
    [SerializeField] GameObject redBallPrefab;

    [SerializeField] CubeObjectScript SpawnCube;

    [SerializeField] float OffsetY;

    Transform currentSpawnCube;

    // Use this for initialization
    void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
	}

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy(){
        while (ContinueGame)
        {
            currentSpawnCube = SpawnCube.transform;
            GameObject Enemy = Instantiate(coilyEggPrefab, new Vector3(currentSpawnCube.position.x, currentSpawnCube.position.y + OffsetY, currentSpawnCube.position.z), currentSpawnCube.rotation);
            Enemy.GetComponent<AgentBase>().StartScript(SpawnCube);
            yield return new WaitForSeconds(10.0f);
        }

    }
	private void OnTriggerEnter2D(Collider2D collision)
	{
		    
	}

	private void OnTriggerEnter(Collider other)
	{
		    
	}
}
