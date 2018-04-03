using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {

    public static EnemySpawner instance = null;

     public static bool ContinueGame = true;

    [SerializeField] float delay;

    [SerializeField] GameObject coilyEggPrefab;
    [SerializeField] GameObject greenBallPrefab;
    [SerializeField] GameObject redBallPrefab;

    [SerializeField] CubeObjectScript SpawnCube;

    GameObject spawnedEnemy;

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
        currentSpawnCube = SpawnCube.transform;
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy(){
        while (ContinueGame)
        {
            ContinueGame = false; // Runs Only Once
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    if (CoilyScript.coily == null)
                    {
                        spawnedEnemy = Instantiate(coilyEggPrefab, new Vector3(currentSpawnCube.position.x, currentSpawnCube.position.y + OffsetY, currentSpawnCube.position.z), currentSpawnCube.rotation);
                        spawnedEnemy.GetComponent<AgentBase>().StartScript(SpawnCube);
                    }
                    break;
                case 1:
                    spawnedEnemy = Instantiate(greenBallPrefab, new Vector3(currentSpawnCube.position.x, currentSpawnCube.position.y + OffsetY, currentSpawnCube.position.z), currentSpawnCube.rotation);
                    spawnedEnemy.GetComponent<AgentBase>().StartScript(SpawnCube);
                    break;
                case 2:
                    spawnedEnemy = Instantiate(redBallPrefab, new Vector3(currentSpawnCube.position.x, currentSpawnCube.position.y + OffsetY, currentSpawnCube.position.z), currentSpawnCube.rotation);
                    spawnedEnemy.GetComponent<AgentBase>().StartScript(SpawnCube);
                    break;
                default:
                    break;
            }
            
           
         
            yield return new WaitForSeconds(delay);
        }

    }
}
