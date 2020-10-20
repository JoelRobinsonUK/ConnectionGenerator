using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Networking;

public class Requests : MonoBehaviour
{
    string[] targets = {"firstname","surname","trait", "flaws"};

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {

            string url = "https://hackspace-api.herokuapp.com/" + targets[i];
            var request = new UnityWebRequest(url);
            StartCoroutine(WaitForRequest(request, i));
        }

        
    }

    IEnumerator WaitForRequest(UnityWebRequest request, int target)
    {
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();
        Values[] valueList = JsonHelper.FromJson<Values>(request.downloadHandler.text);


        // check for errors

        if (request.error == null)
        {
            switch (target)
            {
                case 0:

                    foreach (Values firstname in valueList)
                    {
                        DataManager.forenames.Add(firstname.firstname);
                    }

                    break;
                case 1:

                    foreach (Values surname in valueList)
                    {
                        DataManager.surnames.Add(surname.surname);
                    }

                    break;
                case 2:

                    foreach (Values trait in valueList)
                    {
                        DataManager.traits.Add(trait.trait);
                    }

                    break;
                case 3:

                    foreach (Values flaw in valueList)
                    {
                        DataManager.flaws.Add(flaw.flaw);
                    }

                    break;

            }

        }
        else
        {
            Debug.Log("WWW Error: " + request.error);
        }
    }

    public static IEnumerator SendRequest(string name)
    {
        var jsonData = JsonUtility.ToJson(name);
        UnityWebRequest www = UnityWebRequest.Post("https://hackspace-api.herokuapp.com/firstname", jsonData);
        {
            www.method = UnityWebRequest.kHttpVerbPOST;
            www.SetRequestHeader("Content-Type", "application/json");
            www.SetRequestHeader("Accept", "application/json");
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(jsonData));
            print("request sent");
            yield return www.SendWebRequest();

        }
    }

}
