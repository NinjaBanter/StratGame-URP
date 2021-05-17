using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> theTargetedSquares = new List<GameObject>();


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


    public void ShowSingleTile(GameObject theOriginTile, GameObject theTargetedTile)
    {
        TileValue originPosition = theOriginTile.GetComponent<TileValue>();
        TileValue tValue = theTargetedTile.GetComponent<TileValue>();

        if(originPosition.tileX == tValue.tileX && originPosition.tileZ == tValue.tileZ)
        {
            TargetTile(theTargetedTile);
        }
    }




    public void ShowBlastSquares(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        int remRange = CheckBlastX(range, theOriginTile, theTargetedTile);
      int finalRange = CheckBlastZ(remRange, theOriginTile, theTargetedTile);
        Debug.Log("Got this far");

        if (finalRange >= 0)
        {
            TargetTile(theTargetedTile);
        }
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
            int rangedifference = positionZ - tvalue.tileZ;
            int remainingRange = range - rangedifference;
            theRemainingRange = remainingRange;
            return theRemainingRange;
        }
    }


    public void ShowCrossSquares(int range, GameObject theOriginTile, GameObject theTargetedTile)
    {
        TileValue originPosition = theOriginTile.GetComponent<TileValue>();
        TileValue tValue = theTargetedTile.GetComponent<TileValue>();

        if(tValue.tileX <= originPosition.tileX + range && tValue.tileX >= originPosition.tileX - range && tValue.tileZ == originPosition.tileZ)
        {
            TargetTile(theTargetedTile);
        }

        if (tValue.tileZ <= originPosition.tileZ + range && tValue.tileZ >= originPosition.tileZ - range && tValue.tileX == originPosition.tileX)
        {
            TargetTile(theTargetedTile);
        }
    }



    public void AssignAppropriateAttack(Weapon theCurrentWeapon, GameObject theOriginTile, GameObject theTargetedTile)
    {
        if(theCurrentWeapon.attackType == 1)
        {
            ShowSingleTile(theOriginTile, theTargetedTile);
        }
        else
        if (theCurrentWeapon.attackType == 2)
        {
            ShowBlastSquares(theCurrentWeapon.damageRadius, theOriginTile, theTargetedTile);
        }
        else
        if (theCurrentWeapon.attackType == 3)
        {
            ShowCrossSquares(theCurrentWeapon.damageRadius, theOriginTile, theTargetedTile);
        }
    }


    public void TargetTile(GameObject theTargetedTile)
    {
        //selectedTile.GetComponent<MeshRenderer>().material = selectedMaterial;
        theTargetedTile.GetComponent<Renderer>().material.color = Color.green;
        theTargetedSquares.Add(theTargetedTile);
        theTargetedTile.GetComponent<TileHighlight>().tileMode = 3;
    }

    

}
