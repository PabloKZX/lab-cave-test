﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace KartGame.Track
{
    /// <summary>
    /// A class to display information about a particular racer's timings.  WARNING: This class uses strings and creates a small amount of garbage each frame.
    /// </summary>
    public class TimeDisplay : MonoBehaviour
    {
        [Tooltip("Display the time for the current lap.")]
        public TimeDisplayItem currentLapText;
        [Tooltip("Display the time for the best lap.")]
        public TimeDisplayItem bestLapText;
        
        [Tooltip("Pool object for the time display UI item.")]
        public PoolObjectDef timeDisplayItem;

        [Tooltip("Finished lap info will be displayed under this parent.")]
        public UITable finishedLapsParent; 

        public static Action OnUpdateLap;
        public static Action<int> OnSetLaps;
        
        private List<float> finishedLapTimes = new List<float>();

        private float currentLapStartTime;

        private List<TimeDisplayItem> lapTimesText = new List<TimeDisplayItem>();

        private bool lapsOver;
        void Awake()
        {
            currentLapText.SetText("");
            bestLapText.SetText("");
            currentLapText.SetTitle("Current:");
            bestLapText.SetTitle("Best Lap:");
            currentLapStartTime = 0;
            lapsOver = false;
        }

        void SetLaps(int laps)
        {

            for (int i = 0; i < laps; i++)
            {
                TimeDisplayItem newItem = timeDisplayItem.getObject(false, finishedLapsParent.transform).GetComponent<TimeDisplayItem>();
                finishedLapsParent.UpdateTable(newItem.gameObject);
                
                lapTimesText.Add(newItem);
            }
                
        }

        void OnEnable()
        {
            OnUpdateLap += UpdateLap;
            OnSetLaps += SetLaps;
        }

        TimeDisplayItem GetItem(int i)
        {

            if (i >= lapTimesText.Count)
            {
                TimeDisplayItem newItem = timeDisplayItem.getObject(false, finishedLapsParent.transform).GetComponent<TimeDisplayItem>();
                finishedLapsParent.UpdateTable(newItem.gameObject);
                lapTimesText.Add(newItem);
                return newItem;
            }

            return lapTimesText[i];
        }
        
        void OnDisable()
        {
            OnUpdateLap -= UpdateLap;
            OnSetLaps -= SetLaps;
        }

        int getBestLap()
        {
            int best = -1;
            for (int i = 0; i < finishedLapTimes.Count; i++)
            {
                if (best < 0 || finishedLapTimes[i] < finishedLapTimes[best]) best = i;
            }

            return best;
        }

        void UpdateLap()
        {
            if (lapsOver) return;

            if (currentLapStartTime == 0)
            {
                currentLapStartTime = Time.time;
                return;
            }

            var lapTime = Time.time - currentLapStartTime;

            UpdateLapTime(lapTime);

            finishedLapTimes.Add(lapTime);
            currentLapStartTime = Time.time;
            
            AddFinishedLapTime(finishedLapTimes.Count - 1);

            bestLapText.SetText(DisplaySessionBestLapTime());


            if (finishedLapTimes.Count == lapTimesText.Count)
            {
                lapsOver = true;
                currentLapText.gameObject.SetActive(false);
            }
        }

        void UpdateLapTime(float lapTime)
        {
            var model = PlayerModelProvider.Instance.Model;
            
            if(lapTime < model.BestTime)
            {
                DisplaysManager.Instance.SendUpdateEvent(DisplayType.NewRecord);
                model.BestTime = lapTime;
            }
        }

        void Update()
        {
            if (currentLapStartTime == 0) return;
            if (lapsOver) return;
            currentLapText.SetText(DisplayCurrentLapTime());
        }

        void AddFinishedLapTime(int lap)
        {
            TimeDisplayItem newItem = GetItem(lap);

            newItem.SetText(TimeUtils.GetTimeString(finishedLapTimes[lap]));
            newItem.SetTitle($"Lap {lap+1}:");
            newItem.gameObject.SetActive(true);
        }

        string DisplayCurrentLapTime()
        {
            float currentLapTime = Time.time - currentLapStartTime;
            if (currentLapTime < 0.01f) return "0:00";
            return TimeUtils.GetTimeString(currentLapTime);
        }
        
        string DisplaySessionBestLapTime()
        {
            int bestLap = getBestLap();
            if (bestLap < 0) return "";
            return TimeUtils.GetTimeString(finishedLapTimes[bestLap]);
        }
    }
}
