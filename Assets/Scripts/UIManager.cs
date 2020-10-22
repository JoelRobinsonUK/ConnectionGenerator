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
        for(int i=0; i < InputManager.conAm; i++)
        {
            int node = Random.Range(0, Mathf.RoundToInt(8 * InputManager.degSep));
            nodes[node].SetActive(true);
            nodes.RemoveAt(node);
        }
        print(InputManager.conAm);
    }
}
