namespace XmlElementNuker;

public static class GetDefaultElements
{
    private static readonly string[] elements = 
        [
            "DisplayName",
            "Description",
            "CubeSize",
            "BlockTopology",
            "Size",
            "ModelOffset",
            "Model",
            "UseModelIntersection",
            "SilenceableByShipSoundSystem",
            "DeformationRatio",
            "UsesDeformation",
            "MountPoints",
            "BuildProgressModels",
            "VoxelPlacement",
            "BlockPairName",
            "MirroringY",
            "MirroringZ",
            "MirroringBlock",
            "EdgeType",
            "PrimarySound",
            "ResourceSinkGroup",
            "RotorPart",
            "MinHeight",
            "MaxHeight",
            "DamageEffectName",
            "DamagedSound",
            "SafetyDetach",
            "SafetyDetachMax",
            "FlamePointMaterial",
            "FlameLengthMaterial",
            "FlameFlare",
            "FlameVisibilityDistance",
            "FlameGlareQuerySize",
            "PrimarySound",
            "DamageEffectName",
            "DestroySound",
            "Public",
            "DestroyEffect",
            "PCU",
            "TieredUpdateTimes",
            "TargetingGroups",
            "IsAirTight",
            "InventorySize",
            "WheelPlacementCollider",
            "GuiVisible",
            "PhysicalMaterial",
            "ThrusterType",
            "EmissiveColorPreset",
            "FlameIdleColor",
            "PropellerUsesPropellerSystem",
            "PropellerSubpartEntityName",
            "PropellerRoundsPerSecondOnFullSpeed",
            "PropellerRoundsPerSecondOnIdleSpeed",
            "PropellerAccelerationTime",
            "PropellerDecelerationTime",
            "PropellerMaxVisibleDistance",
            
        ];
    public static string AsString()
    {
        return string.Join(Environment.NewLine, elements);
    }
}