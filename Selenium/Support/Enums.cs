using System.ComponentModel;

public enum PageName
{
    Home,
    SignIn,
    CreateAccount,
    MyAccount
}

public enum Element
{
    SignInLink,
    SignInButton,
    NewUserEmail,
    ExistingUserEmail,
    CreateAnAccountButton,
    MrRadioButtonOption,
    MrsRadioButtonOption,
    CustomerFirstName,
    CustomerLastName,
    Email,
    Password,
    BirthdateMonth,
    BirthdateDay,
    BirthdateYear,
    AddressFirstName,
    AddressLastName,
    Address,
    City,
    State,
    Zip,
    Country,
    MobilePhone,
    AddressAlias,
    RegisterButton,
    SignOutLink
}

public enum Title
{
    Mr,
    Mrs
}

public enum Month
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}

public enum State
{
    Washington
}

public enum Country
{
    [Description("United States")]
    UnitedStates
}