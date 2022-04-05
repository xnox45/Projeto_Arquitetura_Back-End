namespace Template.Application.ViewModel
{
    public class UserAuthenticateResponseViewModel
    {
        public UserViewModel User { get; set; }
        
        public string Token{ get; set; }

        public UserAuthenticateResponseViewModel(UserViewModel user, string token)
        {
            this.User = user;

            this.Token = token;
        }
    }
}
