﻿namespace web_api_v8.Dtos
{
    public class TouristRouteDto
    {


        public Guid Id { get; set; }

        public required string Title { get; set; }

        public required string Description { get; set; }

        //public decimal OriginalPrice { get; set; }
        //public double? DiscountPresent { get; set; }

        public decimal? Price { get; set; }
        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? DepartureTime { get; set; }


        public string Features { get; set; }

        public string Fees { get; set; }

        public string Notes { get; set; }



        public double? Rating { get; set; }

        public string? TravelDays { get; set; }

        public string? TripType { get; set; }

        public string DepartureCity { get; set; }

        //public ICollection<TouristRoutePictureDto> TouristRoutePictures { get; set; }
    }
}
