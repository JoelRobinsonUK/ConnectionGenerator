using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    [SerializeField] TMP_InputField forename, surname;
    [SerializeField] TMP_Dropdown trait1, trait2, trait3;
    [SerializeField] Slider connections, seperation;
    [SerializeField] Toggle pos, neut, neg, rom;

    public string protagForename, protagSurname;
    public float pTrait1, pTrait2, pTrait3, conAm, degSep;
    public bool posRel, neutRel, negRel, romRel;

    public void UpdateName()
    {
        protagForename = forename.text;
        protagSurname = surname.text;
    }

    public void UpdateTraits()
    {
        pTrait1 = trait1.value;
        pTrait2 = trait2.value;
        pTrait3 = trait3.value;
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

}
