using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameObject))]
public class MeshColliderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GameObject selectedObject = (GameObject)target;

        if (selectedObject.GetComponent<MeshCollider>() == null)
        {
            if (GUILayout.Button("Add Mesh Collider"))
            {
                selectedObject.AddComponent<MeshCollider>();
                Debug.Log("Mesh Collider added to " + selectedObject.name);
            }
        }
        else
        {
            GUILayout.Label("MeshCollider already exists on this object.");
        }
    }
}

