using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{

    TurnHandler tHandler;
    AgentBehaviour aBehaviour;
    public GameObject theAgent;

    private Vector3 offsetPos = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        tHandler = this.gameObject.GetComponent<TurnHandler>();
        // aBehaviour = theAgent.GetComponent<AgentBehaviour>();
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
                }
            }
        }
    }




    public void AttackSquare(GameObject thePlayerAttack)
    {
       // Instantiate();
    }

}