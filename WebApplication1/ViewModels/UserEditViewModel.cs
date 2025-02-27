﻿using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş Bırakılamaz!")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Posta adresi zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Telefon Numarası Boş Bırakılamaz!")]
        [RegularExpression(@"^(\+90|0)?\d{10}$", ErrorMessage = "Geçerli bir telefon numarası girin.")]
        [Display(Name = "Telefon Numarası")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Doğum Günü")]
        public DateTime?  BirthDate{ get; set; }


        [Display(Name = "Şehir")]
        public string City { get; set; } 


        [Display(Name = "Profil resmi")]
        public IFormFile Picture { get; set; }


        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }

    }

}
