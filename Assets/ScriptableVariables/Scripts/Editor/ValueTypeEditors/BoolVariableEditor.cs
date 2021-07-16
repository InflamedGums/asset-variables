using UnityEditor;

namespace CustomLibrary.Util.ScriptableVariables
{
    [CustomEditor(typeof(BoolVariable))]
    public class BoolVariableEditor : ValueTypeEditor<bool>
    {
        protected override bool GenericEditorField(string description, bool value)
            => EditorGUILayout.Toggle(description, value);
    }
}
