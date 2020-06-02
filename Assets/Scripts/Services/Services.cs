using System;


namespace Snake_box
{
    public sealed class Services
    {
        #region Fields
        
        private static readonly Lazy<Services> _instance = new Lazy<Services>();

        #endregion


        #region ClassLifeCycles

        public Services()
        {
            Initialize();
        }

        #endregion
        
        
        #region Properties

        public static Services Instance => _instance.Value;
        public CameraServices CameraServices { get; private set; }
        public ITimeService TimeService { get; private set; }
        public PhysicsService PhysicsService { get; private set; }
        public ISaveData SaveData { get; private set; }
        public JsonService JsonService { get; private set; }
        public LevelService LevelService { get; private set; }
        public LevelLoadService LevelLoadService { get; private set; }
        
        #endregion
        
        
        #region Methods
        
        private void Initialize()
        {
            CameraServices = new CameraServices();
            TimeService = new UnityTimeService();
            PhysicsService = new PhysicsService(CameraServices);
            SaveData = new PrefsService();
            JsonService = new JsonService();
            LevelService = new LevelService();
            LevelLoadService = new LevelLoadService();
        }
        
        #endregion
    }
}
