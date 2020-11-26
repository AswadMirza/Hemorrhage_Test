/** 
* Last modified 25/11/2020 
* By: Sharek Khan 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityLog
{
    private static List<string> m_events = new List<string>(); 

    public static void AddActivity(string _event)
    {
        // Adds a new event to the log
        m_events.Add(_event);
        // Keeps the last events to conserve memory space
        if(m_events.Count > 15)
        {
            // Removes first index from list of events
            m_events.RemoveAt(0);
        }
    }

    public static string ReadRecentActivity()
    {
        // Checks if event log has any events added
        if(m_events.Count != 0)
        {
            // Returns the last event logged
            return m_events[m_events.Count - 1];
        }
        // No events logged, returns an empty string
        return "";
    }
}
