using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class TetaviShaderEditor : ShaderGUI
{
    
    override public void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
    {
        bool first_properties = true;
        // Goes all over the properties of the shader
        for (int i = 0; i < properties.Length;i++)
        {
            
            
            // makes arrow toggle from every property with name Show in it
            if (properties[i].name.Contains("Show"))
            {
                first_properties = false;
                properties[i].floatValue = GUILayout.Toggle(properties[i].floatValue > 0, properties[i].displayName, "Foldout", GUILayout.ExpandWidth(false)) ? 1 : 0;
                if (properties[i].floatValue > 0)
                {
                    // this for looks ahead to count how many properties will be hidden in this foldout
                    for (int j = i+1; j < properties.Length; j++)
                    {
                        int k = 0;
                        if (properties[j].name.Contains("Show"))
                        {
                            i += k;
                            break;
                        }
                        else
                        {
                            k++;
                            materialEditor.ShaderProperty(properties[j], properties[j].name);
                        }
                    }
                    
                    
                }

            }
            else
            {
                if (first_properties)
                {
                    if(!properties[i].flags.HasFlag(MaterialProperty.PropFlags.HideInInspector))
                        materialEditor.ShaderProperty(properties[i], properties[i].name);
                }
            }
            
        }

        // get the render queue , enable gpu inctancing and double sided global illumination on the material
        base.OnGUI(materialEditor,new MaterialProperty[0]);
    }
    

}