using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnTransform1;
    public Transform spawnTransform2;
    public Transform spawnTransform3;
    public Transform spawnTransform4;
    public Transform spawnTransform5;
    public Transform spawnTransform6;
    // Start is called before the first frame update
    void Start()
    {
        // Vector3 spawnPosition = spawnTransform.position;
        // Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space)){
            int spawnerLocation = Random.Range(0, 7);
            if(spawnerLocation == 1){
                Vector3 spawnPosition = spawnTransform1.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            } else if(spawnerLocation == 2){
                Vector3 spawnPosition = spawnTransform2.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            } else if(spawnerLocation == 3){
                Vector3 spawnPosition = spawnTransform3.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            } else if(spawnerLocation == 4){
                Vector3 spawnPosition = spawnTransform4.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            } else if(spawnerLocation == 5){
                Vector3 spawnPosition = spawnTransform5.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            } else if(spawnerLocation == 6){
                Vector3 spawnPosition = spawnTransform6.position;
                Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
