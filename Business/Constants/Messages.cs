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
            public static string UpdatedCompany = "Şirket güncelleme işlemi başarıyla gerçekleştirildi.";
        }

        public static class User
        {
            public static string UserNotFound = "Kullanıcı bulunamadı.";
            public static string PasswordError = "Hatalı şifre girişi!";
            public static string SuccessfulLogin = "Başarıyla giriş yapıldı.";
            public static string UserRegistered = "Kullanıcı başarıyla oluşturuldu.";
            public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut. Lütfen farklı bir kullanıcı giriniz.";
            public static string UserMailConfirmSuccessful = "Mailiniz başarıyla onaylandı.";
            public static string MailConfirmSendSuccessful = "Mailiniz tekrardan gönderildi.";
            public static string MailAlreadyConfirm = "Bu mail zaten onaylanmış!";
            public static string MailConfirmTimeHasNotExpired = "Mail onayını 5 dakikada bir gönderebilirsiniz.";
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

        public static class CurrencyAccount
        {
            public static string AddedCurrencyAccount = "Cari kaydı başarıyla eklendi.";
            public static string DeletedCurrencyAccount = "Cari kaydı başarıyla silindi.";
            public static string UpdatedCurrencyAccount = "Cari kaydı başarıyla güncellendi.";
        }

        public static class AccountReconciliation
        {
            public static string AddedAccountReconciliation = "Cari mutabakat kaydı başarıyla eklendi.";
            public static string DeletedAccountReconciliation = "Cari mutabakat kaydı başarıyla silindi.";
            public static string UpdatedAccountReconciliation = "Cari mutabakat kaydı başarıyla güncellendi.";
        }

        public static class AccountReconciliationDetail
        {
            public static string AddedAccountReconciliationDetail = "Cari mutabakat detay kaydı başarıyla eklendi.";
            public static string DeletedAccountReconciliationDetail = "Cari mutabakat detay kaydı başarıyla silindi.";
            public static string UpdatedAccountReconciliationDetail = "Cari mutabakat detay kaydı başarıyla güncellendi.";
        }

        public static class BaBsReconciliation
        {
            public static string AddedBaBsReconciliation = "BaBs kaydı başarıyla eklendi.";
            public static string DeletedBaBsReconciliation = "BaBs kaydı başarıyla silindi.";
            public static string UpdatedBaBsReconciliation = "BaBs kaydı başarıyla güncellendi.";
        }

        public static class BaBsReconciliationDetail
        {
            public static string AddedBaBsReconciliationDetail = "BaBs detay kaydı başarıyla eklendi.";
            public static string DeletedBaBsReconciliationDetail = "BaBs detay kaydı başarıyla silindi.";
            public static string UpdatedBaBsReconciliationDetail = "BaBs detay kaydı başarıyla güncellendi.";
        }

        public static class OperationClaim
        {
            public static string AddedOperationClaim = "Yetki başarıyla eklendi.";
            public static string DeletedOperationClaim = "Yetki başarıyla silindi.";
            public static string UpdatedOperationClaim = "Yetki başarıyla güncellendi.";
        }

        public static class UserOperationClaim
        {
            public static string AddedUserOperationClaim = "Kullanıcıya yetki başarıyla eklendi.";
            public static string DeletedUserOperationClaim = "Kullanıcıya yetkibaşarıyla silindi.";
            public static string UpdatedUserOperationClaim = "Kullanıcıya yetki başarıyla güncellendi.";
        }
    }
}
