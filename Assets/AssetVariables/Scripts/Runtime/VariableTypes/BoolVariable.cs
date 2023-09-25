using UnityEngine;

namespace LovelyBytesGaming.AssetVariables
{
    [CreateAssetMenu(menuName = "LovelyBytesGaming/AssetVariables/Bool")]
    public class BoolVariable : Variable<bool> {
       public void Reset() => Value = false;
    };
}