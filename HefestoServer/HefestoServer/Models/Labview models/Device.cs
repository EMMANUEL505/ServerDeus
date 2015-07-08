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

    }

}