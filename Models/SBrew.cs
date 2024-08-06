using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace apiconsume2.Models
{
    public class SBrew
    {
      
        
            [Required]
            public int RowNumber { get; set; }

            [Required]
            public int Id { get; set; }

            [Required]
            [StringLength(255, ErrorMessage = "Project title cannot exceed 255 characters.")]
            public string ProjectTitleEn { get; set; }

            [StringLength(255, ErrorMessage = "Project title (AR) cannot exceed 255 characters.")]
            public string ProjectTitleAr { get; set; }

            [Required]
            [StringLength(255, ErrorMessage = "URL project title cannot exceed 255 characters.")]
            public string UrlProjectTitleEn { get; set; }

            [StringLength(1000, ErrorMessage = "Project info (EN) cannot exceed 1000 characters.")]
            public string ProjectInfoEn { get; set; }

            [StringLength(1000, ErrorMessage = "Project info (AR) cannot exceed 1000 characters.")]
            public string ProjectInfoAr { get; set; }

            [Required]
            [StringLength(2000, ErrorMessage = "Description (EN) cannot exceed 2000 characters.")]
            public string DescEn { get; set; }

            [StringLength(2000, ErrorMessage = "Description (AR) cannot exceed 2000 characters.")]
            public string DescAr { get; set; }

            [Required]
            [StringLength(255, ErrorMessage = "Image filename cannot exceed 255 characters.")]
            public string Image { get; set; }

            [StringLength(255, ErrorMessage = "Detail image filename cannot exceed 255 characters.")]
            public string DetailImage { get; set; }

            [StringLength(255, ErrorMessage = "Created by (EN) cannot exceed 255 characters.")]
            public string CreatedByEn { get; set; }

            [StringLength(255, ErrorMessage = "Created by (AR) cannot exceed 255 characters.")]
            public string CreatedByAr { get; set; }

            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "Sort index must be a non-negative integer.")]
            public int SortIndex { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public DateTime CompletedOn { get; set; }

            [Required]
            [StringLength(255, ErrorMessage = "Client name (EN) cannot exceed 255 characters.")]
            public string ClientEn { get; set; }

            [StringLength(255, ErrorMessage = "Client name (AR) cannot exceed 255 characters.")]
            public string ClientAr { get; set; }

            [Url]
            [StringLength(500, ErrorMessage = "Web link cannot exceed 500 characters.")]
            public string WebLink { get; set; }

            [Url]
            [StringLength(500, ErrorMessage = "Android link cannot exceed 500 characters.")]
            public string AndroidLink { get; set; }

            [Url]
            [StringLength(500, ErrorMessage = "iOS link cannot exceed 500 characters.")]
            public string iOSLink { get; set; }

            [Required]
            public int CategoryId { get; set; }

            [Required]
            public bool IsActive { get; set; }

            [Required]
            public bool IsDeleted { get; set; }
             public int pagesize { get; set; }
             public int pageno { get; set; }

            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "Total row count must be a non-negative integer.")]
            public int TotalRowCount { get; set; }

            [StringLength(255, ErrorMessage = "Technology IDs cannot exceed 255 characters.")]
            public string Technology { get; set; }

            [StringLength(1000, ErrorMessage = "Technology names (EN) cannot exceed 1000 characters.")]
            public string TechnologyNamesEn { get; set; }

            [StringLength(1000, ErrorMessage = "Technology images cannot exceed 1000 characters.")]
            public string TechnologyImages { get; set; }
        }
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Error { get; set; }
    }
}


