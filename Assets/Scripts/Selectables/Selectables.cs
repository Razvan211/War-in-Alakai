using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RN.WIA.Selectables
{
    public class Selectables : MonoBehaviour
    {
        public bool isSelected = false;
        public GameObject selectionCircle = null;
        public virtual void Awake()
        {
            selectionCircle.SetActive(false);
        }

        public virtual void OnSelect()
        {
            ShowSelectionCircle();
            isSelected = true;
        }

        public virtual void NoSelect()
        {
            HideSelectionCircle();
            isSelected = false;
        }

        public virtual void ShowSelectionCircle()
        {
            selectionCircle.SetActive(true);
        }
        public virtual void HideSelectionCircle()
        {
            selectionCircle.SetActive(false);
        }
    }
}

