using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Character : MonoBehaviour
{
    [SerializeField]TMP_Text text;

    public string forename, surname;
    public string[] traits = new string[3];
    public string[] flaws = new string[3];

    public void Set()
    {
        forename = DataManager.forenames[Random.Range(0, DataManager.forenames.Count -1)];
        surname = DataManager.surnames[Random.Range(0, DataManager.surnames.Count -1)];

        for(int i = 0; i < 3; i++)
        {
            traits[i] = DataManager.traits[Random.Range(0, DataManager.traits.Count -1)];
            flaws[i] = DataManager.flaws[Random.Range(0, DataManager.flaws.Count -1)];
        }

        

        text.text = forename + "\n" + surname;
    }

    public void Hover()
    {
        GameObject info = GameObject.Find("Info Container");
        TMP_Text nameText = GameObject.Find("Name Info").GetComponent<TMP_Text>();
        TMP_Text traitsText = GameObject.Find("Traits Info").GetComponent<TMP_Text>();
        TMP_Text flawsText = GameObject.Find("Flaws Info").GetComponent<TMP_Text>();

        nameText.text = forename + " " + surname;
        traitsText.text = traits[0] + "\n" + traits[1] + "\n" + traits[2];
        flawsText.text = flaws[0] + "\n" + flaws[1] + "\n" + flaws[2];

        info.transform.localScale = Vector3.one;
    }

    public void Exit()
    {
        GameObject info = GameObject.Find("Info Container");

        info.transform.localScale = Vector3.zero;
    }
}
