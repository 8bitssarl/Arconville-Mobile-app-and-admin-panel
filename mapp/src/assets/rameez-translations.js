var rameez_languages=[];

function get_rameez_language_translation(value,langArg){
    let defaultLang='en';
    let lang = defaultLang;
    if (langArg){
        lang=langArg;
    }
    if (rameez_languages){
        let langs=rameez_languages;
        if (langs[lang]){
            if (langs[lang][value]){
                return langs[lang][value];
            }
            if (lang!=defaultLang && langs[defaultLang][value]){
                return langs[defaultLang][value];
            }
        }
    }
    return value;
}


rameez_languages["en"]={
    "reservations":"Reservations",
    "family":"Family",
    "profile":"Profile",
    "logout":"Logout",
    "please_wait":"Please wait",
    "get_started":"Get Started",
    "login_with":"LOGIN WITH",
    "or":"OR",
    "email":"Email",
    "enter_email":"Enter email",
    "password":"Password",
    "login":"login",
    "dont_have_an_account":"Don't have an account",
    "signup":"Signup",
    "my_subscription":"My Subscription",
    "packages":"Packages",
    "on_going":"On Going",
    "subscribe":"Subscribe",
    "my_reservations":"My Reservations",
    "upcoming":"Upcoming",
    "previous":"Previous",
    "reserve":"Reserve",
    "reservation":"Reservation",
    "pick_date":"Pick Date",
    "pick_time":"Pick Time",
    "reserved":"Reserved",
    "free":"Free",
    "share":"Share",
    "add_to_calendar":"Add to Calendar",
    "cancel":"Cancel",
    "sure_want_to_cancel":"Are you sure you want to cancel?",
    "family_members":"Family Members",
    "title":"Title",
    "relation":"Relation",
    "phone_number":"Phone Number",
    "enroll":"Enroll",
    "approved":"Approved",
    "pending":"Pending",
    "my_profile":"My Profile",
    "name":"Name",
    "date_of_birth":"Date of birth",
    "gender":"Gender",
    "update":"Update",
};
rameez_languages["fr"]={
    "reservations":"Fr Reservations",
    "family":"Fr Family",
    "profile":"Fr Profile",
    "logout":"Fr Logout",
    "please_wait":"French Please wait",
    "get_started":"French Get Started",
    "login_with":"French LOGIN WITH",
    "or":"French OR",
    "email":"French Email",
    "enter_email":"French Enter email",
    "password":"French Password",
    "login":"French login",
    "dont_have_an_account":"French Don't have an account",
    "signup":"French Signup",
    "my_subscription":"French My Subscription",
    "packages":"French Packages",
    "on_going":"French On Going",
    "subscribe":"French Subscribe",
    "my_reservations":"French My Reservations",
    "upcoming":"French Upcoming",
    "previous":"French Previous",
    "reserve":"French Reserve",
    "reservation":"French Reservation",
    "pick_date":"French Pick Date",
    "pick_time":"French Pick Time",
    "reserved":"Fr Reserved",
    "free":"Fr Free",
    "share":"Fr Share",
    "add_to_calendar":"Fr Add to Calendar",
    "cancel":"Fr Cancel",
    "sure_want_to_cancel":"Fr Are you sure you want to cancel?",
    "family_members":"Fr Family Members",
    "title":"Fr Title",
    "relation":"Fr Relation",
    "phone_number":"Fr Phone Number",
    "enroll":"Fr Enroll",
    "approved":"Fr Approved",
    "pending":"Fr Pending",
    "my_profile":"french My Profile",
    "name":"Fr Name",
    "date_of_birth":"Fr Date of birth",
    "gender":"Fr Gender",
    "update":"Fr Update",
};