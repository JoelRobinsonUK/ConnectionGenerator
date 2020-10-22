using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePositions : MonoBehaviour
{
    public static NodePositions instance;

    public Vector3[] oneDegreeSeperation;
    public Vector3[] twoDegreeSeperation;
    public Vector3[] threeDegreeSeperation;
    public Vector3[] fourDegreeSeperation;
    public Vector3[] fiveDegreeSeperation;

    public static Vector3[][] nodes;

    // Start is called before the first frame update
    void Start()
    {
        nodes = new Vector3[][] {oneDegreeSeperation, twoDegreeSeperation, threeDegreeSeperation, fourDegreeSeperation, fiveDegreeSeperation};
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
