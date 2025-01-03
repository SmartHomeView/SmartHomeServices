using Microsoft.AspNetCore.Mvc;
using SmartHomeServices.Helper;
using SmartHomeServices.Models;
using SmartHomeServices.Models.Device;
using System.Collections.Generic;
using static SmartHomeServices.Helper.HomeAssistantHelper;

namespace SmartHomeServices.Controllers.SmartDevice
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DeviceQueryController : Controller
    {
        private readonly IConfiguration _Configuration;
        public DeviceQueryController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        [HttpGet(Name = "GetLightingDevices")]
        [Tags("设备查询")]
        [EndpointSummary("获取灯光设备列表")]
        [EndpointDescription("查询所有可操作的灯光类型设备列表,返回值实体:DeviceEntity")]
        public ApiResponse<List<DeviceEntity>> GetLightingDevices()
        {
            try
            {
                HomeAssistantHelper homeAssistantHelper = new HomeAssistantHelper();
                string homeAssistantUrl = _Configuration["HomeAssistantUrl"];
                string homeAssistantToken = _Configuration["HomeAssistantToken"];
                if (string.IsNullOrEmpty(homeAssistantUrl) || string.IsNullOrEmpty(homeAssistantToken))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("HomeAssistantUrl or HomeAssistantToken is not configured.");
                }
                HomeAssistantResponse Response = homeAssistantHelper.GetHomeAssistantResponse(homeAssistantUrl + "/api/states", homeAssistantToken);
                if (Response.StatusCode == 200)
                {
                    List<DeviceEntity> DeviceEntityList = System.Text.Json.JsonSerializer.Deserialize<List<DeviceEntity>>(Response.Response);
                    List<DeviceEntity> Result = DeviceEntityList.Where(e => e.entity_id.StartsWith("light.") && (e.state.ToLower() == "on" || e.state.ToLower() == "off")).ToList();
                    return ApiResponse<List<DeviceEntity>>.Success(Result);
                }
                else
                {
                    return ApiResponse<List<DeviceEntity>>.Failure(Response.Response);
                }
            }
            catch (Exception e)
            {
                return ApiResponse<List<DeviceEntity>>.Failure(e.Message);
            }

        }
    }
}
