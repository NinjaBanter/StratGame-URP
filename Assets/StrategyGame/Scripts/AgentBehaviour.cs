using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public bool isTurn = true;
    public List<GameObject> selectableSquares = new List<GameObject>();
    public List<GameObject> usableWeapons = new List<GameObject>();
    public MapGenerator mapGen;
    public int movementRange = 3;
    //public int attackRange = 6;
    public Weapon currentWeapon;



    public Material selectedMaterial;
    public int positionX, positionZ;

    public Vector3 offsetPos = new Vector3(0, 1, 0);

    public int agentPosition;


    // Start is called before the first frame update
    void Start()
    {
        mapGen = GameObject.FindGameObjectWithTag("MapGenerator").GetComponent<MapGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a"))
        {
            foreach (GameObject i in mapGen.tilesGO)
            {
                CanMove(i);
            }
        }
    }


    public void getPosition()
    {
        positionX = this.gameObject.transform.parent.GetComponent<TileValue>().tileX;
        positionZ = this.gameObject.transform.parent.GetComponent<TileValue>().tileZ;
    }


    public void CanMove(GameObject selectedTile)
    {
        //selectableSquares.Clear();
        getPosition();
        int remRange = CanMoveX(selectedTile);
        remRange = CanMoveZ(selectedTile, remRange);

        if (remRange >= 0)
        {
            //selectedTile.GetComponent<MeshRenderer>().material = selectedMaterial;
            selectedTile.GetComponent<Renderer>().material.color = Color.blue;

            selectableSquares.Add(selectedTile);
            selectedTile.GetComponent<TileHighlight>().tileMode = 1;
        }
    }

    public void CanAttack(GameObject selectedTile, int attackRange)
    {
       // selectableSquares.Clear();
        getPosition();
        int remRange = RangeCheckX(selectedTile, attackRange);
        remRange = RangeCheckZ(selectedTile, remRange);

        if (remRange >= 0)
        {
            //selectedTile.GetComponent<MeshRenderer>().material = selectedMaterial;
            selectedTile.GetComponent<Renderer>().material.color = Color.red;

            selectableSquares.Add(selectedTile);
            selectedTile.GetComponent<TileHighlight>().tileMode = 2;
        }
    }

    public void MoveTo(GameObject selectedTile)
    {
        this.gameObject.transform.parent = null;
        this.transform.position = selectedTile.transform.position + offsetPos;
        this.gameObject.transform.SetParent(selectedTile.transform);
        ChoseAction cAction = GameObject.FindGameObjectWithTag("ChooseMenu").GetComponent<ChoseAction>();
        cAction.CloseMenuFunc();
        DeselectTiles();
        getPosition();
    }

    public void RangedAttack()
    {

    }

    public void CheckRangedTiles()
    {
        getPosition();
    }



    #region 
    public int CanMoveX(GameObject selectedTile)
    {
        TileValue tvalue = selectedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        if (tvalue.tileX >= positionX)
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = movementRange + rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = movementRange - rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }



    }

    public int CanMoveZ(GameObject selectedTile, int importRange)
    {
        TileValue tvalue = selectedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        if (tvalue.tileZ >= positionZ)
        {
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = importRange + rangedifference;
            theRemainingRange = remainingRange;

            Debug.Log("Z position is " + tvalue.tileZ + " and remaining movementRange is " + theRemainingRange);

            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = importRange - rangedifference;
            theRemainingRange = remainingRange;

            Debug.Log("Z position is " + tvalue.tileZ + " and remaining movementRange is " + theRemainingRange);

            return theRemainingRange;
        }
    }
    #endregion

    #region

    public int RangeCheckX(GameObject selectedTile, int attackRange)
    {
        TileValue tvalue = selectedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        if (tvalue.tileX >= positionX)
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = attackRange + rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = attackRange - rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
    }

    public int RangeCheckZ(GameObject selectedTile, int importRange)
    {
        TileValue tvalue = selectedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        if (tvalue.tileZ >= positionZ)
        {
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = importRange + rangedifference;
            theRemainingRange = remainingRange;

            Debug.Log("Z position is " + tvalue.tileZ + " and remaining movementRange is " + theRemainingRange);

            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = importRange - rangedifference;
            theRemainingRange = remainingRange;

            Debug.Log("Z position is " + tvalue.tileZ + " and remaining movementRange is " + theRemainingRange);

            return theRemainingRange;
        }
    }

    #endregion

    public void ShowMovableTiles()
    {
        DeselectTiles();
        selectableSquares.Clear();


        foreach (GameObject i in mapGen.tilesGO)
        {
            CanMove(i);
        }
    }

    public void ShowAttackableTiles(int attackRange)
    {
        DeselectTiles();
        selectableSquares.Clear();


        foreach (GameObject i in mapGen.tilesGO)
        {
            Debug.Log("ShowAttackableTiles Check");
            CanAttack(i, attackRange);
        }
    }

    public void DeselectTiles()
    {
        foreach (GameObject tile in selectableSquares)
        {
            Debug.Log("Deselecting a tile");
            TileHighlight tHighlight = tile.GetComponent<TileHighlight>();
            tHighlight.tileMode = 0; // Setting mode to deselected
            tile.GetComponent<Renderer>().material.color = Color.white;
        }

        selectableSquares.Clear();
    }




}