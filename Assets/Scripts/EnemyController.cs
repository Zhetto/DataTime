using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int totalEnemy, maxEnemy,spawnedEnemys,diedEnemys;
    [SerializeField]
    GameObject[] spawners;
    [SerializeField]
    GameObject enemy,door;
    // Start is called before the first frame update
    void Start()
    {
        totalEnemy = 3;
        maxEnemy = 10;
        StartCoroutine(spawnEnemys());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (diedEnemys >= maxEnemy)
        {
            //Debug.Log("Liberar a porta");
            Destroy(door);
            Destroy(this.gameObject);
        }
    }

    IEnumerator spawnEnemys()
    {
        while (true)
        {            
            int delay = 2;
            if (spawnedEnemys < totalEnemy && spawnedEnemys+diedEnemys<maxEnemy)
            {
                int wish = Random.Range(0, spawners.Length);
                Instantiate(enemy, spawners[wish].transform.position, spawners[wish].transform.rotation, this.transform);
                spawnedEnemys++;
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
