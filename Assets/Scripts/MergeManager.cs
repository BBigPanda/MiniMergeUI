using System;
using UnityEngine;


    public class MergeManager : MonoBehaviour
    {
        public static MergeManager instance;


        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        
    }
