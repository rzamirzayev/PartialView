using System.ComponentModel.DataAnnotations;

namespace PustokBackTask.Models
{
    public class Setting
    {
        [MaxLength(20)]
        public string Key { get; set; }
        [MaxLength(250)]
        public string Value { get; set; }
    }
}
