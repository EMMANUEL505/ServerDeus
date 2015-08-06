using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace HefestoServer.Models
{
    public class Device
    {
        
        public int Device_Id { get; set; }

        [Required]
        [Display(Name = "Device Name")]
        public string Device_Name { get; set; }

        [Required]
        [Display(Name = "Latitude")]
        public double Device_Lat { get; set; }

        [Required]
        [Display(Name = "Longitude")]
        public double DEvice_Long { get; set; }

        [Required]
        [Display(Name = "Email to reports")]
        public string Device_Email { get; set; }

        [Required]
        [Display(Name = "Mode")]
        public int Device_Mode { get; set; }

        [Required]
        [Display(Name = "Status")]
        public int Device_Status { get; set; }

        [Required]
        [Display(Name = "Device zone")]
        public string Device_Zone { get; set; }

        
        [Display(Name = "Device setpoint")]
        public int Device_SetPoint { get; set; }

        
        [Display(Name = "Device Histeresys")]
        public int Device_Histerresys { get; set; }

        
        [Display(Name = "Device_OnTime")]
        public DateTime  Device_OnTime { get; set; }

       
        [Display(Name = "Device_OffTime")]
        public DateTime Device_OffTime { get; set; }

        
        [Display(Name = "Device_Port_On_Over")]
        public int Device_Port_On_Over { get; set; }

        
        [Display(Name = "Device_Port_Off_Under")]
        public int Device_Port_Off_Under { get; set; }

        
        [Display(Name = "Device_Port_In")]
        public int Device_Port_In { get; set; }

    }

}