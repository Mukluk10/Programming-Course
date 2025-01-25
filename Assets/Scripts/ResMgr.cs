using UnityEngine;

public static class ResMgr
{
    private static int nextID = 1;

    public static int GenID()
    {
        return nextID++;
    }
}
