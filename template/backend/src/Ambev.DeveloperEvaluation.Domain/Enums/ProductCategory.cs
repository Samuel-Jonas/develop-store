using System.ComponentModel.DataAnnotations;

namespace Ambev.DeveloperEvaluation.Domain.Enums;

public enum ProductCategory : byte
{
    [Display(Name = "Electronics")]
    Electronics = 0,
    
    [Display(Name = "Clothing")]
    Clothing,

    [Display(Name = "Home & Kitchen")]
    HomeAndKitchen,

    [Display(Name = "Beauty & Personal Care")]
    BeautyAndPersonalCare,

    [Display(Name = "Health & Wellness")]
    HealthAndWellness,

    [Display(Name = "Grocery")]
    Grocery,

    [Display(Name = "Toys & Games")]
    ToysAndGames,

    [Display(Name = "Books & Media")]
    BooksAndMedia,

    [Display(Name = "Sports & Outdoors")]
    SportsAndOutdoors,

    [Display(Name = "Automotive")]
    Automotive,

    [Display(Name = "Tools & Home Improvements")]
    ToolsAndHomeImprovements,

    [Display(Name = "Pet Supplies")]
    PetSupplies,

    [Display(Name = "Baby Products")]
    BabyProducts,

    [Display(Name = "Office Products")]
    OfficeProducts
}