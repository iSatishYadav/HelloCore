using HelloCore.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloCore.Api
{
    public class CitiesDataStore
    {
        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>
            {
                new CityDto
                {
                    Id = 1, Name = "New Delhi", Description = "Capital of India",
                     PointsOfInterest = new List<PointsOfInterestDto>
                     {
                         new PointsOfInterestDto
                         {
                             Id = 1,
                             Name = "India Gate",
                             Description = "India Gate"
                         }
                     }
                },
                new CityDto
                {
                    Id = 2, Name = "Mumbai", Description = "Financial Capital of India",
                    PointsOfInterest = new List<PointsOfInterestDto>
                     {
                         new PointsOfInterestDto
                         {
                             Id = 1,
                             Name = "Marine Drive",
                             Description = "Marine Drive"
                         }
                     }
                },
                new CityDto
                {
                    Id = 3, Name = "Chennai", Description = "Religious Capital of India",
                    PointsOfInterest = new List<PointsOfInterestDto>
                     {
                         new PointsOfInterestDto
                         {
                             Id = 1,
                             Name = "Marina Beach",
                             Description = "Marina Beach"
                         }
                     }
                },
                new CityDto
                {
                    Id = 4, Name = "Kolkata", Description = "Sweet Capital of India",
                     PointsOfInterest = new List<PointsOfInterestDto>
                     {
                         new PointsOfInterestDto
                         {
                             Id = 1,
                             Name = "Hawrah Bridge",
                             Description = "Hawrah Bridge"
                         }
                     }
                }
            };
        }
    }
}
