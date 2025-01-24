using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace  Capriccioso
{
    public class CDebugTools : MonoSingleton<CDebugTools>
    {
        public ErrorPopup ErrorPopup;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        public void ShowError(string title, string message)
        {
            ErrorPopup.ShowError(title, message);
        }
    }

}
