using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class InputManager : MonoBehaviour
{
    public static InputManager instance;

    [SerializeField] TMP_Text protagText, degSepText, conAmText;
    [SerializeField] TMP_InputField forename, surname;
    [SerializeField] TMP_Dropdown trait, flaw;
    [SerializeField] public Slider connections, seperation;
    [SerializeField] Toggle pos, neut, neg, rom;

    public static string protagForename, protagSurname;
    public static float pTrait, pFlaw, conAm = 25, degSep = 3;
    public bool posRel = true, neutRel = true, negRel = true, romRel = true;
    public static List<string> linkColours = new List<string>();

    private void Start()
    {
        linkColours.Add("pos");
        linkColours.Add("neut");
        linkColours.Add("neg");
        linkColours.Add("rom");
    }

    public void UpdateName()
    {
        protagForename = forename.text;
        protagSurname = surname.text;
        protagText.text = protagForename + "\n" + protagSurname;
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

        degSepText.text = degSep.ToString();
        conAmText.text = conAm.ToString();

        switch (degSep)
        {
            case 1:
                connections.maxValue = 8;
                break;
            case 2:
                connections.maxValue = 24;
                break;
            case 3:
                connections.maxValue = 56;
                break;
            case 4:
                connections.maxValue = 120;
                break;
            case 5:
                connections.maxValue = 248;
                break;
        }

        
    }

    public void UpdateRelationships()
    {
        linkColours.Clear();

        posRel =  pos.isOn ? true : false;
        neutRel = neut.isOn ? true : false;
        negRel = neg.isOn ? true : false;
        romRel = rom.isOn ? true : false;

        if (posRel) linkColours.Add("pos");
        if (neutRel) linkColours.Add("neut");
        if (negRel) linkColours.Add("neg");
        if (romRel) linkColours.Add("rom");

    }

    public void PopulateDropdown()
    {
        trait.ClearOptions();
        trait.AddOptions(DataManager.traits);

        flaw.ClearOptions();
        flaw.AddOptions(DataManager.flaws);
    }

     public void CheckNamesExist()
    {

        bool addFore = true, addSur = true;

        foreach(string name in DataManager.forenames)
        {
            if (protagForename.Equals(name, System.StringComparison.InvariantCultureIgnoreCase)) {
                addFore = false;
                break;
            }
            else
            {
                addFore = true;
            }
        }

        if (addFore)
        {
            StartCoroutine(Requests.SendRequest(protagForename, "firstname"));
        }

        foreach (string name in DataManager.surnames)
        {
            if (protagSurname.Equals(name, System.StringComparison.InvariantCultureIgnoreCase))
            {
                addSur = false;
                break;
            }
            else
            {
                addSur = true;
            }
        }

        if (addSur)
        {
            StartCoroutine(Requests.SendRequest(protagSurname, "surname"));
        }

    }
     

}
