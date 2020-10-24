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
    public static List<Color> linkColours = new List<Color>();

    private void Start()
    {
        linkColours.Add(new Color(76, 200, 63));
        linkColours.Add(new Color(212, 207, 41));
        linkColours.Add(new Color(212, 57, 41));
        linkColours.Add(new Color(195, 62, 188));
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

        if (posRel) linkColours.Add(new Color(76, 200, 63));
        if (neutRel) linkColours.Add(new Color(212, 207, 41));
        if (negRel) linkColours.Add(new Color(212, 57, 41));
        if (romRel) linkColours.Add(new Color(195, 62, 188));

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
