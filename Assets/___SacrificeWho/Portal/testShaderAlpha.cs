using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class testShaderAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

      var bla = GetComponent<MeshRenderer>().sharedMaterial;
      bla.SetFloat("Vector1_28f208c908e649e7b83238f7866a5264", 0);
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
