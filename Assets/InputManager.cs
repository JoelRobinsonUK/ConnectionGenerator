using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_InputField forename, surname;
    [SerializeField] TMP_Dropdown trait, flaw;
    [SerializeField] Slider connections, seperation;
    [SerializeField] Toggle pos, neut, neg, rom;

    public static string protagForename, protagSurname;
    public float pTrait, pFlaw, conAm, degSep;
    public bool posRel, neutRel, negRel, romRel;

    public void UpdateName()
    {
        protagForename = forename.text;
        protagSurname = surname.text;
    }

    public void UpdateTraits()
    {
        pTrait = trait.value;
        pFlaw = flaw.value;
    }

    public void UpdateModifiers()
    {
        conAm = connections.value;
        degSep = seperation.value;
    }

    public void UpdateRelationships()
    {
        posRel =  pos.isOn ? true : false;
        neutRel = neut.isOn ? true : false;
        negRel = neg.isOn ? true : false;
        romRel = rom.isOn ? true : false;

    }

    public void PopulateDropdown()
    {
        trait.ClearOptions();
        trait.AddOptions(DataManager.traits);

        flaw.ClearOptions();
        flaw.AddOptions(DataManager.flaws);
    }

     public void CheckNamesExist(string check)
    {
        var protagName = this.GetType().GetField(check).GetValue(this).ToString();

        bool addName = true;

        foreach(string name in DataManager.forenames)
        {
            if (protagName.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)) {
                addName = false;
                break;
            }
            else
            {
                addName = true;
            }
        }

        if (addName)
        {
            //StartCoroutine(Requests.SendRequest(protagName));
            print("coroutine commented out");
        }

    }
     

}
