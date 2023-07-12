using System;

static class QuestLogic
{
    public static bool CanFastAttack(bool knightIsAwake)
    {
        if (knightIsAwake == false) {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool CanSpy(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake)
    {
        if (knightIsAwake == true || archerIsAwake == true || prisonerIsAwake == true)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool CanSignalPrisoner(bool archerIsAwake, bool prisonerIsAwake)
    {
        if (archerIsAwake != true && prisonerIsAwake == true)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static bool CanFreePrisoner(bool knightIsAwake, bool archerIsAwake, bool prisonerIsAwake, bool petDogIsPresent)
    {
        if (archerIsAwake != true && petDogIsPresent == true)
        {
            return true;
        } else if (petDogIsPresent != true && prisonerIsAwake == true && archerIsAwake != true && knightIsAwake != true)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
