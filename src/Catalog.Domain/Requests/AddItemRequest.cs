﻿using System;
using Catalog.Domain.Entities;

namespace Catalog.Domain.Requests
{
    public class AddItemRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string LabelName { get; set; }
        public Price Price { get; set; }
        public string PictureUri { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Format { get; set; }
        public int AvailableStock { get; set; }
        public Guid GenreId { get; set; }
        public Guid ArtistId { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
    }
}
