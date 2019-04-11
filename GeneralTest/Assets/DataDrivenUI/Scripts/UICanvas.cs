using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace CanvasData
{
    public class UICanvas : MonoBehaviour
    {
        #region Property Fields
        [SerializeField]
        private int CurrentIndex = 0;

        [SerializeField]
        private UIData CurrentUIData;

        [SerializeField]
        private List<UIData> UIDataList;
        
        #endregion

        #region Unity Life Cycle
        private void Awake()
        {
            LoadData(0);
        }
        #endregion

        #region Private Functionality
        private void LoadData(int index)
        {
            CurrentIndex = Mathf.Clamp(index, 0, UIDataList.Count - 1);
            CurrentUIData = UIDataList[CurrentIndex];
            GenerateUI();
        }
        #endregion

        #region Unity Button Events
        public void Prev()
        {
            LoadData(CurrentIndex - 1);
        }

        public void Next()
        {
            LoadData(CurrentIndex + 1);
        }
        #endregion

        // *************************************************************************************************************
        // Generate UI here based on the current data
        // *************************************************************************************************************
        private void GenerateUI()
        {
            
        }
    }
}