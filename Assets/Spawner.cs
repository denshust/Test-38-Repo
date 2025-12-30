using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPrefab;

    private int teamCounter=0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Character character = Instantiate(spawnPrefab, transform.position + 
            new Vector3(Random.Range(-4f,4f), 
                        Random.Range(-4f, 4f), 
                        Random.Range(-4f, 4f)),
                        Quaternion.identity)
            .GetComponent<Character>();


        switch (teamCounter%3)
        { 
            case 0:
                character.team = Team.Blue;
                character.GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case 1:
                character.team = Team.Red;
                character.GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case 2:
                character.team = Team.Green;
                character.GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            //case 3:
            //    character.team = Team.Green;
            //    character.GetComponent<MeshRenderer>().material.color = Color.green;
            //    break;
        }

        teamCounter++;
    }
}
