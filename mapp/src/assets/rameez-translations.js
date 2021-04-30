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
    "sure_want_to_logout":"Are you sure you want to logout?",
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
    "camera":"Camera",
    "gallery":"Gallery",
};
rameez_languages["fr"]={
    "reservations":"Réservation",
    "family":"Famille",
    "profile":"Profil",
    "logout":"Déconnecter",
    "sure_want_to_logout":"Envie de déconnecter?",
    "please_wait":"veuillez patienter",
    "get_started":"Démarrer",
    "login_with":"Connectez vous avec",
    "or":"Ou",
    "email":"Courriel",
    "enter_email":"Saisir l'adresse e-mail",
    "password":"Mot de passe",
    "login":"Connectez-vous à",
    "dont_have_an_account":"Pas de compte",
    "signup":"Inscription",
    "my_subscription":"Mon abonnement",
    "packages":"Paquets",
    "on_going":"En marche",
    "subscribe":"S'inscrire",
    "my_reservations":"Mes réservations",
    "upcoming":"Prochain",
    "previous":"Précédent",
    "reserve":"Réserver",
    "reservation":"Réservation",
    "pick_date":"Date de sélection",
    "pick_time":"Temps de sélection",
    "reserved":"Réserver",
    "free":"Gratuit",
    "share":"Partager",
    "add_to_calendar":"Ajouter au calendrier",
    "cancel":"Annuler",
    "sure_want_to_cancel":"Envie de l'annuler?",
    "family_members":"Membres de la famille",
    "title":"Titre",
    "relation":"Relation",
    "phone_number":"Numéro de téléphone",
    "enroll":"S'inscrire",
    "approved":"Approuvé",
    "pending":"En attendant",
    "my_profile":"Mon profil",
    "name":"Nom",
    "date_of_birth":"Date de naissance",
    "gender":"Genre",
    "update":"Mettre à jour",
    "camera":"Caméra",
    "gallery":"Galerie",
};