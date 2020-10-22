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

    private void Awake()
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

    private void Update()
    {
    }
}
