using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        GameObject.Find("Start Screen").GetComponent<Transform>().localScale = Vector3.one;
        GameObject.Find("Protag Screen").GetComponent<Transform>().localScale = Vector3.zero;
        GameObject.Find("Main Screen").GetComponent<Transform>().localScale = Vector3.zero;
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
}
