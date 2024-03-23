using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor;

public class CreditBuilder : MonoBehaviour
{
    [SerializeField]
    private VisualElement _rootElement;
    [SerializeField]
    private UIDocument _rootDocument;
    [SerializeField]
    private BackgroundGenerator _backgroundGenerator;
    private void OnEnable()
    {
        _rootElement = _rootDocument.rootVisualElement;
        VisualElement creditBackground = _backgroundGenerator.GenerateCreditBackground();
        _rootElement.Add(creditBackground);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[CustomEditor(typeof(CreditBuilder))]
[CanEditMultipleObjects]
public class BackgroundGeneratorEditor : Editor
{
    private SerializedProperty _rootDocumentProperty;
    private SerializedProperty _backgroundGeneratorProperty;
    private SerializedProperty _fillTypeProperty;
    private SerializedProperty _backgroundColorProperty;
    private SerializedProperty _backgroundImageProperty;
    private void OnEnable()
    {
        _rootDocumentProperty = serializedObject.FindProperty("_rootDocument");
        _backgroundGeneratorProperty = serializedObject.FindProperty("_backgroundGenerator");
        _fillTypeProperty = _backgroundGeneratorProperty.FindPropertyRelative("_fillType");
        _backgroundColorProperty = _backgroundGeneratorProperty.FindPropertyRelative("_backgroundColour");
        _backgroundImageProperty = _backgroundGeneratorProperty.FindPropertyRelative("_backgroundImage");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(_rootDocumentProperty);
        EditorGUILayout.PropertyField(_fillTypeProperty);
        BackgroundFillType selectedFillType = (BackgroundFillType)_fillTypeProperty.intValue;
        if (selectedFillType == BackgroundFillType.Colour)
        {
            EditorGUILayout.PropertyField(_backgroundColorProperty);
        }
        else if (selectedFillType == BackgroundFillType.Image)
        {
            EditorGUILayout.PropertyField(_backgroundImageProperty);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
