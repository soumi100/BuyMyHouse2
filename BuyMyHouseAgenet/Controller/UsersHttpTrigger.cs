using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BuyMyHouseAgenet.Auth;
using BuyMyHouseAgenet.DTO;
using BuyMyHouseAgenet.Service.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BuyMyHouseAgenet.Controller
{
    public class UsersHttpTrigger
    {
        private IUserService _userService;
        private AuthorizationChecker _authorizationChecker;

        public UsersHttpTrigger(IUserService userService, IMapper mapper, AuthorizationChecker authorizationChecker)
        {
            _userService = userService;
            _authorizationChecker = authorizationChecker;
        }

        [EnableCors()]
        [Function(nameof(UsersHttpTrigger.Register))]
        public async Task<HttpResponseData> Register([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "register")] HttpRequestData req, FunctionContext executionContext)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                RegisterRequestDTO model = JsonConvert.DeserializeObject<RegisterRequestDTO>(requestBody);
                _userService.Register(model);
                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return req.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [Function(nameof(UsersHttpTrigger.Authenticate))]
        public async Task<HttpResponseData> Authenticate([HttpTrigger(AuthorizationLevel.Function, "POST", Route = "authenticate")] HttpRequestData req, FunctionContext executionContext)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            AuthenticateRequestDTO model = JsonConvert.DeserializeObject<AuthenticateRequestDTO>(requestBody);
            var authenticateResponse = _userService.Authenticate(model);

            if (authenticateResponse != null)
            {
                HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);
                await response.WriteAsJsonAsync(authenticateResponse);
                return response;
            }

            return req.CreateResponse(HttpStatusCode.Unauthorized);
        }

        [Function(nameof(UsersHttpTrigger.Users))]
        public async Task<HttpResponseData> Users([HttpTrigger(AuthorizationLevel.Function, "GET", Route = "users")] HttpRequestData req, FunctionContext executionContext)
        {

            if (_authorizationChecker.IsAuthorized(req))
            {
                var users = _userService.GetAll();

                HttpResponseData response = req.CreateResponse(HttpStatusCode.OK);

                await response.WriteAsJsonAsync(users);
                return response;
            }
            else
            {
                HttpResponseData response = req.CreateResponse(HttpStatusCode.Unauthorized);

                return response;
            }
        }
    }
}
