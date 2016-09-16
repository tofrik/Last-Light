using UnityEngine;
using System.Collections;

public struct Colour
{
    public string _name;
    public Color _colour;
}


public class LineScript : MonoBehaviour {
    public Material _material;
	// Use this for initialization
	void Start () {
        //_material = GetComponent<Material>();
	}
	
	// Update is called once per frame
	void Update () {
        //_material.SetColor("Tint Color", new Color(0, 0, 0, 1));
	
	}
}
