using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowAttackedSquares(Weapon theWeapon, GameObject theOriginTile)
    {

    }


    public void ShowBlastSquares(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        int remRange = CheckBlastX(range, theOriginTile, theTargetedTile);
      int finalRange = CheckBlastZ(remRange, theOriginTile, theTargetedTile);
        Debug.Log("Got this far");

        if (finalRange >= 0)
        {
            //selectedTile.GetComponent<MeshRenderer>().material = selectedMaterial;
            theTargetedTile.GetComponent<Renderer>().material.color = Color.green;

            //selectableSquares.Add(selectedTile);
            //selectedTile.GetComponent<TileHighlight>().tileMode = 1;
        }
    }

    public void ShowCrossSquares(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        TileValue originValue = theOriginTile.GetComponent<TileValue>();
        TileValue TargetedTileValue = theTargetedTile.GetComponent<TileValue>();

        if(TargetedTileValue.tileX   originValue.tileX) //Put in code to make a cross
    }

    private int CheckBlastX(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        TileValue tvalue = theTargetedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        int positionX = theOriginTile.GetComponent<TileValue>().tileX;

        if (tvalue.tileX >= positionX)
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = range + rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionX - tvalue.tileX;
            int remainingRange = range - rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
    }

    private int CheckBlastZ(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        TileValue tvalue = theTargetedTile.GetComponent<TileValue>();
        int theRemainingRange = 0;

        int positionZ = theOriginTile.GetComponent<TileValue>().tileZ;

        if (tvalue.tileZ >= positionZ)
        {
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = range + rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
        else
        {
            int rangedifference = positionZ - tvalue.tileX;
            int remainingRange = range - rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
    }
}
