﻿namespace DefenseSim.Data
{
    public enum WeaponType
    {
        BallisticMissile,
        Drone,
        Rocket
    }

    public enum CounterMeasureType
    {
        ElectronicJamming,
        AntiAirSystem,
        InterceptorMissile
    }

    public enum ResponseStatus
    {
        Pending,
        Success,
        Fail
    }

    public enum eLocation
    {
        Iran,
        Lebanon,
        Syria,
        Yemen,
        Gaza,
        Jerusalem,
        TelAviv,
        Eilat,
        Hifa
    }
}
