using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BuyMyHouseAgenet.Service;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace BuyMyHouseAgenet
{
    public  class HouseHttptrigger
    {
        private readonly IHouseService houseService;

        public HouseHttptrigger(IHouseService houseService)
        {
            this.houseService = houseService;
        }

        [Function("AddHouse")]
        public async Task<HttpResponseData> AddHouse([HttpTrigger(AuthorizationLevel.Anonymous,"post")] HttpRequestData req,
            FunctionContext executionContext)
        {
            House house = new House("Haarlem", 38960000, 5);
            await houseService.insertOrUpdateAsync(house);
            return req.CreateResponse(HttpStatusCode.Created);
        }
        [Function("RemoveHouse")]
        public async Task<HttpResponseData> RemoveHouse([HttpTrigger(AuthorizationLevel.Anonymous, "DELETE")] HttpRequestData req,
           FunctionContext executionContext)
        {
            string partionKey = "x";
            string rowKey = "x";
            await houseService.DeleteEntityAsync(partionKey, rowKey);
            return req.CreateResponse(HttpStatusCode.Created);
        }

        [Function("GetHouses")]
        public async Task<HttpResponseData> GetHouses([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req,
          FunctionContext executionContext , [FromQuery] double minPrice, [FromQuery] double maxPrice)
        {
            House house = new House("Haarlem", 38960000, 5);
            await houseService.insertOrUpdateAsync(house);
            return req.CreateResponse(HttpStatusCode.Created);
        }



    }
}
