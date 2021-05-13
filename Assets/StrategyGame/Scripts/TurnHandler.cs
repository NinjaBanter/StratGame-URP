using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnHandler : MonoBehaviour
{
    public bool isPlayerTurn = true;

    public List<GameObject> teamCharacters = new List<GameObject>();
    public GameObject selectedCharacter;
    public GameObject choiceMenu;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowMenu()
    {
        GameObject theCanvas = GameObject.FindGameObjectWithTag("Canvas");

        Instantiate(choiceMenu, theCanvas.transform);
    }
}
