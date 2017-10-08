namespace VNS.Data.Models.ValidationRules
{
    public class PropertiesConstraints
    {
        // TODO name regex A-Za-z
        public const int AddressNameMinLenght = 5;
        public const int AddressNameMaxLenght = 300;
        public const int NameMinLenght = 2;
        public const int NameMaxLenght = 50;

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 50;

        // TODO add regex for alphanumeric
        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 50;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 4000;

        // TODO add regex for phone -> starts with zero
        public const int PhoneNumberLength = 10;
        public const string PhoneNumberContents = @"^0+[0-9]+$";

        public const string StringLengthError = "The {0} must be at least {2} characters long.";
    }
}
