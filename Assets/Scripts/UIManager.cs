using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    List<GameObject> nodes;

    [SerializeField] GameObject character, displayPanel;
    private void Start()
    {
        GameObject.Find("Start Screen").GetComponent<Transform>().localScale = Vector3.one;
        GameObject.Find("Protag Screen").GetComponent<Transform>().localScale = Vector3.zero;
        GameObject.Find("Main Screen").GetComponent<Transform>().localScale = Vector3.zero;

        nodes = GameObject.Find("Position Manager").GetComponent<Nodes>().nodes;
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

        int count = 0;

        while(count < InputManager.conAm)
        {
            int node = Random.Range(0, Mathf.RoundToInt(GameObject.Find("Input Manager").GetComponent<InputManager>().connections.maxValue - 1));

            if (!nodes[node].activeInHierarchy)
            {
                nodes[node].SetActive(true);
                nodes[node].GetComponent<Character>().Set();
                print(node);
                count++;
            }
        }
    }
}
