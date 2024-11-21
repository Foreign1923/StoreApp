using Services.Contracts;

namespace StoreApp.Components
{
    public class UserSummaryViewComponent
    {
        private readonly IServiceManager _manager;

        public UserSummaryViewComponent(IServiceManager manager)
        {
            _manager = manager;
        }
        public string Invoke()
        {
            return _manager
                .AuthService
                .GetAllUsers()
                .Count()
                .ToString();
        }
    }
}
