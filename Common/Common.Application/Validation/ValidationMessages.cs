﻿namespace Common.Application.Validation
{
    public static class ValidationMessages
    {
        public const string Required = "وارد کردن این فیلد اجباری است";

        public const string InvalidPhoneNumber = "شماره تماس معتبر نیست";
        public const string NotFound = "اطلاعات درخواستی یافت نشد";
        public const string MaxLength = "تعداد کاراکتر های وارد شده بیشتر از حد مجاز است";
        public const string MinLength = "تعداد کاراکتر های وارد شده کمتر از حد مجاز است";

        public static string required(string field) => $"{field} is mandatory ";
        public static string maxLength(string field, int maxLength) => $"{field} must be less than {maxLength}";
        public static string minLength(string field, int minLength) => $"{field} must be bigger than {minLength}";
    }
}