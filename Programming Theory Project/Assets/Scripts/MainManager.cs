using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

// Base class of figures present in scene
public abstract class FigureComponent : MonoBehaviour
{
    private UnityEngine.Color m_color;
    // color of the figure as property
    public UnityEngine.Color color
    {
        get { return m_color; }
        protected set
        {
            m_color = value;
        }
    }

    // check if the string is the name of the figure
    protected abstract bool IsCodeNameTheSame(string str);
    public void SetColor(string aName)
    {
        if (IsCodeNameTheSame(aName))
        {
            gameObject.GetComponent<Renderer>().material.color = color;
        }
    }

    // Initialization
    public virtual void Initialization()
    {
        color = UnityEngine.Color.black;
    }
}

// Child class of Figure - Box
public class BoxComponent : FigureComponent
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

    // Initialization
    public override void Initialization()
    {
        base.Initialization();
        color = UnityEngine.Color.green;
    }
}

// Child class of Figure - Sphere
public class SphereComponent : FigureComponent
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

    // Initialization
    public override void Initialization()
    {
        base.Initialization();
        color = UnityEngine.Color.yellow;
    }
}

// Child class of Figure - Capsule
public class CapsuleComponent : FigureComponent
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

    // Initialization
    public override void Initialization()
    {
        base.Initialization();
        color = UnityEngine.Color.red;
    }
}


public class MainManager : MonoBehaviour
{
    // InputField
    public TMP_InputField inputField;

    // Start is called before the first frame update
    void Start()
    {
        // search scene for all objects with given names and add components to them
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            switch (obj.name)
            {
                case "Box":
                    obj.AddComponent<BoxComponent>().Initialization();
                    break;
                case "Sphere":
                    obj.AddComponent<SphereComponent>().Initialization();
                    break;
                case "Capsule":
                    obj.AddComponent<CapsuleComponent>().Initialization();
                    break;
                    //   default:
                    //       Debug.Log("No matching component found for this GameObject");
                    //       break;
            }

        }

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
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            FigureComponent figure = obj.GetComponent<FigureComponent>();
            if (figure != null)
            {
                // Usinng overriden method
                figure.SetColor(inputField.text);
                // Using public color property with get
                Debug.Log("Color changed: " + figure.color);
            }
        }
    }
}
