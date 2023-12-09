﻿namespace Server.Interfaces;

public interface IGameAuthenticationService
{
    public class AuthenticationResult
    {
        public AuthenticationResult(bool isSuccess , string message, string token)
        {
            IsSuccess = isSuccess;
            Message = message;
            Token = token;
        }

        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
    }
    
    public AuthenticationResult Register(string username, string password);
    public AuthenticationResult Login(string username, string password);


}