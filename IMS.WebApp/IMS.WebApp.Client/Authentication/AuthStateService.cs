﻿namespace IMS.WebApp.Client.Authentication
{
    public class AuthStateService
    {
        public event Action OnChange;

        private bool _isLoggedIn;
        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set
            {
                if (_isLoggedIn != value)
                {
                    _isLoggedIn = value;
                    NotifyStateChanged();
                }
            }
        }

        private string _userRole;
        public string UserRole
        {
            get => _userRole;
            set
            {
                if (_userRole != value)
                {
                    _userRole = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}