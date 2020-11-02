using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.Networking;

public class Requests : MonoBehaviour
{
    string[] targets = {"firstnames","surnames","traits", "flaws"};

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

    public static IEnumerator SendRequest(string name, string target)
    {
        UnityWebRequest www = UnityWebRequest.Put("https://hackspace-api.herokuapp.com/" + target + "s", "{\"" + target + "\": \"" + name + "\"}");
        {
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Error While Sending" + www.error);
            }
            else
            {
                Debug.Log("Received" + www.downloadHandler.text);
            }
        }
    }

}
