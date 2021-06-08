using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour, IInteractable
{
    #region Variables
        [Space, Header("Interactable Settings")]
        [SerializeField] private bool holdInteract = true;
        [SerializeField] private float holdDuration = 1f;

        [Space]
        [SerializeField] private bool multipleUse =false;
        [SerializeField] private bool isInteractable = true;

        [SerializeField] private string tooltipMessage = "You Died";
    #endregion

    #region Properties
        public float HoldDuration => holdDuration;
        public bool HoldInteract => holdInteract;
        public bool MultipleUse => multipleUse;
        public bool IsInteractable => isInteractable;

        public string TooltipMessage => tooltipMessage;

    #endregion

    #region Methods
    public virtual void OnInteract()
        {
            Debug.Log("Interacted:" + gameObject.name);
        }
    #endregion
}
