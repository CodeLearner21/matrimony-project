﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Matrimony.Infrastructure.Data.Entities
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public string AppUserId { get; set; }        
        public AppUser AppUser { get; set; }

        public int PortfolioTypeId { get; set; }
        public PortfolioType PortfolioType { get; set; }

        public int SubCasteId { get; set; }
        public SubCaste SubCaste { get; set; }
    }
}