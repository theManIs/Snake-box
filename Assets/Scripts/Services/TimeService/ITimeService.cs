namespace BottomlessCloset
{
    public interface ITimeService
    {
        float DeltaTime();
        float UnscaledDeltaTime();
        float FixedDeltaTime();
        float RealtimeSinceStartup();
        float GameTime();
        long Timestamp();
        void SetTimeScale(float timeScale);

        // HACK: When the app goes foreground we should reset the accumulated delta time
        // to avoid double time skip caused by IExecuteSystem's and corresponding TimeRemainingEntitiesAdjuster's code
        // (e.g. opening chests became double time forwarded by ReduceChestTimeSystem and TimeRemainingEntitiesAdjuster)
        void ResetDeltaTime();
    }
}
