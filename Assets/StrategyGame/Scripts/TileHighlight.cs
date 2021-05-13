using System.Collections.Generic;
using UnityEngine;

public class TileHighlight : MonoBehaviour
{
    public Material defaultMaterial;
    public Material selectedMaterial;

    public int tileMode = 0;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }



    void OnMouseOver()
    {
        if (tileMode == 0)
        {
            //this.GetComponent<Renderer>().material.color = Color.green;
        }
        else
            if (tileMode == 1 || tileMode == 2)
        {
            this.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    void OnMouseExit()
    {
        if (tileMode == 1)
        {
            this.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        if (tileMode == 2)
        {
            this.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}