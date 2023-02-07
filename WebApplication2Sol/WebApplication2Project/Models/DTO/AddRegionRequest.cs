﻿namespace WebApplication2Project.Models.DTO
{
    public class AddRegionRequest
    {
        //We create AddRegionRequest because client don't want to see the ID Property. 
        public String Region_Code { get; set; }
        public string FullName { get; set; }
        public double LocalArea { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
        public long Overall_Population { get; set; }
    }
}