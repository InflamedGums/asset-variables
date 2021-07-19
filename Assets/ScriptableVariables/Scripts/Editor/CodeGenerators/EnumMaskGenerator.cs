// TODO make file path editable
// TODO make strings const

using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

public class EnumMaskGenerator : EditorWindow
{
    private const string class_src_path = "Assets/ScriptableVariables/Scripts/Editor/CodeGenerators/Templates/EnumMaskTemplate.txt";
    private const string editor_src_path = "Assets/ScriptableVariables/Scripts/Editor/CodeGenerators/Templates/EnumMaskEditorTemplate.txt";
    private const string class_dest_path = "Assets/ScriptableVariables/Scripts/Classes/AutoGenerated/Enums/{0}Mask.cs";
    private const string editor_dest_path = "Assets/ScriptableVariables/Scripts/Editor/AutoGenerated/Enums/{0}MaskEditor.cs";

    private const string header =
@"
///////////////////////////////////////////////////////////////////
/// Automatically generated by EnumMaskGenerator.cs ///////////
///////////////////////////////////////////////////////////////////
";

    private static string nameStr = "";
    private static string valuesStr = "";
    private static int numValues = 0;
    private static int defaultValue = 0;
    private static string[] lastKnownValues;

    [MenuItem("Window/Scriptable Variables/Create or delete Enum-Mask type")]
    public static void CreateNewEnumType()
    {
        EnumMaskGenerator window = (EnumMaskGenerator)GetWindow(typeof(EnumMaskGenerator));
        window.Show();
    }

    private enum Places
    {
        _16 = 16, _32 = 32
    }
    private static Places places = Places._16;

    private void OnGUI()
    {
        GUILayout.Label("Enum Type Generator", EditorStyles.boldLabel);
        GUILayout.Space(40f);
        nameStr = EditorGUILayout.TextField("Enum Name: ", nameStr);
        GUILayout.Space(10f);
        int tmp = EditorGUILayout.IntField("Number of Values: ", numValues);
        places = (Places)EditorGUILayout.EnumPopup("Number of Bits: ", places);

        if (tmp != numValues)
        {
            if(lastKnownValues == null)
            {
                lastKnownValues = new string[tmp];
            }
            else
            {
                string[] tmpStr = new string[tmp];
                for(int i = 0; i < ((tmp < numValues) ? tmp : numValues); ++i) {
                    tmpStr[i] = lastKnownValues[i];
                }
                lastKnownValues = tmpStr;
            }
            numValues = tmp;
        }

        for (int i = 0; i < numValues; ++i)
        {
            lastKnownValues[i] = EditorGUILayout.TextField($"{i}", lastKnownValues[i] ?? "");
        }
        
        GUILayout.Space(10f);
        defaultValue = EditorGUILayout.IntField("Default Value: ", defaultValue);
        if(lastKnownValues != null)
        {
            defaultValue = (defaultValue < lastKnownValues.Length) ? defaultValue : 0;
            GUILayout.Label($"({lastKnownValues[defaultValue]})");
        }

        if (GUILayout.Button("Generate Enum Mask"))
        {
            if(!IsScriptNameValid(nameStr))
            {
                EditorUtility.DisplayDialog(
                    "Invalid Class Name", 
                    "Enum Variables should start with a letter and should only contain letters, numbers and underscores.", 
                    "Alrighty then");
                return;
            }

            valuesStr = "";

            if (lastKnownValues == null)
            {
                EditorUtility.DisplayDialog(
                    "Not enough values", 
                    "Enum variables should have at least one value.", 
                    "Alrighty then");
                return;
            }

            if (lastKnownValues.Length < 2)
            {
                if (!EditorUtility.DisplayDialog(
                    "Pointless Enum?", 
                    "You are trying to create an enum with just one value...\nU sure?", 
                    "Just do it >:(", 
                    "my mistake"))
                {
                    return;
                }
            }

            bool fallthrough = false;

            for (int i = 0; i < lastKnownValues.Length; ++i)
            {
                if (lastKnownValues[i].Length < 1)
                {
                    if (!fallthrough)
                    {
                        int answ = EditorUtility.DisplayDialogComplex(
                            "Incomplete Enum?",
                            $"Enum with value {i} is not named.\nIt will receive a default name.",
                            "Go ahead",
                            "Apply to all",
                            "Abort!");

                        if (answ == 2)
                        {
                            return;
                        }

                        if (answ == 1)
                        {
                            fallthrough = true;
                        }
                    }
                    lastKnownValues[i] = $"{nameStr}_{i}";
                }
            }

            if(lastKnownValues.Distinct().Count() != lastKnownValues.Length)
            {
                EditorUtility.DisplayDialog("Error", "Your enum contains duplicate value names.", "Sad");
                return;
            }

            for(int i = 0; i < lastKnownValues.Length; ++i)
            {
                if(!IsScriptNameValid(lastKnownValues[i]))
                {
                    EditorUtility.DisplayDialog(
                        $"Invalid Name: {lastKnownValues[i]}", 
                        "Enum Values should start with a letter and should only contain letters, numbers and underscores.", 
                        "Alrighty then");
                    return;
                }

                valuesStr += "_" + ((i + 1 < lastKnownValues.Length)
                    ? lastKnownValues[i] + $" = {i},\r\n        "
                    : lastKnownValues[i] + $" = {i}");
            }

            try
            {
                string scriptTemplate = File.ReadAllText(class_src_path);
                string editorTemplate = File.ReadAllText(editor_src_path);

                string scriptStr = string.Format(
                    scriptTemplate, 
                    header, 
                    nameStr, 
                    valuesStr, 
                    lastKnownValues.Length, 
                    (int)places, 
                    lastKnownValues[defaultValue],
                    (places == Places._16) ? "ushort" : "uint"
                );

                string editorStr = string.Format(
                    editorTemplate, 
                    header, 
                    nameStr, 
                    (int)places
                );

                FileInfo file = new FileInfo(string.Format(class_dest_path, nameStr));
                file.Directory.Create(); // If the directory already exists, this method does nothing.
                File.WriteAllText(file.FullName, scriptStr);

                file = new FileInfo(string.Format(editor_dest_path, nameStr));
                file.Directory.Create();
                File.WriteAllText(file.FullName, editorStr);

                EditorUtility.DisplayDialog(
                    "Success", 
                    $"created class script\n\n{string.Format(class_dest_path, nameStr)}\n\n" + 
                    $"and editor script\n\n{string.Format(editor_dest_path, nameStr)}\n\n" +
                    "Feel free to edit :D", 
                    "Nicenstein"
                );
                AssetDatabase.Refresh();
            }
            catch(System.Exception e)
            {
                EditorUtility.DisplayDialog("Error (Create)", e.Message, "Sad");
            }
        }

        else if (GUILayout.Button("Delete"))
        {
            try
            {
                FileInfo file = new FileInfo(string.Format(class_dest_path, nameStr));
                file.Delete();

                file = new FileInfo(string.Format(editor_dest_path, nameStr));
                file.Delete();
            }
            catch (System.Exception e)
            {
                EditorUtility.DisplayDialog("Error (Delete)", e.Message, "Sad");
            }
        }
    }

    private static bool IsScriptNameValid(string name)
    {
        // should start with a letter and can only contain numbers, letters and underscores
        Regex validName = new Regex("^[a-zA-Z]+[0-9a-zA-Z_]*$");
        return validName.IsMatch(name);
    }

    private static bool IsEnumValueValid(string name)
    {
        Regex validName = new Regex("^[a-zA-Z]+[0-9a-zA-Z_]*$");
        return validName.IsMatch(name);
    }
}