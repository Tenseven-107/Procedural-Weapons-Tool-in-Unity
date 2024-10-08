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
        
        
        // Loading stats from parts
        public void LoadStats(List<ProcWeaponUniquePart> parts)
        {
            // Adding stats
            foreach (var part in parts)
            {
                for (int stat = 0; stat < part.stats.Count; stat++)
                {
                    var currentStatList = part.stats;
                    if (HasStat(currentStatList[stat].statName) == false) { weaponStats.Add(currentStatList[stat]); }
                }
            }
            
            // Calculating stats
            for (int stat = 0; stat < weaponStats.Count; stat++)
            {
                var startStatValue = !weaponStats[stat].negativeStat ? weaponStats[stat].statValue : -weaponStats[stat].statValue;
                var statCopy = new ProcWeaponStat(weaponStats[stat].statName, startStatValue, weaponStats[stat].negativeStat);

                foreach (var part in parts)
                {
                    for (int partStat = 0; partStat < part.stats.Count; partStat++)
                    {
                        var currentStat = part.stats[partStat];
                        statCopy.statValue = !currentStat.negativeStat ? statCopy.statValue + currentStat.statValue : statCopy.statValue - currentStat.statValue;
                    }
                }

                weaponStats[stat] = statCopy;
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
    
