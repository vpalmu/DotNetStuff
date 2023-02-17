﻿namespace CityInfo.API.Models
{
    public class CityWithoutPointOfInterestDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Description { get; set; }
    }
}
