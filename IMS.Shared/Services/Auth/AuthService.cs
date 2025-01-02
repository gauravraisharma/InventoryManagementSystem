using System.Text;
using System.Text.Json;
using IMS.Shared.Common;
using IMS.Shared.Constants;
using IMS.Shared.Interface.Auth;
using IMS.Shared.RequestDto.UserDTOs;
using IMS.Shared.RequestDto;

namespace IMS.Shared.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse<string>> Login(string username, string password)
        {
            var loginPayload = new
            {
                Username = username,
                Password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Login, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<string>>(responseContent,new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiResponse;
               
            }

            return new ApiResponse<string>
            {
                IsSuccess = false,
                Message = "Failed to login"
            };
        }

        public async Task<ApiResponse<bool>> Register(string firstname, string lastname, string username, string email, string password)
        {
            var registerPayload = new
            {
                FirstName = firstname,
                LastName = lastname,
                Username = username,
                Email = email,
                Password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(registerPayload), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Register, content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<bool>>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return apiResponse;
            }

            return new ApiResponse<bool>
            {
                IsSuccess = false,
                Message = "Failed to register"
            };
        }

        public async Task<ApiResponse<List<ApplicationUserDto>>> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiEndpoints.Auth.GetAllUsers);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<ApplicationUserDto>>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse;
                }

                return new ApiResponse<List<ApplicationUserDto>>
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve users"
                };
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the request
                return new ApiResponse<List<ApplicationUserDto>>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<ApplicationUserDto>> GetUserById(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{ApiEndpoints.Auth.GetUserById}/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<ApplicationUserDto>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse;
                }

                return new ApiResponse<ApplicationUserDto>
                {
                    IsSuccess = false,
                    Message = "Failed to retrieve user"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<ApplicationUserDto>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }

        public async Task<ApiResponse<bool>> UpdateUserProfile(string userId, string email, string phone, string firstName, string lastName, string address)
        {
            // Construct the payload for updating the user profile
            var updatePayload = new
            {
                UserId = userId,
                Email = email,
                Phone = phone,
                FirstName = firstName,
                LastName = lastName ?? "",  // Handle nullable last name
                Address = address ?? ""     // Handle nullable address
            };

            // Serialize the payload and set the content type to JSON
            var content = new StringContent(JsonSerializer.Serialize(updatePayload), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync($"{ApiEndpoints.Auth.UpdateUserProfile}", content);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                  
                }

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonSerializer.Deserialize<ApiResponse<bool>>(responseContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    return apiResponse;
                }

                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = "Failed to update profile"
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<bool>
                {
                    IsSuccess = false,
                    Message = $"An error occurred: {ex.Message}"
                };
            }
        }
    }
}
