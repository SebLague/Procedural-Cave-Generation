using UnityEditor;
using UnityEngine;
using System.Collections;

[CustomEditor(typeof(MapGenerator))]
public sealed class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var mapGenerator = (MapGenerator)target;
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Generate"))
        {
            mapGenerator.GenerateMap();
        }
        GUI.enabled = mapGenerator.IsGenerated;
        if (GUILayout.Button("Clear"))
        {
            mapGenerator.ClearMap();
        }
        if (GUILayout.Button("Save Meshes"))
        {
            mapGenerator.SaveMeshes();
        }
        GUI.enabled = true;
        GUILayout.EndHorizontal();
    }
}
