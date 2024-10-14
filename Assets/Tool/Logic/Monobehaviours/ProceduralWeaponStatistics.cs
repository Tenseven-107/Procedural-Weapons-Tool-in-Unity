using System.Collections;
using System.Collections.Generic;
using Tool.Logic.Collections;
using Tool.Logic.Parts;
using UnityEngine;


namespace Tool.Logic.Monobehaviours
{
    public class ProceduralWeaponStatistics : MonoBehaviour
    {
        [SerializeField] private List<ProcWeaponStat> weaponStats = new List<ProcWeaponStat>();
        public List<ProcWeaponStat> WeaponStats => weaponStats;
        
        // Flavor text
        [SerializeField] private string weaponName;
        [SerializeField, TextArea] private string description;
        public string WeaponName => weaponName;
        public string Description => description;
        
        
        // Loading stats from parts
        public void LoadStats(List<ProcWeaponUniquePart> parts)
        {
            // Adding stats
            var leftOverStatLists = new List<List<ProcWeaponStat>>();
            foreach (var part in parts)
            {
                var newList = new List<ProcWeaponStat>();
                for (int stat = 0; stat < part.stats.Count; stat++)
                {
                    var currentStatList = part.stats;
                    if (HasStat(currentStatList[stat].statName) == false) { weaponStats.Add(currentStatList[stat]); }
                    else { newList.Add(currentStatList[stat]); }
                }
                
                leftOverStatLists.Add(newList);
            }


            // Calculating stats
            for (int stat = 0; stat < weaponStats.Count; stat++)
            {
                var startStatValue = !weaponStats[stat].negativeStat ? weaponStats[stat].statValue : -weaponStats[stat].statValue;
                var statCopy = new ProcWeaponStat(weaponStats[stat].statName, startStatValue, weaponStats[stat].negativeStat);
                
                for (int list = 0; list < leftOverStatLists.Count; list++)
                {
                    for (int subStat = 0; subStat < leftOverStatLists[list].Count; subStat++)
                    {
                        if (leftOverStatLists[list][subStat].statName == statCopy.statName)
                        {
                            var currentStat = leftOverStatLists[list][subStat];
                            statCopy.statValue = !currentStat.negativeStat ? statCopy.statValue + currentStat.statValue : statCopy.statValue - currentStat.statValue;
                        }
                    }
                }

                statCopy.negativeStat = false;
                weaponStats[stat] = statCopy;
            }
        }

        
        // Load raw stats
        public void LoadRawStats(List<ProcWeaponStat> newStats)
        {
            weaponStats.Clear();
            for (int stat = 0; stat < newStats.Count; stat++)
            {
                var newStat = newStats[stat];
                weaponStats.Add(newStat);
            }
        }
        

        
        // Check if already has a certain stat
        public bool HasStat(string statName)
        {
            for (int stat = 0; stat < weaponStats.Count; stat++)
            {
                if (weaponStats[stat].statName == statName)
                {
                    return true;
                }
            }

            return false;
        }
        
        // Get stats Index by name
        public int GetIndexWithName(string statName)
        {
            for (int stat = 0; stat < weaponStats.Count; stat++)
            {
                if (weaponStats[stat].statName == statName)
                {
                    return stat;
                }
            }

            return 0;
        }
        
        // Get a stat by name
        public ProcWeaponStat GetStatWithName(string statName)
        {
            for (int stat = 0; stat < weaponStats.Count; stat++)
            {
                if (weaponStats[stat].statName == statName)
                {
                    return weaponStats[stat];
                }
            }

            return new ProcWeaponStat();
        }
        
        // Get a stat by Index
        public ProcWeaponStat GetStatWithIndex(int index)
        {
            return weaponStats[index];
        }
        
        // Add stat
        public void AddStat(ProcWeaponStat addedStat)
        {
            weaponStats.Add(addedStat);
        }
        
        // Modify stat
        public void ModifyStat(ProcWeaponStat stat)
        {
            var statCopy = stat;
            statCopy.statValue += stat.statValue;

            stat = statCopy;
        }
    }
}
    
