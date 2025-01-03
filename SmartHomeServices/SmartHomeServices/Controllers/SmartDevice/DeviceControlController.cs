using Microsoft.AspNetCore.Mvc;
using SmartHomeServices.Helper;
using SmartHomeServices.Models.Device;
using SmartHomeServices.Models;
using static SmartHomeServices.Helper.HomeAssistantHelper;
using System.Text.Json;

namespace SmartHomeServices.Controllers.SmartDevice
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DeviceControlController : Controller
    {
        private readonly IConfiguration _Configuration;
        public DeviceControlController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        [HttpPost(Name = "LightTurnOn")]
        [Tags("设备操控")]
        [EndpointSummary("开启灯光")]
        [EndpointDescription("根据entity_id开启设备灯光,返回值实体:DeviceEntity")]
        public ApiResponse<List<DeviceEntity>> LightTurnOn([FromBody] ServicesInput input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.entity_id))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("请选择要操作的设备");
                }
                HomeAssistantHelper homeAssistantHelper = new HomeAssistantHelper();
                string homeAssistantUrl = _Configuration["HomeAssistantUrl"];
                string homeAssistantToken = _Configuration["HomeAssistantToken"];
                if (string.IsNullOrEmpty(homeAssistantUrl) || string.IsNullOrEmpty(homeAssistantToken))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("HomeAssistantUrl or HomeAssistantToken is not configured.");
                }
                HomeAssistantResponse Response = homeAssistantHelper.PostHomeAssistantResponse(homeAssistantUrl + "/api/services/light/turn_on", homeAssistantToken, JsonSerializer.Serialize(input));
                if (Response.StatusCode == 200)
                {
                    if (Response.Response.Contains("entity_id"))
                    {
                        List<DeviceEntity> DeviceEntityList = JsonSerializer.Deserialize<List<DeviceEntity>>(Response.Response);
                        return ApiResponse<List<DeviceEntity>>.Success(DeviceEntityList);
                    }
                    else
                    {
                        return ApiResponse<List<DeviceEntity>>.Failure("状态未改变");
                    }
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
        [HttpPost(Name = "LightTurnOff")]
        [Tags("设备操控")]
        [EndpointSummary("关闭灯光")]
        [EndpointDescription("根据entity_id关闭设备灯光,返回值实体:DeviceEntity")]
        public ApiResponse<List<DeviceEntity>> LightTurnOff([FromBody] ServicesInput input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.entity_id))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("请选择要操作的设备");
                }
                HomeAssistantHelper homeAssistantHelper = new HomeAssistantHelper();
                string homeAssistantUrl = _Configuration["HomeAssistantUrl"];
                string homeAssistantToken = _Configuration["HomeAssistantToken"];
                if (string.IsNullOrEmpty(homeAssistantUrl) || string.IsNullOrEmpty(homeAssistantToken))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("HomeAssistantUrl or HomeAssistantToken is not configured.");
                }
                HomeAssistantResponse Response = homeAssistantHelper.PostHomeAssistantResponse(homeAssistantUrl + "/api/services/light/turn_off", homeAssistantToken, JsonSerializer.Serialize(input));
                if (Response.StatusCode == 200)
                {
                    if (Response.Response.Contains("entity_id"))
                    {
                        List<DeviceEntity> DeviceEntityList = JsonSerializer.Deserialize<List<DeviceEntity>>(Response.Response);
                        return ApiResponse<List<DeviceEntity>>.Success(DeviceEntityList);
                    }
                    else
                    {
                        return ApiResponse<List<DeviceEntity>>.Failure("状态未改变");
                    }
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
        [HttpPost(Name = "LightToggle")]
        [Tags("设备操控")]
        [EndpointSummary("切换灯光开关状态")]
        [EndpointDescription("根据entity_id切换设备灯光状态,返回值实体:DeviceEntity")]
        public ApiResponse<List<DeviceEntity>> LightToggle([FromBody] ServicesInput input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.entity_id))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("请选择要操作的设备");
                }
                HomeAssistantHelper homeAssistantHelper = new HomeAssistantHelper();
                string homeAssistantUrl = _Configuration["HomeAssistantUrl"];
                string homeAssistantToken = _Configuration["HomeAssistantToken"];
                if (string.IsNullOrEmpty(homeAssistantUrl) || string.IsNullOrEmpty(homeAssistantToken))
                {
                    return ApiResponse<List<DeviceEntity>>.Failure("HomeAssistantUrl or HomeAssistantToken is not configured.");
                }
                HomeAssistantResponse Response = homeAssistantHelper.PostHomeAssistantResponse(homeAssistantUrl + "/api/services/light/toggle", homeAssistantToken, JsonSerializer.Serialize(input));
                if (Response.StatusCode == 200)
                {
                    if (Response.Response.Contains("entity_id"))
                    {
                        List<DeviceEntity> DeviceEntityList = JsonSerializer.Deserialize<List<DeviceEntity>>(Response.Response);
                        return ApiResponse<List<DeviceEntity>>.Success(DeviceEntityList);
                    }
                    else
                    {
                        return ApiResponse<List<DeviceEntity>>.Failure("状态未改变");
                    }
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
