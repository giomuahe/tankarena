using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.GameLogics
{
    public class FPSCounter : MonoBehaviour
    {
        public Text FpsCounterText;
        const string textFormat = "{0} FPS";
        int ignoredFrames;
        float previousTime;
        float deltaTime;
        private void Start()
        {
            
        }

        private void Update()
        {
            ignoredFrames++;

            deltaTime = Time.realtimeSinceStartup - previousTime;
            if (deltaTime < 0.5f)
            {
                return;
            }

            FpsCounterText.text = string.Format(textFormat, (int)(ignoredFrames / deltaTime));
            ignoredFrames = 0;
            previousTime = Time.realtimeSinceStartup;
        }
    }
}
