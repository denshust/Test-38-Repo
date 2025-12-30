using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float health = 100;
    public Color charactersColor;
    public Team team;
    public List<CharacterData> characters = new List<CharacterData>();
    public float spawnDelay = 1.0f; // Time delay between each spawn in seconds
    public GameObject characterPrefab;
    public Transform spawnPoint;

    void Start()
    {
        // Start the coroutine to spawn characters with a delay
        StartCoroutine(SpawnCharactersWithDelay());
    }

    IEnumerator SpawnCharactersWithDelay()
    {
        foreach (CharacterData characterData in characters)
        {
            Debug.Log("Spawning character with health: " + characterData.health + " and damage: " + characterData.damage);

            // Instantiate the characterPrefab at the spawn point
            GameObject characterObject = Instantiate(characterPrefab, spawnPoint.position, spawnPoint.rotation);

            characterObject.GetComponent<MeshRenderer>().material.color = charactersColor;

            // Get the Character component from the instantiated prefab
            Character spawnedCharacter = characterObject.GetComponent<Character>();

            // Set the values of the spawned character's properties
            if (spawnedCharacter != null)
            {
                spawnedCharacter.health = characterData.health;
                spawnedCharacter.damage = characterData.damage;
                spawnedCharacter.team = team;
            }

            // Wait for the specified delay before continuing the loop
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
