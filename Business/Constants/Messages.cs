using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi.";
        public static string ProductUpdated = "Ürün güncellendi.";
        public static string ProductDeleted = "Ürün silindi.";
        public static string InvalidProductEntry = "Girilen bilgiler hatalı veya eksiktir.";

        public static string ColorAdded = "Renk bilgisi eklendi.";
        public static string ColorUpdated = "Renk bilgisi güncellendi.";
        public static string ColorDeleted = "Renk bilgisi silindi.";

        public static string BrandAdded = "Marka bilgisi eklendi.";
        public static string BrandUpdated = "Marka bilgisi güncellendi.";
        public static string BrandDeleted = "Marka bilgisi silindi.";

        public static string UserAdded = "Kullanıcı bilgileri kaydedildi.";
        public static string UserUpdated = "Kullanıcı bilgileri güncellendi.";
        public static string UserDeleted = "Kullanıcı bilgileri silindi.";

        public static string CustomerAdded = "Müşteri bilgileri kaydedildi.";
        public static string CustomerUpdated = "Müşteri bilgileri güncellendi.";
        public static string CustomerDeleted = "Müşteri bilgileri silindi.";

        public static string RentalAdded = "Kiralama bilgileri kaydedildi.";
        public static string RentalUpdated = "Kiralama bilgileri güncellendi.";
        public static string RentalDeleted = "Kiralama bilgileri silindi.";
        public static string UnavailableRental = "Zaten kiralanmış araç veya hatalı giriş...";

        public static string CarImageLimitExceeded = "Araca ait en fazla 5 resim olabilir.";
        internal static string UserNotFound = "Kullanıcı bulunamadı!";
        internal static string UserPasswordInvalid = "Kullanıcı şifresi hatalı!";
        internal static string SuccessfulLogin = "Giriş başarılı!";
        internal static string UserAlreadyExists = "Böyle bir kullanıcı zaten mevcut!";
        internal static string UserRegistered = "Kayıt işlemi başarılı.";
        internal static string AccessTokenCreated = "Access Token oluşturma işlemi başarılı.";
        internal static string AuthorizationDenied = "Yetkiniz bulunmamaktadır!";
    }
}
