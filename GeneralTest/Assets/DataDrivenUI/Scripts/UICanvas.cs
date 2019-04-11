using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

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

        [Header("Prefab References")]
        [SerializeField]
        private Transform contentPanel;

        [SerializeField]
        private Transform colorParent;

        [Serializable]
        public class Content
        {
            public string tag;
            public GameObject prefab;
        }

        [SerializeField]
        private List<Content> contentList;

        private Dictionary<string, Queue<GameObject>> contentDictionary;

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
            if(contentDictionary == null)
                contentDictionary = new Dictionary<string, Queue<GameObject>>();
            GenerateItems();
            GenerateRanges();
            GenerateColors();
        }

        private void GenerateItems()
        {
            Content content = contentList[0];
            if (!contentDictionary.ContainsKey(content.tag))
                contentDictionary.Add(content.tag, new Queue<GameObject>());

            UpdateContentPool(content.tag, content.prefab, CurrentUIData.Items.Count);
            UpdateContent(content.tag, CurrentUIData.Items.Count);
        }

        private void GenerateRanges()
        {
            Content content = contentList[1];
            if (!contentDictionary.ContainsKey(content.tag))
                contentDictionary.Add(content.tag, new Queue<GameObject>());

            UpdateContentPool(content.tag, content.prefab, CurrentUIData.RangeList.Count);
            UpdateContent(content.tag, CurrentUIData.RangeList.Count);
        }

        private void GenerateColors()
        {
            Content content = contentList[2];
            if (!contentDictionary.ContainsKey(content.tag))
                contentDictionary.Add(content.tag, new Queue<GameObject>());

            UpdateContentPool(content.tag, content.prefab, CurrentUIData.Colors.Count);
            UpdateContent(content.tag, CurrentUIData.Colors.Count);

            colorParent.SetAsLastSibling();
        }

        private void UpdateContentPool(string tag, GameObject prefab, int count)
        {
            while (contentDictionary[tag].Count < count)
            {
                GameObject content = Instantiate(prefab);
                if(tag != "color")
                    content.transform.SetParent(contentPanel);
                else
                    content.transform.SetParent(colorParent);

                content.transform.localPosition = Vector3.zero;
                content.transform.localScale = Vector3.one;
                contentDictionary[tag].Enqueue(content);
            }
        }

        private void UpdateContent(string tag, int count)
        {
            for (int i = 0; i < contentDictionary[tag].Count; i++)
            {
                GameObject content = contentDictionary[tag].Dequeue();
                content.SetActive(false);

                if (i < count)
                {
                    switch (tag)
                    {
                        case "item":
                            content.GetComponentInChildren<Text>().text = CurrentUIData.Items[i];
                            content.SetActive(true);
                            break;
                        case "range":
                            var texts = content.GetComponentsInChildren<Text>();
                            var slider = content.GetComponentInChildren<Slider>();

                            texts[0].text = CurrentUIData.RangeList[i].Min.ToString();
                            texts[1].text = CurrentUIData.RangeList[i].Max.ToString();
                            texts[2].text = CurrentUIData.RangeList[i].Val.ToString();

                            slider.minValue = CurrentUIData.RangeList[i].Min;
                            slider.maxValue = CurrentUIData.RangeList[i].Max;
                            slider.value = CurrentUIData.RangeList[i].Val;
                            break;
                        case "color":
                            content.GetComponentInChildren<Image>().color = CurrentUIData.Colors[i].Color;
                            content.GetComponentInChildren<Text>().text = CurrentUIData.Colors[i].Letter;
                            break;
                    }
                    content.SetActive(true);
                }
                contentDictionary[tag].Enqueue(content);
            }
        }
    }
}