using System;
using TMPro;
using UnityEngine;

namespace _Scripts.UI
{
    public class ScoreBehaviour : MonoBehaviour
    {
        private TextMeshProUGUI textmeshPro;
        // public static float time;
        public static int score;
        private int highscore;

        // Start is called before the first frame update
        void Start()
        {
            textmeshPro = GetComponent<TextMeshProUGUI>();
        
            // set score value to be zero
            // time = 0;
            score = 0;
            highscore = 0;
        }

        // Update is called once per frame
        void Update()
        {
            // if (running == true)
            // {
            //     time += Time.deltaTime;
            // }

            // int currentLife = GameManager._currentPlayerLive;
            // if (currentLife == 0)
            // {
            //     StopTimer();
            // }
            string sTime = GameManager.time.ToString("F2");
            // update text of Text element
            textmeshPro.SetText("Time: {0} \nScore: {1} \nHighscore: {2} \nLife: {3}", 
                Convert.ToSingle(sTime), score, highscore, GameManager._currentPlayerLive);
        }
    }
}
