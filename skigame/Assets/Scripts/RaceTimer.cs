using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTimer : MonoBehaviour
{
 private bool timerRunning = false;
 private float raceTime = 0;
 [SerializeField]  private float penaltyTime = 1;
 [SerializeField]  private Leaderboard leaderboard;

 private void Update()
 {
  if (timerRunning)
   raceTime += Time.deltaTime;
  
 }

 private void OnEnable()
 {
  GameEvents.raceStart += StartRace;
  GameEvents.raceEnd += FinishRace;
 }
 
 private void OnDisable()
 {
  GameEvents.raceStart -= StartRace;
  GameEvents.raceEnd -= FinishRace;
 }

 private void Penalty()
 {
  raceTime += penaltyTime;
  Debug.Log("penalty received");
 }
 private void StartRace()
 {
  raceTime = 0;
  timerRunning = true;
  Debug.Log("Race started");
 }

 private void FinishRace()
 {
  timerRunning = false;
  leaderboard.AddTime(raceTime);
  GameData.Instance.racesCompleted++;
  Debug.Log("Races Completed :" + GameData.Instance.racesCompleted);
  Debug.Log("Race finished");
  Debug.Log("time" + raceTime);
 }
}
