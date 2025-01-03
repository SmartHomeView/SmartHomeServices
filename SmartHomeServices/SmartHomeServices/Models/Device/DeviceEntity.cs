using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;

namespace SmartHomeServices.Models.Device
{
    public class DeviceEntity
    {
        [property: Description("设备唯一ID")]
        public string? entity_id { get; set; }
        [property: Description("设备状态")]
        public string? state { get; set; }
        [property: Description("设备详细属性")]
        public dynamic attributes { get; set; }
        [property: Description("设备最后状态改变时间")]
        public DateTime last_changed { get; set; }
        [property: Description("设备最后上报状态时间")]
        public DateTime last_reported { get; set; }
        [property: Description("设备最后更新状态时间")]
        public DateTime last_updated { get; set; }
        [property: Description("设备上下文")]
        public Context? context { get; set; }
    }
    public class Context
    {
        public string? id { get; set; }
        public object? parentid { get; set; }
        public object? userid { get; set; }
    }
}
