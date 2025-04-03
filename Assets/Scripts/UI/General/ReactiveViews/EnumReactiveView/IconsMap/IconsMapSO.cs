using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UI.ReactiveViews
{
    public abstract partial class IconsMapSO<TEnum> : ScriptableObject
    where TEnum : Enum
    {
        [System.Serializable]
        public class IconInfo
        {
            public TEnum EnumValue;
            public Sprite Sprite;
            public Color Color = Color.white;
        }

        public List<IconInfo> Icons;

        public Dictionary<TEnum, Sprite> IconMap => Icons.ToDictionary(x => x.EnumValue, x => x.Sprite);
        public Dictionary<TEnum, Color> ColorMap => Icons.ToDictionary(x => x.EnumValue, x => x.Color);
    }


}