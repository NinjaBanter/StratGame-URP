using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{

    TurnHandler tHandler;
    public GameObject gameManager;
    public GameObject mapGenerator;
    AgentBehaviour aBehaviour;
    public GameObject theAgent;

    private AttackHandler atkHandler;
    private Vector3 offsetPos = new Vector3(0, 1, 0);

    
    //Tilemode 0 = nothing
    //Tilemode 1 = Movable
    //Tilemode 2 = Attackable




    void Start()
    {
        mapGenerator = GameObject.FindGameObjectWithTag("MapGenerator");
        tHandler = this.gameObject.GetComponent<TurnHandler>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        // aBehaviour = theAgent.GetComponent<AgentBehaviour>();
        atkHandler = gameManager.GetComponent<AttackHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Agent(Clone)") // Maybe change to use tags.
                {
                    Debug.Log("Object name is " + hit.transform.name);
                    tHandler.selectedCharacter = hit.transform.gameObject;
                    tHandler.ShowMenu();
                }
                else
                    if (hit.transform.name == "BaseTile(Clone)")
                {
                    TileHighlight tHighlight = hit.transform.gameObject.GetComponent<TileHighlight>();
                    if (tHighlight.tileMode == 1)
                    {
                        tHandler.selectedCharacter.GetComponent<AgentBehaviour>().MoveTo(hit.transform.gameObject);
                    }
                 else
                        if(tHighlight.tileMode == 2)
                    {
                        GameObject theSelectedTile = hit.transform.gameObject;
                        Weapon theCurrentWeapon = theAgent.GetComponent<AgentBehaviour>().currentWeapon;
                        
                        foreach(GameObject tile in mapGenerator.GetComponent<MapGenerator>().tilesGO)
                        {
                            atkHandler.AssignAppropriateAttack(theCurrentWeapon, theSelectedTile, tile);
                        }                        
                    }
                }
            }
        }
    }


    public void AttackSquare(GameObject thePlayerAttack)
    {
       // Instantiate();
    }

}