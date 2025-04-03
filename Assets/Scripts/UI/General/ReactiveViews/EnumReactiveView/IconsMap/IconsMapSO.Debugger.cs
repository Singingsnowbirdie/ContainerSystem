using UnityEngine;

namespace UI.ReactiveViews
{
    public abstract partial class IconsMapSO<TEnum> : ScriptableObject
    where TEnum : System.Enum
    {
#if UNITY_EDITOR
        private void Reset()
        {
            int count = System.Enum.GetValues(typeof(TEnum)).Length;
            Icons ??= new();
            while (Icons.Count < count)
            {
                TEnum enumValue = (TEnum)System.Enum.ToObject(typeof(TEnum), Icons.Count);
                Icons.Add(new IconInfo() { EnumValue = enumValue, Sprite = null });
            }
        }
#endif
    }

}