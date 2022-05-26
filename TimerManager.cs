using System.Collections.Generic;
using UnityEngine;
    public class TimerManager : Singleton<TimerManager>
    {


        Dictionary<string, Timer> timerDict = new Dictionary<string, Timer>();


        void Update() {

            // If active timers in dictionary, increase their times
            if (timerDict.Count > 0) {

                foreach (KeyValuePair<string, Timer> dictVal in timerDict) {

                    if (dictVal.Value.active) {
                        dictVal.Value.time += Time.deltaTime;
                    }
                }
            }
        }


        public void BeginTimer(string name) {

            if (!timerDict.ContainsKey(name)) {
                timerDict.Add(name, new Timer());
            }

            timerDict[name].Begin();
        }


        public float GetTime(string name) {

            if (timerDict.ContainsKey(name)) {
                return timerDict[name].time;
            }

            return 0f;
        }


        public void Reset(string name) {

            timerDict[name].Reset();
        }

    } // class

    public class Timer
    {

        public float time;
        public bool active;

        public Timer() {
            time = 0f;
        }

        public void Begin() {
            active = true;
        }

        public void Reset() {
            active = false;
            time = 0f;
        }

    } // class
