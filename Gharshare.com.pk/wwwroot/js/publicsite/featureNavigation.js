window.onload = function () {
    //debugger;
    var sectionId = window.location.hash.substring(1); // Get the section ID from the URL fragment
    console.log(sectionId);
    if (sectionId === "advertise") {
        $('.adv,#aAd').addClass('active show');
        $('#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
    }
    else if (sectionId === "ltn_tab_1_2") {
        $('#ltn_tab_1_2,#aEnq').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_3") {
        $('#ltn_tab_1_3,#aMa').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_4") {
        $('#ltn_tab_1_4,#aCt').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,\
                                #ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_5") {
        $('#ltn_tab_1_5,#aCl').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_6") {
        $('#ltn_tab_1_6,#aSt').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_7") {
        $('#ltn_tab_1_7,#aCr').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_8") {
        $('#ltn_tab_1_8,#aCb').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_1_9") {
        $('#ltn_tab_1_9,#aCp').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_1") {
        $('#ltn_tab_2_1,#aTe').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_2") {
        $('#ltn_tab_2_2,#aCe').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_3") {
        $('#ltn_tab_2_3,#aGr').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_4") {
        $('#ltn_tab_2_4,#aOm').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,\
                                #ltn_tab_2_5,#aci,#ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_5") {
        $('#ltn_tab_2_5,#aci').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_6,#aSd').removeClass('active show');
        window.scrollTo(0, 400);
    }
    else if (sectionId === "ltn_tab_2_6") {
        $('#ltn_tab_2_6,#aSd').addClass('active show');
        $('.adv,#aAd,#ltn_tab_1_2,#aEnq,#ltn_tab_1_3,#aMa,#ltn_tab_1_4,\
                                #aCt,#ltn_tab_1_5,#aCl,#ltn_tab_1_6,#aSt,#ltn_tab_1_7,#aCr,\
                                #ltn_tab_1_8,#aCb,#ltn_tab_1_9,#aCp,#ltn_tab_2_1,#aTe,\
                                #ltn_tab_2_2,#aCe,#ltn_tab_2_3,#aGr,#ltn_tab_2_4,#aOm,\
                                #ltn_tab_2_5').removeClass('active show');
        window.scrollTo(0, 400);
    }
};
document.querySelector('a').addEventListener('click', function (e) {
    e.preventDefault();
    // Custom navigation logic
});
