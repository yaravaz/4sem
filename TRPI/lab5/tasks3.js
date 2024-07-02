var Membership;
(function (Membership) {
    Membership[Membership["Simple"] = 0] = "Simple";
    Membership[Membership["Standart"] = 1] = "Standart";
    Membership[Membership["Premium"] = 2] = "Premium";
})(Membership || (Membership = {}));
var membership = Membership.Standart;
var membershipReverse = Membership[2];
console.log(membership); // 1
console.log(membershipReverse); // Premium
var SocialMedia;
(function (SocialMedia) {
    SocialMedia["VK"] = "VK";
    SocialMedia["FACEBOOK"] = "FaceBook";
    SocialMedia["INSTARGAM"] = "Instagram";
})(SocialMedia || (SocialMedia = {}));
var social = SocialMedia.INSTARGAM;
console.log(social);
