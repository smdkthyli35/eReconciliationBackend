using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static class Company
        {
            public static string AddedCompany = "Şirket kayıt işlemi başarıyla gerçekleştirildi.";
            public static string CompanyAlreadyExists = "Bu şirket zaten mevcut. Lütfen farklı bir şirket giriniz.";
        }

        public static class User
        {
            public static string UserNotFound = "Kullanıcı bulunamadı.";
            public static string PasswordError = "Hatalı şifre girişi!";
            public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
            public static string UserRegistered = "Kullanıcı başarıyla oluşturuldu.";
            public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut. Lütfen farklı bir kullanıcı giriniz.";
            public static string UserMailConfirmSuccessful = "Mailiniz başarıyla onaylandı.";
        }

        public static class MailParameter
        {
            public static string MailParameterUpdate = "Mail parametreleri başarıyla güncellendi.";
        }

        public static class Mail
        {
            public static string MailSendSuccessful = "Mail gönderme işlemi başarılı.";
            public static string MailTemplateAdded = "Mail şablonu başarıyla kaydedildi.";
            public static string MailTemplateDeleted = "Mail şablonu başarıyla silindi.";
            public static string MailTemplateUpdated = "Mail şablonu başarıyla güncellendi.";
        }
    }
}
