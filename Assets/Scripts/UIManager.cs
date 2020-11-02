using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

public class UIManager : MonoBehaviour
{
    List<GameObject> nodes, activeNodes;

    [SerializeField] GameObject character, line, displayPanel;
    private void Start()
    {
        GameObject.Find("Start Screen").GetComponent<Transform>().localScale = Vector3.one;
        GameObject.Find("Protag Screen").GetComponent<Transform>().localScale = Vector3.zero;
        GameObject.Find("Main Screen").GetComponent<Transform>().localScale = Vector3.zero;

        nodes = GameObject.Find("Position Manager").GetComponent<Nodes>().nodes;
        activeNodes = new List<GameObject>();
    }

    public void GetStarted()
    {
        StartCoroutine("GetStart");
    }

    public void Next()
    {
        StartCoroutine("Next1");
    }

    public IEnumerator GetStart()
    {
        LeanTween.scale(GameObject.Find("Start Screen"), Vector2.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(GameObject.Find("Protag Screen"), Vector2.one, 0.5f);
    }

    public IEnumerator Next1()
    {
        LeanTween.scale(GameObject.Find("Protag Screen"), Vector2.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        LeanTween.scale(GameObject.Find("Main Screen"), Vector2.one, 0.5f);
    }

    public void GenerateCharacters()
    {
        foreach(GameObject node in nodes)
        {
            node.SetActive(false);
        }

        var lines = new List<GameObject>();
        foreach (Transform child in GameObject.Find("Line Container").transform) lines.Add(child.gameObject);
        lines.ForEach(child => Destroy(child));

        activeNodes.Clear();

        int count = 0;

        while(count < InputManager.conAm)
        {
            int node = Random.Range(0, Mathf.RoundToInt(GameObject.Find("Input Manager").GetComponent<InputManager>().connections.maxValue - 1));

            if (!nodes[node].activeInHierarchy)
            {
                nodes[node].SetActive(true);
                nodes[node].GetComponent<Character>().Set();
                activeNodes.Add(nodes[node]);

                GameObject newLine = Instantiate(line, GameObject.Find("Line Container").transform);
                string setColor = InputManager.linkColours[Random.Range(0, InputManager.linkColours.Count)];

                print(setColor);

                if (setColor == "pos") { newLine.GetComponent<UILineRenderer>().color = new Color(0, 255, 0); }

                if (setColor == "neut") { newLine.GetComponent<UILineRenderer>().color = new Color(200, 200, 0); }

                if (setColor == "neg") { newLine.GetComponent<UILineRenderer>().color = new Color(255, 0, 0); }

                if (setColor == "rom") { newLine.GetComponent<UILineRenderer>().color = new Color(200, 0, 200); }

                if (node <= 7)
                {
                    
                    newLine.GetComponent<UILineRenderer>().Points[0] = nodes[node].GetComponent<RectTransform>().anchoredPosition;
                    newLine.GetComponent<UILineRenderer>().Points[1] = Vector2.zero;
                    //newLine.GetComponent<UILineRenderer>().color = InputManager.linkColours[Random.Range(0, InputManager.linkColours.Count - 1)];
                    
                } 
                else if (node >= 8 && node < 23)
                {
                    newLine.GetComponent<UILineRenderer>().Points[0] = nodes[node].GetComponent<RectTransform>().anchoredPosition;

                    int targetNode;

                    do
                    {
                        targetNode = Random.Range(7, Mathf.RoundToInt(GameObject.Find("Input Manager").GetComponent<InputManager>().connections.maxValue - 1));

                        newLine.GetComponent<UILineRenderer>().Points[1] = activeNodes[Random.Range(0, activeNodes.Count)].GetComponent<RectTransform>().anchoredPosition;
                    } 
                    while (!nodes[targetNode].activeInHierarchy);

                    
                }

                

                count++;
            }
        }
    }
}
