using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoseAction : MonoBehaviour
{
    public GameObject theAgent;
    public TurnHandler tHandler;
    public GameObject gameManager;
    public GameObject baseBtns;

    public GameObject primaryWeaponBtn, secondaryWeaponBtn;

    public Text primaryWeaponBtnTxt, secondaryWeaponBtnTxt;

    public GameObject currentMenu;

    [SerializeField]
    public int rifleRange, grenadeRange;

    [SerializeField]
    private GameObject weaponsMenu;

    public List<Weapon> weaponList = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        tHandler = gameManager.GetComponent<TurnHandler>();
        theAgent = tHandler.selectedCharacter;
        currentMenu = baseBtns;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showMovableSquares()
    {
        ResetTiles();

        theAgent = tHandler.selectedCharacter;
        AgentBehaviour aBehaviour = theAgent.GetComponent<AgentBehaviour>();
        aBehaviour.ShowMovableTiles();
    }

    public void showAttackableSquares(int attackRange)
    {
        theAgent = tHandler.selectedCharacter;
        AgentBehaviour aBehaviour = theAgent.GetComponent<AgentBehaviour>();
        aBehaviour.ShowAttackableTiles(attackRange);
    }

    public void CloseMenuFunc()
    {
        ResetTiles();
        StartCoroutine(CloseMenu());
    }

    public IEnumerator CloseMenu()
    {
        Debug.Log("I am closingmenu");
        Animation anim = this.gameObject.transform.GetComponent<Animation>();
        anim.Play("MenuDisappear");
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

    public void ResetTiles()
    {
        theAgent = tHandler.selectedCharacter;
        AgentBehaviour aBehaviour = theAgent.GetComponent<AgentBehaviour>();
        aBehaviour.DeselectTiles();
    }
    public void ShowWeaponMenu()
    {

        ResetTiles();
        OrderWeapons();
        weaponsMenu.SetActive(true);
        currentMenu.SetActive(false);
        currentMenu = weaponsMenu;
    }

    public void ShowBaseMenu()
    {
        ResetTiles();

        baseBtns.SetActive(true);
        currentMenu.SetActive(false);

        currentMenu = baseBtns;
    }

    public void PrimaryAttack()
    {
        Debug.Log("Primary Attack Radius is" + weaponList[0].attackRadius);
        showAttackableSquares(weaponList[0].attackRadius);
    }

    public void SecondaryAttack()
    {
        Debug.Log("Secondary Attack Radius is" + weaponList[1].attackRadius);
        showAttackableSquares(weaponList[1].attackRadius);
    }

    public void OrderWeapons()
    {
        foreach(GameObject weapon in theAgent.GetComponent<AgentBehaviour>().usableWeapons)
        {
            Weapon weaponScript = weapon.GetComponent<Weapon>();
            weaponList.Add(weaponScript);
        }
        primaryWeaponBtnTxt.text = weaponList[0].weaponName;
        Debug.Log("primaryWeaponBtn weapon btn .txt is " + primaryWeaponBtnTxt.text + " and the weapon name is " + weaponList[0].weaponName);
        secondaryWeaponBtnTxt.text = weaponList[1].weaponName;
        Debug.Log("primaryWeaponBtn weapon btn .txt is " + secondaryWeaponBtnTxt.text + " and the weapon name is " + weaponList[1].weaponName);
    }

    public void ClearCurrentWeapons()
    {
        foreach(Weapon weaponScript in weaponList)
        {
            weaponList.Remove(weaponScript);
        }
    }


    public void SelectWeapon()
    {
        theAgent = tHandler.selectedCharacter;

    }


}