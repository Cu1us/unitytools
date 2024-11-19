using UnityEngine;

/// <summary>
/// Makes a field readonly in the inspector. Does not work for collections, niche, or custom data types.
/// </summary>
public class ReadOnlyInspectorAttribute : PropertyAttribute
{
    // small class that can be used to make certain serialized fields readonly in the inspector
    // use it this way:
    // [ReadOnlyInspector][SerializeField] float ChainRotationSpeed;
    // or
    // [ReadOnlyInspector] public float ChainRotationSpeed;
}

