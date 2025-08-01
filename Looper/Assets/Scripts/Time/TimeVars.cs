public static class TimeVars
{
    static int currentTime = 0;
    static int maxTime = 10500; //3.5mins

    public static void resetCurrent() {  currentTime = 0; }
    public static void addToCurrent() { currentTime++; }

    public static int getCurrent() { return currentTime; }

    public static int getMaxTime() { return maxTime; }
}
