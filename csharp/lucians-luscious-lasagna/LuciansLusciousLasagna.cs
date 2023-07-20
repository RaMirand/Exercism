using Microsoft.VisualBasic;

class Lasagna
{

    public int ExpectedMinutesInOven()
    {
        int lasagnaPreparationTime = 40;

        return lasagnaPreparationTime;
    }

    public int RemainingMinutesInOven(int actualMinutes)
    {
        int lasagnaTotalTime = 40;

        return lasagnaTotalTime - actualMinutes;
    }

    public int PreparationTimeInMinutes(int lasagnaLayers)
    {
        int layerPreparationTime = 2;

        return layerPreparationTime * lasagnaLayers;
    }

   public int ElapsedTimeInMinutes(int lasagnaLayers, int timeInOven)
    {
        int layerPreparationTime = 2;
        int timeCookingLasagna = (lasagnaLayers * layerPreparationTime) + timeInOven;

        return timeCookingLasagna;
    }
    // TODO: define the 'ExpectedMinutesInOven()' method

    // TODO: define the 'RemainingMinutesInOven()' method

    // TODO: define the 'PreparationTimeInMinutes()' method

    // TODO: define the 'ElapsedTimeInMinutes()' method
}
