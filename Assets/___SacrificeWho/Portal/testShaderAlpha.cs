using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class testShaderAlpha : MonoBehaviour
{
    Material portalmeshrendere;
    float propertyval = 0;
    bool openflag = false;
    float incrementval = .5f;
    string materialName;
    //drop event listner 
    //call it from button script  MyEventSO Openportal   Openportal.Raise();  ;;
    BoxCollider CharcterDetector;

    private void Awake()
    {
        CharcterDetector = GetComponent<BoxCollider>();
        CharcterDetector.isTrigger = false;

    }
    private void Start()
    {
        portalmeshrendere = GetComponent<MeshRenderer>().sharedMaterial;
        materialName = portalmeshrendere.shader.GetPropertyName(5);
        Debug.Log(materialName);
        portalmeshrendere.SetFloat(materialName, propertyval);

    }
    public  void Open()
    {
        Debug.Log("portalopenCalled");
        openflag = true;
        CharcterDetector.isTrigger = true;


    }
    private void Update()
    {
        if (openflag)
        {
            if (propertyval < 1f)
            {
                propertyval = Mathf.Lerp(0, 1, incrementval);
                portalmeshrendere.SetFloat(materialName, propertyval);
                incrementval += 0.1f * Time.deltaTime;
             //   Debug.Log(propertyval);

            }
        }
    }





}

