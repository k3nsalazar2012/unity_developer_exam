using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CanvasData
{
    [CreateAssetMenu]
    public class UIData : ScriptableObject
    {
        [Serializable]
        public class RangeData
        {
            public int Min;
            public int Max;
            public int Val;
        }

        [Serializable]
        public class ColorData
        {
            public Color Color;
            public string Letter;
        }

        [SerializeField]
        private List<string> _Items;
        public List<string> Items
        {
            get { return _Items; }
        }

        [SerializeField]
        private List<RangeData> _RangeList;
        public List<RangeData> RangeList
        {
            get { return _RangeList; }
        }

        [SerializeField]
        private List<ColorData> _Colors;
        public List<ColorData> Colors
        {
            get { return _Colors; }
        }
    }
}