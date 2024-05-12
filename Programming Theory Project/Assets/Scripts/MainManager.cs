using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Base class of figures present in scene
public abstract class Figure : MonoBehaviour
{
    // check if the string is the name of the figure
    protected abstract bool IsCodeNameTheSame(string str);
    public void SetColor(string aName)
    {
        if (IsCodeNameTheSame(aName))
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void TestName(string aName)
    {
        Debug.Log("Yes, I am " + aName);
    }
}

// Child class of Figure - Box
public class Box : Figure
{
    protected override bool IsCodeNameTheSame(string str)
    {
        bool result = (str == "Box");
        if (result)
        {
            Debug.Log("Yes, I am Box");
        }
        return result;
    }
}

// Child class of Figure - Sphere
public class Sphere : Figure
{
    protected override bool IsCodeNameTheSame(string str)
    {
        bool result = (str == "Sphere");
        if (result)
        {
            Debug.Log("Yes, I am Sphere");
        }
        return result;
    }
}

// Child class of Figure - Capsule
public class Capsule : Figure
{
    protected override bool IsCodeNameTheSame(string str)
    {
        bool result = (str == "Capsule");
        if (result)
        {
            Debug.Log("Yes, I am Capsule");
        }
        return result;
    }
}


public class MainManager : MonoBehaviour
{
    // InputField
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        inputField.text = "Hello World!";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // runs it when player enter text to InputField
    public void OnEndEdit()
    {
        Debug.Log("OnEndEdit: " + inputField.text);

        // cycle through all objects in the scene. If name of the object is the same as the text in the InputField, then change color of this object to red
        foreach (Figure obj in GameObject.FindObjectsOfType<Figure>())
        {
            Debug.Log("SetColorCall for : " + obj.name);
            obj.SetColor(inputField.text);
            obj.TestName(obj.name);
        }
    }
}
