﻿namespace Web.ViewModel
{
    public class PaginationInfoViewModel
    {
        public int ActualPage { get; set; }
        public int TotalItems { get; set; }

        public int TotalPages { get; set; }
        public int ItemsPerPage { get; set; }

        public string? Previous { get; set; }
        public string? Next { get; set; }

    }
}
