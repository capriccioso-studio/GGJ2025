using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Capriccioso
{
    public class ErrorPopup : MonoBehaviour
    {
        public Animator animator;
        public TMP_Text TitleTxt, MessageTxt;
        public void ShowError(string title, string message)
        {
            TitleTxt.text = title;
            MessageTxt.text = message;
            animator.SetTrigger("ShowError");
        }
    }
}
