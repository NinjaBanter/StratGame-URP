using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public int gridX, gridZ;

    public Vector3[] tilePositions, alertTiles;
    public List<GameObject> tilesGO = new List<GameObject>();
    public GameObject baseTile;
    public GameObject theAgent;
    public GameObject theGameManager;

    public Vector3 offsetPos = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        theGameManager = GameObject.FindGameObjectWithTag("GameManager");
        tilePositions = new Vector3[(gridX + 1) * (gridZ + 1)];


        for (int i = 0, z = 0; z <= gridZ; z++) // Assigns for each Z row
        {
            for (int x = 0; x <= gridX; x++, i++) // Assigns for each X row
            {
                tilePositions[i] = new Vector3(x, 0, z);
                GameObject newTile = Instantiate(baseTile, tilePositions[i], new Quaternion(0, 0, 0, 0));
                tilesGO.Add(newTile);
                TileValue tValueScript = newTile.GetComponent<TileValue>();

                AssignValueToTile(tValueScript, x, z);
            }
        }

        int position = (Random.Range(0, tilesGO.Count));
        GameObject positionTile = tilesGO[position];

        GameObject currentCharacter = Instantiate(theAgent, positionTile.transform.position + offsetPos, new Quaternion(0, 0, 0, 0));
        SetParent(currentCharacter, positionTile);

        SelectCharacter sCharacter = theGameManager.GetComponent<SelectCharacter>();
        sCharacter.theAgent = currentCharacter;




    }
    void Update()
    {

    }




    public void AssignValueToTile(TileValue tValue, int x, int z)
    {
        tValue.tileX = x;
        tValue.tileZ = z;
    }

    public void SetParent(GameObject theCurrentCharacter, GameObject newParent)
    {
        //Makes the GameObject "newParent" the parent of the GameObject "player".
        theCurrentCharacter.transform.parent = newParent.transform;

        //Display the parent's name in the console.
        // Debug.Log("Player's Parent: " + theAgent.transform.parent.name);

        // Check if the new parent has a parent GameObject.
        if (newParent.transform.parent != null)
        {
            //Display the name of the grand parent of the player.
            Debug.Log("Player's Grand parent: " + theCurrentCharacter.transform.parent.parent.name);
        }
    }
}