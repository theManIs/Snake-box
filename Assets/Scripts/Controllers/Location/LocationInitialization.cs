namespace BottomlessCloset
{
    public sealed class LocationInitialization : IInitialization
    {   
        #region Fields
        
        private readonly LocationService _locationService;
        
        #endregion

        
        #region ClassLifeCycles

        public LocationInitialization()
        {
            _locationService = Services.Instance.LocationService;
        }
        
        #endregion  
        
        
        #region IInitialization

        public void Initialization()
        {
            _locationService.Load();
        }

        #endregion
    }
}
