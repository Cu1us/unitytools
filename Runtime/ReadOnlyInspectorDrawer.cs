
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(ReadOnlyInspectorAttribute))]
public class ReadOnlyInspectorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        string displayValue = property.propertyType switch
        {
            SerializedPropertyType.Integer => property.intValue.ToString(),
            SerializedPropertyType.Boolean => property.boolValue.ToString(),
            SerializedPropertyType.Float => property.floatValue.ToString(),
            SerializedPropertyType.String => property.stringValue,
            SerializedPropertyType.Vector2 => $"[{property.vector2Value.x}, {property.vector2Value.y}]",
            SerializedPropertyType.Vector3 => $"[{property.vector3Value.x}, {property.vector3Value.y}, {property.vector3Value.z}]",
            SerializedPropertyType.Quaternion => property.quaternionValue.eulerAngles.ToString(),
            SerializedPropertyType.Enum => property.enumDisplayNames[property.enumValueIndex],
            SerializedPropertyType.ExposedReference => ExtractReferenceData(property.exposedReferenceValue),
            SerializedPropertyType.ObjectReference => ExtractReferenceData(property.objectReferenceValue),
            SerializedPropertyType.Color => property.colorValue.ToString(),
            _ => "[Readonly " + property.propertyType.ToString() + " (unsupported)]"
        };

        static string ExtractReferenceData(Object reference)
        {
            if (reference is GameObject)
            {
                GameObject refGameObject = reference as GameObject;
                if (refGameObject == null)
                    return "None (GameObject)";
                else return refGameObject.name + " (GameObject)";
            }
            else if (reference is Component)
            {
                string type = reference.GetType().Name;
                return reference.name + " (" + type + ")";
            }
            else if (reference == null)
            {
                return "null";
            }
            else return reference.name;

        }

        EditorGUI.LabelField(position, label.text, displayValue);
    }
}