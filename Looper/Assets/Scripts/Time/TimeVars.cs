using UnityEngine;

public class TimeVars: MonoBehaviour
{
    static int currentTime = 0;
    static int maxTime = 12000; //4mins
    static int hourFrame = 1200; 
    static bool canUpdate = false;

    public static void resetCurrent() {  currentTime = 0; }
    public static void addToCurrent() { currentTime++; }
    public static int getCurrent() { return currentTime; }
    public static int getMaxTime() { return maxTime; }
    public static int getHourFrame() { return hourFrame; }
    public static void setCanUpdate(bool can) { canUpdate = can; }
    public static bool getCanUpdate() { return canUpdate; }

    private void FixedUpdate()
    {
        if (canUpdate)
            if (currentTime < maxTime)
                addToCurrent();
        else
        {
            resetCurrent();
            canUpdate = false;
        }
    }
}
