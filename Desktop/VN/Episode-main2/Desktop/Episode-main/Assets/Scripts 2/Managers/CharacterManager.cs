using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;
    public Transform[] actorPositions;
    public List<GameObject> Spawnedcharacters=new List<GameObject>();
    public static CharacterManager instance;
    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        { instance = this; }
        else
        { Debug.LogWarning("More than one characterManager used");}
    }
    public void GenerateCharacter(int index, int positionIndex)
    {
        if (characters.Length - 1 < index || index < 0) return;
        GameObject Spawnedcharacter = Instantiate(characters[index]);
       //Spawnedcharacter.transform.position = actorPositions[positionIndex].position;
        Spawnedcharacter.transform.position = Spawnedcharacter.transform.position;
        Spawnedcharacters.Add(Spawnedcharacter);
    }
    public void ClearActors()
    {
        foreach(GameObject character in Spawnedcharacters)
        { Destroy(character); }
        Spawnedcharacters.Clear();
    }
   
}
